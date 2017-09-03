var idColumn = "Id";
var fullNameColumn = "FullName";
var genderColumn = "Gender";
var addressColumn = "Address";
var colonyColumn = "Colony";
var municipalityColumn = "Municipality";
var homePhoneColumn = "HomePhone";
var cellPhoneColumn = "CellPhone";

var filtersTable = ["Name", "Colony", "Municipality"];

createTable({
    Controller: "Customer",
    ClickToSelect: false,
    Columns: [[idColumn, "Codigo", true],
              [fullNameColumn, "Nombre", true],
              [genderColumn, "Genero", true],
              [addressColumn, "Dirección", true],
              [colonyColumn, "Colonia", true],
              [municipalityColumn, "Municipio", true],
              [homePhoneColumn, "Telefono", true],
              [cellPhoneColumn, "Celular", true]],
    Buttons: [buttonInfo, buttonEdit, buttonDelete],
    Filters: filtersTable,
    CardView: { ApplyCardView: true, WidthPerApply: 600 },
    SortingAndPagination: { SortBy: idColumn, Sort: "DESC" },
    ChangeColumnSortBy: [[fullNameColumn, "Name"]],
    ChangeColumnValues: [[genderColumn, genderChangeValue]]
});

function genderChangeValue(gender) {
    if (gender === 1) {
        return "Masculino";
    } else {
        return "Femenino";
    }
}

function buttonDelete(buttons, row) {
    buttons.OperateEvents['click .btnDelete'] = function (event, value, row) {
        createDialog({
            Id: row.Id,
            Entity: "Customer",
            Root: root + "Customer",
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
        redirectWithId("Customer", "Edit", row.Id);
    };

    return " <button class='btnEdit btn btn-default btn-sm' data-toggle='tooltip' title='Editar'><i class='fa fa-pencil'></i></button>";
}

function buttonInfo(buttons) {
    buttons.OperateEvents['click .btnInfo'] = function (event, value, row) {
        var parameters = "id=" + row.Id;
        redirectWithParameters("Customer", "Details", parameters);
    };

    return " <button class='btnInfo btn btn-default btn-sm' data-toggle='tooltip' title='Informacion'><i class='fa fa-info-circle'></i></button>";
}

//function buttonPrint(buttons) {
//    buttons.OperateEvents['click .printSheet'] = function (event, value, row) {
//        redirectWithId("Customer", "Print", row.Id);
//    };

//    return " <button class='printSheet btn btn-info btn-sm' data-toggle='tooltip' title='Imprimir'><i class='fa fa-print'></i></button>";
//}