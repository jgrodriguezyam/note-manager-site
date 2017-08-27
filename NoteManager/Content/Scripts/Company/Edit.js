$(function () {
    hookEvent();
});

function hookEvent() {
    var form = $("#formEdit");

    form
    .removeData("validator")
    .removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(form);

    form.on("submit", function (event) {
        var $form = $(this);

        var applyAjax = $form.attr("data-apply-ajax");
        if (applyAjax == "False") {
            return true;
        }

        event.stopPropagation();
        event.preventDefault();

        if (!$form.valid()) {
            return false;
        }

        var urlAction = $form.attr("action");
        var hasFileToUpload = $form.attr("enctype") == "multipart/form-data";
        var formData = null;
        waitingDialog.show(saveDialogMessage);

        if (hasFileToUpload) {
            formData = new FormData($form.get(0));

            $.ajax({
                url: urlAction,
                type: "POST",
                data: formData,
                cache: false,
                processData: false,
                contentType: false,
                success: callbackSucccessSavedForm,
                error: callbackErrorSavedForm
            });
        } else {
            formData = $form.serialize();

            $.ajax({
                url: urlAction,
                type: "POST",
                data: formData,
                cache: false,
                dataType: "json",
                success: callbackSucccessSavedForm,
                error: callbackErrorSavedForm
            });
        }
    });
}

function callbackSucccessSavedForm(result) {
    if (result.Result == resultType.Ok) {
        goToCompanyIndex();
        //waitingDialog.hide();
    } else {
        waitingDialog.hide();
    }
}

function goToCompanyIndex() {
    redirect("Company", "Index");
}

function callbackErrorSavedForm() {
    waitingDialog.hide();
}