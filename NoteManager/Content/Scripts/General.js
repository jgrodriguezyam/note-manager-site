//VARIABLES ==================================================================
var valueExtracted = "";
var index;
var root = $("body").data("root");
var formatDate = 'DD/MM/YYYY';
var requetType = { Post: "POST", Get: "GET" };
var fileType = { Image: "Imagen", Pdf: "PDF"};
var resultType = { Ok: "Success", Failure: "Failure", Information: "Information" };
var regExprToRequestForm = /^[u00C0-\u00FFA-Za-z\d\s%-&()_@.,]+$/;
var regExprToFilter = /&#|<!|<\?|<\/|<[a-zA-Z]|{|}/ ;
var loading = "</div><div class='col-lg-12' style='text-align: center; font-size: 25px; padding: 50px; opacity: .5;'><i class='fa fa-cog fa-spin'></i><span> Cargando contenido... </span></div>";
var dateNow = function () {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10)
        dd = '0' + dd;

    if (mm < 10)
        mm = '0' + mm;

    today = dd + '/' + mm + '/' + yyyy;
    return today;
};

//GENERAL ==================================================================
function require(script) {
    var len = $('script').filter(function () {
        return ($(this).attr('src') == script);
    }).length;

    if (len === 0) {
        $.ajaxSetup({ async: false });
        $.getScript(script);
        $.ajaxSetup({ async: true });
    }
}

function redirectWithId(controller, action, id) {

    window.location.href = root + controller + "/" + action + "/" + id;
}

function redirectWithParameters(controller, action, parameters) {

    window.location.href = root + controller + "/" + action + "?" + parameters;
}

function redirect(controller, action) {

    window.location.href = root + controller + "/" + action;
}

function isNumberKeyUp(evt) {
    var charCode = (evt.keyCode.which) ? evt.keyCode.which : event.keyCode;
    if (charCode == 45 || (charCode != 46 && (charCode > 31))
      && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isNumberKeyDow(evt) {
    if (evt.keyCode != 86 || !evt.ctrlKey)
        return false;

    return true;
}

function elementExistInArray(element, array) {
    return $.inArray(element, array) > -1;
}

function formatNumber() {
    $('input.number').number(true, 0);
}

function SumValues(value1, value2) {
    return (parseFloat(value1) + parseFloat(value2)).toFixed(2);
}

function deductValues(value1, value2) {
    return parseFloat(value1) - parseFloat(value2);
}

function dividerValues(value1, value2) {
    return parseFloat(value1) / parseFloat(value2);
}

function multiplyValues(value1, value2) {
    return (parseFloat(value1) * parseFloat(value2)).toFixed(2);
}

function isGreaterThan(value1, value2) {
    return (parseFloat(value1) > parseFloat(value2));
}

function isInValidRequestForm(value) {
    return regExprToRequestForm.test(value);
}

function isInValidFilter(value) {
    return regExprToFilter.test(value);
}

function tryActiveElement($element, isActive) {
    if (!$element.parent().hasClass("active") && isActive) {
        $element.parent().trigger("click");
    }
    if ($element.parent().hasClass("active") && !isActive) {
        $element.parent().trigger("click");
    }
}

function setSocialSecurityNumberFieldFormat(fieldElement) {
    var fieldValue = $(fieldElement).val().match(/\d/g);
    var format = "";
    if (fieldValue == null) {
        $(fieldElement).val(format);
        return false;
    }

    var numbers = fieldValue.join("");

    if (numbers.length > 3)
        format = numbers.substr(0, 3) + "-" + numbers.substr(3, 2);

    if (numbers.length > 5)
        format = format + "-" + numbers.substr(5, 4);

    if (numbers.length <= 3)
        format = numbers;

    $(fieldElement).val(format);
}

function setPhoneNumberFieldFormat(fieldElement) {
    var fieldValue = $(fieldElement).val().match(/\d/g);
    var format = "";
    if (fieldValue == null) {
        $(fieldElement).val(format);
        return false;
    }
    
    var numbers = fieldValue.join("");

    if (numbers.length > 3)
        format = numbers.substr(0, 3) + "-" + numbers.substr(3, 3);

    if (numbers.length > 6)
        format = format + "-" + numbers.substr(6, 4);

    if (numbers.length <= 3)
        format = numbers;

    $(fieldElement).val(format);
}

function setPostalCodeFieldFormat(fieldElement) {
    var fieldValue = $(fieldElement).val().match(/\d/g);
    var format = "";
    if (fieldValue == null) {
        $(fieldElement).val(format);
        return false;
    }

    var numbers = fieldValue.join("");

    if (numbers.length > 5)
        format = numbers.substr(0, 5);

    if (numbers.length <= 5)
        format = numbers;

    $(fieldElement).val(format);
}

function setSocialSecurityNumberFormat(fieldElement) {
    $(fieldElement).keyup(function () {
        setSocialSecurityNumberFieldFormat(fieldElement);
    });
    $(fieldElement).change(function () {
        setSocialSecurityNumberFieldFormat(fieldElement);
    });
    $(fieldElement).click(function () {
        setSocialSecurityNumberFieldFormat(fieldElement);
    });
}

function setPhoneNumberFormat(fieldElement) {
    $(fieldElement).keyup(function () {
        setPhoneNumberFieldFormat(fieldElement);
    });
    $(fieldElement).change(function () {
        setPhoneNumberFieldFormat(fieldElement);
    });
    $(fieldElement).click(function () {
        setPhoneNumberFieldFormat(fieldElement);
    });
}

function setPostalCodeFormat(fieldElement) {
    var fieldValue = $(fieldElement).val();
    if (fieldValue == 0) {
        $(fieldElement).val("");
    }

    $(fieldElement).keyup(function () {
        setPostalCodeFieldFormat(fieldElement);
    });
    $(fieldElement).change(function () {
        setPostalCodeFieldFormat(fieldElement);
    });
    $(fieldElement).click(function () {
        setPostalCodeFieldFormat(fieldElement);
    });
}

//PASSWORD ==================================================================
function actionToClickTopreviewPassword() {
    viewPasswordElement
        .mousedown(function () { $(this).closest(".form-group").find("input").attr('type', 'text'); })
        .mouseup(function () { $(this).closest(".form-group").find("input").attr('type', 'password'); });
}

//MULTIMEDIA==================================================================
function extractValue(value, row) {
    switch (value) {
        case "Status":
            var classBySpan = row["Status"] == true ? "success" : "danger";
            var displayBySpan = row["Status"] == true ? "activo" : "inactivo";
            valueExtracted = '<span class="label label-' + classBySpan + ' pull-right" style="margin-top: 8px;">' + displayBySpan + '</span>';
            break;
        default:
            valueExtracted = row[value];
            break;
    }
}

function resolveFileSize(fileid) {
    try {
        var fileSize = 0;
        //for IE
        if ($.browser.msie) {
            //before making an object of ActiveXObject, 
            //please make sure ActiveX is enabled in your IE browser
            var objFSO = new ActiveXObject("Scripting.FileSystemObject");
            var filePath = $("#" + fileid)[0].value;
            var objFile = objFSO.getFile(filePath);
            var fileSize = objFile.size; //size in kb
            fileSize = fileSize / 1048576; //size in mb 
        }
        //for FF, Safari, Opeara and Others
        else {
            fileSize = $("#" + fileid)[0].files[0].size //size in kb
            fileSize = fileSize / 1048576; //size in mb 
        }
        alert("Uploaded File Size is" + fileSize + "MB");
    }
    catch (e) {
        alert("Error detecting file size:" + e);
    }
}

//DATE & TIME ==================================================================
function createStartDateAndEndDateRangePicker() {
    //VARIABLES
    var startDateElement = $("#StartDate");
    var endDateElement = $("#EndDate");
    var formElement = $("#Form");
    var minDate = moment();
    var startDate = moment();
    var endDate = moment();

    //INTERNAL
    function resolveMinDate() {
        if (startDateElement.val() != "" && moment(startDateElement.val(), formatDate) > moment(dateNow(), formatDate))
            minDate = startDateElement.val();
    }
    function resolveStartDate() {
        if (startDateElement.val() != "" && moment(startDateElement.val(), formatDate) > moment(dateNow(), formatDate))
            startDate = startDateElement.val();
    }
    function resolveEndDate() {
        if (endDateElement.val() != "" && moment(endDateElement.val(), formatDate) > moment(dateNow(), formatDate))
            endDate = endDateElement.val();
    }

    function startDateRangePicker() {
        startDateElement.daterangepicker({
            "singleDatePicker": true,
            "locale": {
                format: formatDate
            },
            "autoApply": true,
            "linkedCalendars": false,
            "minDate": minDate,
            "startDate": startDate
        }).change('input', function () {
            formElement.bootstrapValidator('revalidateField', 'StartDate');
            formElement.bootstrapValidator('revalidateField', 'EndDate');
        });
    }

    function endDateRangePicker() {
        endDateElement.daterangepicker({
            "singleDatePicker": true,
            "locale": {
                format: formatDate
            },
            "autoApply": true,
            "linkedCalendars": false,
            "minDate": minDate,
            "startDate": endDate
        }).change('input', function () {
            formElement.bootstrapValidator('revalidateField', 'StartDate');
            formElement.bootstrapValidator('revalidateField', 'EndDate');
        });
    }

    //INSTANCE
    resolveMinDate();
    resolveStartDate();
    resolveEndDate();
    startDateRangePicker();
    endDateRangePicker();

}

function createDateRangePicker() {
    $(".dateRangePicker").daterangepicker({
        autoUpdateInput: false,
        "singleDatePicker": true,
        "locale": {
            format: formatDate,
        },
        "autoApply": true,
        "linkedCalendars": false,
        //"minDate": moment(),
        "startDate": moment()
    });
    $('.dateRangePicker').on("apply.daterangepicker", function (e, picker) {
        picker.element.val(picker.startDate.format(picker.locale.format));
    });
}

function createDateRangePicker(fieldElement, showDropdowns, drops, minDate, maxDate) {
    var startDate = moment();
    var fieldValue = $(fieldElement).val();
    if (fieldValue != "")
        startDate = fieldValue;
    if (minDate == null) 
        minDate = moment().subtract(100, "years").format("DD/MM/YYYY");
    if (maxDate == null)
        maxDate = moment().add(20, "years").format("DD/MM/YYYY");

    $(fieldElement).daterangepicker({
        autoUpdateInput: false,
        "singleDatePicker": true,
        "locale": {
            format: formatDate,
        },
        "autoApply": true,
        "linkedCalendars": false,
        "minDate": minDate,
        "maxDate": maxDate,
        "startDate": startDate,
        showDropdowns: showDropdowns,
        "drops": drops
    });

    $(fieldElement).on("apply.daterangepicker", function (e, picker) {
        picker.element.val(picker.startDate.format(picker.locale.format));
    });
}


function clickToIconCalendar() {
    $('.dateRangePicker i').click(function () {
        $(this).parent().find('input').click();
    });
}

//TABLE ==================================================================
function truncateString(value, length, useWordBoundary) {
    length = (length == undefined || length == null) ? 16 : length;
    useWordBoundary = (useWordBoundary == undefined || useWordBoundary == null) ? false : useWordBoundary;

    if (value != undefined && value != null && (typeof value == "string" || value instanceof string !== false)) {
        var toLong = value.length > length;
        var s = toLong ? value.substr(0, length) : value;

        if (useWordBoundary) {
            s = useWordBoundary && toLong ? s.substr(0, s.lastIndexOf(' ')) : s;
        }

        value = toLong ? s + '&hellip;' : s;
    }

    return value;
}

//AJAX ==================================================================

function FormPerAjax(entity, id, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/Form',
        type: requetType.Get,
        dataType: 'html',
        async: true,
        data: { id: id },
        contentType: "application/json",
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function (e) {
            if (callbackError) callbackError();
            alertError("Error al intentar recuperar los registros.");
        }
    });
}

function filterPerAjax(entity, data, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/Filter',
        type: requetType.Get,
        dataType: 'json',
        async: true,
        data: data,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("Error al intentar recuperar los registros.");
        }
    });
}

function getPerAjax(entity, action, callbackSuccess, dataType, callbackError) {
    if (!dataType) dataType = 'json';
    $.ajax({
        url: root + entity + '/' + action,
        type: requetType.Get,
        dataType: dataType,
        async: true,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function (e) {
            if (callbackError) callbackError();
            alertError("Error al intentar recuperar los registros.");
        }
    });
}

function deletePerAjax(entity, id, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/Delete',
        type: requetType.Post,
        async: true,
        data: { id: id },
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("No se ha podido establecer conexi&oacute;n con el servicio.");
        }
    });
}

function changeStatusPerAjax(entity, id, status, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/ChangeStatus',
        type: requetType.Post,
        async: true,
        data: { id: id, status: status },
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("No se ha podido establecer conexi&oacute;n con el servicio.");
        }
    });
}

function changePasswordPerAjax(entity, data, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + "/ChangePassword",
        type: requetType.Post,
        async: true,
        data: data,
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("No se ha podido establecer conexi&oacute;n con el servicio.");
        }
    });
}

function savePerAjax(entity, method, callbackSuccess, callbackError, idform) {
    if (method == "undefined") method = "Create";
    if (idform == "undefined") idform = "#Form" + entity;
    $.ajax({
        url: root + entity + '/' + method,
        type: requetType.Post,
        cache: 'false',
        data: $(idform).serialize(),
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            alertError("No se ha podido establecer conexi&oacute;n con el servicio.");
        }
    });
}

function otherFilterPerAjax(entity, action, data, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/' + action,
        type: requetType.Get,
        dataType: 'json',
        async: true,
        data: data,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("Error al intentar recuperar los registros.");
        }
    });
}

function checkResponseToAjax(response) {
    //if (response.Result == resultType.Ok && response.Message != undefined)
    //    alertSuccess(response.Message);
    if (response.Result == resultType.Information)
        alertInfo(response.Message);
    else if (response.Result == resultType.Failure)
        alertError(response.Message);
    else if (response.Result == resultType.LostSession || response.Result == resultType.InvalidSerial) {
        alertError(response.Message);
        setTimeout(function () {
            return window.location.href = root + "Account/Login/";
        }, 2000);
    }
}

var ajaxButton = {
    _requestsInProcess: 0,
    hide: function () {
        if (this._requestsInProcess == 0) {
            $("#Next").prop("disabled", true);
        }

        this._requestsInProcess++;
    },

    show: function () {
        this._requestsInProcess--;
        if (this._requestsInProcess == 0) {
            $("#Next").prop("disabled", false);
        }
    }
};


//NOTIFICATIONS ==================================================================
var options = { extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right', theme: 'flat' };

function alertInfo(message) {
    Messenger.options = options;

    Messenger().post({
        message: message,
        type: 'info',
        showCloseButton: true
    });
}

function alertSuccess(message) {
    Messenger.options = options;

    Messenger().post({
        message: message,
        type: 'success',
        showCloseButton: true
    });
}

function alertError(message) {
    Messenger.options = options;

    Messenger().post({
        message: message,
        type: 'error',
        showCloseButton: true
    });
}

function hideAllAlerts() {
    Messenger().hideAll();
}

//AJAX ==================================================================
$(document).ajaxSuccess(function (event, httpRequest, settings, response) {
    var x = "";
    if (settings.type.toLowerCase() == 'post')
        checkResponseToAjax(response);
});

//Loading ===============================================================
var saveDialogMessage = "Guardando";
var waitingDialog = waitingDialog || (function ($) {
    'use strict';

    // Creating modal dialog's DOM
    var $dialog = $(
		'<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
		'<div class="modal-dialog modal-m">' +
		'<div class="modal-content">' +
			'<div class="modal-header"><h3 style="margin:0;"></h3></div>' +
			'<div class="modal-body">' +
				'<div class="progress progress-striped active" style="margin-bottom:0;"><div class="progress-bar" style="width: 100%"></div></div>' +
			'</div>' +
		'</div></div></div>');

    return {
        /**
		 * Opens our dialog
		 * @param message Custom message
		 * @param options Custom options:
		 * 				  options.dialogSize - bootstrap postfix for dialog size, e.g. "sm", "m";
		 * 				  options.progressType - bootstrap postfix for progress bar type, e.g. "success", "warning".
		 */
        show: function (message, options) {
            // Assigning defaults
            if (typeof options === 'undefined') {
                options = {};
            }
            if (typeof message === 'undefined') {
                message = 'Loading';
            }
            var settings = $.extend({
                dialogSize: 'm',
                progressType: '',
                onHide: null // This callback runs after the dialog was hidden
            }, options);

            // Configuring dialog
            $dialog.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
            $dialog.find('.progress-bar').attr('class', 'progress-bar');
            if (settings.progressType) {
                $dialog.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
            }
            $dialog.find('h3').text(message);
            // Adding callbacks
            if (typeof settings.onHide === 'function') {
                $dialog.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                    settings.onHide.call($dialog);
                });
            }
            // Opening dialog
            $dialog.modal();
        },
        /**
		 * Closes dialog
		 */
        hide: function () {
            $dialog.modal('hide');
        }
    };

})(jQuery);

//TABLE
function clearOpacity() {
    $('.page-content').addClass('page-content-ease-in');
}

function addOpacity() {
    $('.page-content').removeClass('page-content-ease-in');
}