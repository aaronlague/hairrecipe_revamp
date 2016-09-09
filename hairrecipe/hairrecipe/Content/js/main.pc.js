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
    * Scrolls user up upon clicking the button to top
    * Binds on pagelaod
    */
    BackToTop: function (){
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
    },
    /*
    *Youtube embed Video
    */
    PlayVideo: function () {
        console.log("bind");
        $('.play_vid').click(function () {
            console.log("execute");
            video = '<iframe class="embed-responsive-item" src="' + $(this).attr('data-video') + '"></iframe>';
            $(this).replaceWith(video);
        });
    },
    /*
    * holds all function that needs to run on page load
    */
    startup: function () {
        
        hairrecipe.subHeader();
        hairrecipe.BackToTop();
        hairrecipe.PlayVideo();
    }
}


/* run om page load */
hairrecipe.startup();



$('.play_vid').click(function () {
    console.log("execute");
    video = '<iframe class="embed-responsive-item" src="' + $(this).attr('data-video') + '"></iframe>';
    $(this).replaceWith(video);
});