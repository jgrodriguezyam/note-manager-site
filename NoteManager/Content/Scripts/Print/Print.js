$(function () {
    retrieveCompanies();
    setDate();
    openPrintSheet();
});

function retrieveCompanies() {
    var entity = $("#CompanyId").attr("data-entity");
    var data = "";
    var callbackSuccess = function (response) {
        $.each(response.Records, function (i, item) {
            $('#CompanyId').append($('<option>', {
                value: item.Id,
                text: item.Name
            }));
        });
        ajaxButton.show();
    }

    ajaxButton.hide();
    filterPerAjax(entity, data, callbackSuccess);
}

function setDate() {
    createDateRangePicker("#Date", true, "down", null, null);
}

function openPrintSheet() {
    $("#CustomerId").keyup(function (e) {
        if (e.keyCode == 13) {
            $("#PrintSheet").submit();
        }
    });
}