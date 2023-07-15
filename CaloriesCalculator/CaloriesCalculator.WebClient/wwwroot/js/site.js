function addNewRow() {
    var table = document.querySelector('table');
    var rowCount = table.rows.length - 2; // Subtract 2 to exclude the "total" rows
    var row = table.insertRow(rowCount);

    var cellIndex = row.insertCell();
    cellIndex.textContent = rowCount;

    var cellName = row.insertCell();
    cellName.innerHTML = '<input type="text" class="product-name" name="name" />';

    var cellWeight = row.insertCell(); // Новая ячейка
    cellWeight.innerHTML = '<input type="text" class="product-weight" name="weight" />';

    var cellProteins = row.insertCell();
    cellProteins.innerHTML = '<input type="text" class="product-proteins" name="proteins" />';

    var cellFats = row.insertCell();
    cellFats.innerHTML = '<input type="text" class="product-fats" name="fats" />';

    var cellCarbs = row.insertCell();
    cellCarbs.innerHTML = '<input type="text" class="product-carbs" name="carbs" />';

    var cellCalories = row.insertCell(); // Новая ячейка
    cellCalories.innerHTML = '<input type="text" class="product-calories" name="calories" />';

    var cellDelete = row.insertCell(); // Новая ячейка для кнопки удаления
    cellDelete.innerHTML = '<button type="button" class="delete-row">🗑️</button>';

    setupAutocomplete();
}

function setupAutocomplete() {
    $(".product-name").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/CalcCalorie/SearchProducts',
                type: 'GET',
                data: {
                    term: request.term
                },
                success: function (data) {
                    response(data);
                }
            });
        },
        select: function (event, ui) {
            var row = $(this).closest('tr');
            row.find('.product-proteins').val(ui.item.proteins);
            row.find('.product-fats').val(ui.item.fats);
            row.find('.product-carbs').val(ui.item.carbohydrates);
        }
    });
}
$(document).on('click', '.delete-row', function () {
    setupAutocomplete();
    $(this).closest('tr').remove();
});
