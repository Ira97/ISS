function addSearchCount() {
    var count = $("#SearchCount").val();
    count++;
    const filterGroup = document.getElementById(`filterGroup`);
    filterGroup.insertAdjacentHTML('beforeend', `<div class="row" id="filterRow${count}">\r\n 
<div class="input-group mb-3 col-lg-12">\r\n
<div class="input-group-prepend">\r\n
<label class="input-group-text">Фильтр</label>\r\n</div>\r\n
<select class="form-control custom-select" id="searchList${count}" name="SearchList[${count}].Type">
<option value="">Выберите фильтр...</option>\r\n
</select>\r\n
</div>\r\n
<div class="input-group mb-3 col-lg-12">\r\n
<input data-role="tagsinput" id="tagPlaces${count}" name="SearchList[${count}].Value" placeholder="Поиск..." type="text" value=""">\r\n
<div class="input-group-append">\r\n
<button class="btn btn-outline-secondary" type="button" onclick="addSearchCount()">Добавить</button>\r\n
<button class="btn btn-outline-secondary" type="button" onclick="removeSearchCount()">x</button>\r\n
</div>\r\n</div>\r\n </div>`);
    $.get(`/${$("#ControllerName").val()}/GetFilterList`).done(function (data) {
        const select = document.getElementById(`searchList${count}`);
        data.forEach(function (index) {
            select.options[select.options.length] = new Option(index.value, index.key);
        });

    });
    $(`#tagPlaces${count}`).tagsinput();
    $("#SearchCount").val(count);
};

function removeSearchCount() {
    var count = $("#SearchCount").val();
    const original = document.getElementById(`filterRow${count}`);
    original.remove();
    count--;
    $("#SearchCount").val(count);
};