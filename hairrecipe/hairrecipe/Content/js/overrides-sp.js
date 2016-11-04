$(document).ready(function () {
    console.log(window.location.pathname);
    $('.navbar-toggle.nav-burger').click(function () {
        $(this).addClass('hide-opacity');
        $(this).removeClass('show-opacity');
    });

    $('.navbar-toggle.nav-close').click(function () {
        $('.navbar-toggle.nav-burger').removeClass('hide-opacity');
        $('.navbar-toggle.nav-burger').addClass('show-opacity');
    });

    $('.navbar-toggle.nav-slide-right').click(function () {
        $('.navbar-toggle.nav-burger').css('display', 'block');
        $('.navbar-toggle.nav-burger').addClass('show-opacity');
    });

    if (window.location.pathname == "/sp/info") {
        var customImgAlt = $("a[binid^='custom-hawaii-hp']").find('img');
        customImgAlt.attr('alt', 'ヘアレシピ ビューティーキャンプ');
    }

    if ((window.location.pathname == "/sp") || (window.location.pathname == "/sp/info")) {
        $("a[binid^='custom-cosme-hp']").attr('target', '_blank');
    }
})