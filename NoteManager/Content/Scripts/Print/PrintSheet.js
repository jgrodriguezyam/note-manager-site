$(function () {
    closeWindow();
    openPrint();
    openPrintEnter();
});

function closeWindow() {
    $(document).bind('keydown', function (e) {
        if (e.which == 27) {
            window.close();
        }
    });
}

function openPrint() {
    $("#OpenPrint").click(function () {
        $("#TablePrint").hide();
        window.print();
    });
}

function openPrintEnter() {
    $(document).bind('keydown', function (e) {
        if (e.which == 13) {
            $("#TablePrint").hide();
            window.print();
        }
    });
}