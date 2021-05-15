function createReport() {
    $.post("/Report/CreateExcel", $("#mainForm").serialize()).done(function (data) {
        window.location = `/Report/Download?fileGuid=${data.guid}&filename=${data.name}`;
    });
};