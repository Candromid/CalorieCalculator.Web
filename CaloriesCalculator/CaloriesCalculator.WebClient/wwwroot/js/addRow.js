function addNewRow() {
    var table = document.querySelector('table');
    var rowCount = table.rows.length - 2; // Subtract 2 to exclude the "total" rows
    var row = table.insertRow(rowCount);

    var cellIndex = row.insertCell();
    cellIndex.textContent = rowCount;

    var cellName = row.insertCell();
    cellName.innerHTML = '<input type="text" class="product-name" name="name" />';

    var cellWeight = row.insertCell(); // New cell
    cellWeight.innerHTML = '<input type="text" class="product-weight" name="weight" />';

    var cellProteins = row.insertCell();
    cellProteins.innerHTML = '<input type="text" class="product-proteins" name="proteins" readonly value="0" />';

    var cellFats = row.insertCell();
    cellFats.innerHTML = '<input type="text" class="product-fats" name="fats" readonly value="0" />';

    var cellCarbs = row.insertCell();
    cellCarbs.innerHTML = '<input type="text" class="product-carbs" name="carbs" readonly value="0" />';

    var cellCalories = row.insertCell(); // New cell
    cellCalories.innerHTML = '<input type="text" class="product-calories" name="calories" readonly value="0" />';

    var cellDelete = row.insertCell(); // New cell for delete button
    cellDelete.innerHTML = '<button type="button" class="delete-row">🗑️</button>';


    var tableRows = $('table tr').length - 1; // минус строка заголовка
    if (tableRows > 1) {
        $('.delete-row').prop('disabled', false);
    }




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
            var nameInput = row.find('.product-name');

            // сохраняем информацию о продукте в атрибутах data-*
            nameInput.data('proteinsPerGram', ui.item.proteins / 100);
            nameInput.data('fatsPerGram', ui.item.fats / 100);
            nameInput.data('carbsPerGram', ui.item.carbohydrates / 100);
        }
    });

    // Обработчик событий для поля ввода веса
    $(document).on('input', '.product-weight', function () {
        var row = $(this).closest('tr');
        var weight = $(this).val();
        var nameInput = row.find('.product-name');

        // извлекаем информацию о продукте из атрибутов data-*
        var proteinsPerGram = nameInput.data('proteinsPerGram');
        var fatsPerGram = nameInput.data('fatsPerGram');
        var carbsPerGram = nameInput.data('carbsPerGram');

        var proteins = (proteinsPerGram * weight).toFixed(2);
        var fats = (fatsPerGram * weight).toFixed(2);
        var carbs = (carbsPerGram * weight).toFixed(2);

        var calories = (4 * proteins + 9 * fats + 4 * carbs).toFixed(2);

        row.find('.product-proteins').val(proteins);
        row.find('.product-fats').val(fats);
        row.find('.product-carbs').val(carbs);
        row.find('.product-calories').val(calories);

        calculateTotal();
    });
}

function calculateTotal() {
    var totalWeight = 0;
    var totalProteins = 0;
    var totalFats = 0;
    var totalCarbs = 0;
    var totalCalories = 0;

    $(".product-weight").each(function () {
        var weight = parseFloat($(this).val());
        if (!isNaN(weight)) {
            totalWeight += weight;

            var row = $(this).closest('tr');
            var proteins = parseFloat(row.find('.product-proteins').val());
            var fats = parseFloat(row.find('.product-fats').val());
            var carbs = parseFloat(row.find('.product-carbs').val());
            var calories = parseFloat(row.find('.product-calories').val());

            totalProteins += proteins;
            totalFats += fats;
            totalCarbs += carbs;
            totalCalories += calories;
        }
    });

    $("input[name='totalWeight']").val(totalWeight.toFixed(2));
    $("input[name='totalProteins']").val(totalProteins.toFixed(2));
    $("input[name='totalFats']").val(totalFats.toFixed(2));
    $("input[name='totalCarbs']").val(totalCarbs.toFixed(2));
    $("input[name='totalCalories']").val(totalCalories.toFixed(2));

    $("input[name='totalPer100gWeight']").val('100');
    $("input[name='totalPer100gProteins']").val((totalProteins * 100 / totalWeight).toFixed(2));
    $("input[name='totalPer100gFats']").val((totalFats * 100 / totalWeight).toFixed(2));
    $("input[name='totalPer100gCarbs']").val((totalCarbs * 100 / totalWeight).toFixed(2));
    $("input[name='totalPer100gCalories']").val((totalCalories * 100 / totalWeight).toFixed(2));
}

$(document).on('click', '.delete-row', function () {
    $(this).closest('tr').remove();
    var tableRows = $('table tr').length - 1; // минус строка заголовка (если у вас есть заголовок)
    if (tableRows === 1) {
        $('.delete-row').prop('disabled', true);
    } else {
        $('.delete-row').prop('disabled', false);
    }
    calculateTotal();
});

$(function () {
    setupAutocomplete();
    calculateTotal();
});
