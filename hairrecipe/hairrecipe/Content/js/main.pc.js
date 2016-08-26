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
