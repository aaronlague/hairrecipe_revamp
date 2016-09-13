var hairrecipe = {
    /*
    * showing and hiding the sub header
    * run at page load    
    */
    subHeader: function () {
        var subHdr = $(".product .sub");
        
        $('.product.pop').hover(function () {
            subHdr
                .stop(true, true)
                .animate({
                    height: "toggle",
                    opacity: "toggle"
                }, 100);
        });
    },
    /*
    * holds all function that needs to run on page load
    */
    startup: function (){
        hairrecipe.subHeader();
    }
}


/* run om page load */
hairrecipe.startup();


/*back to top */

if ($('#back-to-top').length) {
    var scrollTrigger = 100, // px
        backToTop = function () {
            var scrollTop = $(window).scrollTop();
            if (scrollTop > scrollTrigger) {
                $('#back-to-top').addClass('show');
            } else {
                $('#back-to-top').removeClass('show');
            }
        };
    backToTop();
    $(window).on('scroll', function () {
        backToTop();
    });
    $('#back-to-top').on('click', function (e) {
        e.preventDefault();
        $('html,body').animate({
            scrollTop: 0
        }, 700);
    });
}

/*Youtube embed Video*/
$('.play_vid').click(function () {
    video = '<iframe class="embed-responsive-item" src="' + $(this).attr('data-video') + '"></iframe>';
    $(this).replaceWith(video);
});


/* scrollto reco_recipe */

$(".scrollto").click(function (event) {
    event.preventDefault();
    var defaultAnchorOffset = 98;
    var anchor = $(this).attr('data-attr-scroll');
    var anchorOffset = $('#' + anchor).attr('data-scroll-offset');
    if (!anchorOffset)
        anchorOffset = defaultAnchorOffset;
    $('html,body').animate({
        scrollTop: $('#' + anchor).offset().top - anchorOffset
    }, 500);
});