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

        $("a[binid^='custom-cosme-hp']").attr('href', 'https://www.myrepi.com/tag/hair-recipe-mint-rr-1610');
        $("a[binid^='custom-cosme-hp']").attr('onclick', 'typeof _gaq != "undefined" && _gaq.push(["_trackEvent", "link", "external", "sp_hairrepi_20161107_present"])');

        $('.info-content a[binid^="custom-apple-ginger-hp"] img').css('width', '100%').unwrap();
        
        
        $("a[binid^='custom-info-bin']").attr('binbtngaca', '[platform]_hairrepi_20150618_news_[store]');
    }

    if ((window.location.pathname == "/sp") || (window.location.pathname == "/sp/info")) {
        $("a[binid^='custom-cosme-hp']").attr('target', '_blank');
        $("a[binid^='custom-info-bin']").attr('href', 'javascript:void(0)');
    }
})