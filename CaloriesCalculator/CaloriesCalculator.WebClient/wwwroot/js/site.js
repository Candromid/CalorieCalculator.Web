function addNewRow() {
    var table = document.querySelector('table');
    var rowCount = table.rows.length - 2; // Subtract 2 to exclude the "total" rows
    var row = table.insertRow(rowCount);

    var cellIndex = row.insertCell();
    cellIndex.textContent = rowCount ++;

    var cellName = row.insertCell();
    cellName.innerHTML = '<input type="text" class="product-name" name="name" />';

    var cellProteins = row.insertCell();
    cellProteins.innerHTML = '<input type="text" class="product-proteins" name="proteins" />';

    var cellFats = row.insertCell();
    cellFats.innerHTML = '<input type="text" class="product-fats" name="fats" />';

    var cellCarbs = row.insertCell();
    cellCarbs.innerHTML = '<input type="text" class="product-carbs" name="carbs" />';

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

$(function () {
    setupAutocomplete();
});
