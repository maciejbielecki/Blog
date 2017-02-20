$(document).ready(function () {
    $(window).scroll(function () {
        var top = $(window).scrollTop();
        var find_class_small = $.contains('#nav', '.small');

        if (top > 300 && find_class_small == false) {
            $('#nav').addClass('small');
        }
        else {
            $('#nav').removeClass('small');
        }

    });
});