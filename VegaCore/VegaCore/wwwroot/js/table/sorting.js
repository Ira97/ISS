function sorting(btn) {
    const icon = btn.childNodes[0];
    switch (icon.className) {
    case "fa fa-unsorted":
        icon.className = "fa fa-sort-desc";
        $("#Sorting").val('True');
        break;
    case "fa fa-sort-desc":
        icon.className = "fa fa-sort-asc";
        $("#Sorting").val('False');
        break;
    case "fa fa-sort-asc":
        icon.className = "fa fa-sort-desc";
        $("#Sorting").val('True');
        break;
    }
    const id = btn.parentNode.id;
    $("#OrderBy").val(id);
    $("#mainForm").submit();
}