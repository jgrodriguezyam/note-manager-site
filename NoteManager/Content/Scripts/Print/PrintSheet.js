$(function () {
    closeWindow();
    openPrint();
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