$(function () {
    closeWindow();
});

function closeWindow() {
    $(document).bind('keydown', function (e) {
        if (e.which == 27) {
            window.close();
        }
    });
}