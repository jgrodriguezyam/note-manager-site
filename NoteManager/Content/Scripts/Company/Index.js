var idColumn = "Id";
var nameColumn = "Name";
var addressColumn = "Address";
var colonyColumn = "Colony";
var cityColumn = "City";
var rfcColumn = "Rfc";
var officePhoneColumn = "OfficePhone";
var officeCellPhoneColumn = "OfficeCellPhone";
var dateColumn = "Date";

var filtersTable = ["Name", "Colony", "City"];

createTable({
    Controller: "Company",
    ClickToSelect: false,
    Columns: [[idColumn, "Codigo", true],
              [nameColumn, "Nombre", true],
              [addressColumn, "Dirección", true],
              [colonyColumn, "Colonia", true],
              [cityColumn, "Ciudad", true],
              [rfcColumn, "RFC", true],
              [officePhoneColumn, "Telefono", true],
              [officeCellPhoneColumn, "Celular", true],
              [dateColumn, "Fecha", true]],
    Buttons: [buttonInfo, buttonEdit, buttonDelete],
    Filters: filtersTable,
    CardView: { ApplyCardView: true, WidthPerApply: 600 },
    SortingAndPagination: { SortBy: idColumn, Sort: "DESC" }
});

function buttonDelete(buttons, row) {
    buttons.OperateEvents['click .btnDelete'] = function (event, value, row) {
        createDialog({
            Id: row.Id,
            Entity: "Company",
            Root: root + "Company",
            Title: "Eliminar",
            Message: "¿Deseas eliminar el registro? ",
            Type: BootstrapDialog.TYPE_DANGER,
            Buttons: { Cancel: true, Delete: true }
        });
    };
    return " <button class='btnDelete btn btn-danger btn-sm' data-toggle='tooltip' title='Eliminar'><i class='fa fa-trash-o'></i></button>";
}

function buttonEdit(buttons) {
    buttons.OperateEvents['click .btnEdit'] = function (event, value, row) {
        redirectWithId("Company", "Edit", row.Id);
    };

    return " <button class='btnEdit btn btn-default btn-sm' data-toggle='tooltip' title='Editar'><i class='fa fa-pencil'></i></button>";
}

function buttonInfo(buttons) {
    buttons.OperateEvents['click .btnInfo'] = function (event, value, row) {
        var parameters = "id=" + row.Id;
        redirectWithParameters("Company", "Details", parameters);
    };

    return " <button class='btnInfo btn btn-default btn-sm' data-toggle='tooltip' title='Informacion'><i class='fa fa-info-circle'></i></button>";
}