$(document).ready(function () {
    console.log(window.location.pathname);
    if (window.location.pathname == "/") {
        $("a[binid^='custom-hawaii-hp']").attr('onclick', 'typeof _gaq != "undefined" && _gaq.push(["_trackEvent", "link", "internal", "pc_hairrepi_20161031_top_hawaii_2"])');
        $("a[binid^='custom-cosme-hp']").attr('onclick', 'typeof _gaq != "undefined" && _gaq.push(["_trackEvent", "link", "external", "pc_hairrepi_20161031_top_present"])');
        $('.main-content a[binid^="custom-apple-ginger-hp"] img').css('width', '100%').unwrap();
    }

    if (window.location.pathname == "/info") {
        $("a[binid^='custom-cosme-hp']").attr('onclick', 'typeof _gaq != "undefined" && _gaq.push(["_trackEvent", "link", "external", "pc_hairrepi_20161107_present"])');
    }

    if ((window.location.pathname == "/") || (window.location.pathname == "/info")) {
        $("a[binid^='custom-cosme-hp']").attr('target', '_blank');
    }
})