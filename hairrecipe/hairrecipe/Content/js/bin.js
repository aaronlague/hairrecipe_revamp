/*
* isohubBIN Isobar BIN Function
* Description : function made for querying the BIN data
* online stores
* prerequesite : jquery
*
*/
window.isohub = window.isohub || {};

(function (app) {
    //Bind onlick function on pageload
    app.Start = function () {
        $(".to-shop-btn").click(function (e) {
            var _this = $(this);
            var SKU = _this.attr("sku");
            var PARENT = $(this).parent();
            app.ShowHideBin(SKU, "", PARENT)
        });
    },
    /*
    Toggles the popup button
    SKU : sku code
    GATAG : gaca
    PLATFORM : Mobile or Desktop
    APPENDOBJ :  element where to append the BIN Popup
    */
    app.ShowHideBin = function (SKU, PLATFORM, APPENDOBJ) {

        //Check if theres an existing popup, but dont know where it is
        if ($(".bin .bin-PopUp").length > 0) {
            //check if theres a popup in your target space
            var targetHasPopUp = APPENDOBJ.find(".bin-PopUp").length;
            //fade all pop-up
            $(".bin-PopUp").fadeOut("fast", function () {
                //remove all popup
                $(".bin .bin-PopUp").remove();
                //no popup in your target space? if yes! pop that shit!!
                if (!targetHasPopUp) {app.ReturnBIN(SKU, PLATFORM, APPENDOBJ);}               
            });
        //No popups pop that BIN
        }else{
            app.ReturnBIN(SKU, PLATFORM, APPENDOBJ);
        }
    },
    /*
    Queries all the needed data for BIN from json file
    SKU : sku code
    GATAG : gaca
    PLATFORM : Mobile or Desktop
    APPENDOBJ :  element where to append the BIN Popup
    */
    app.ReturnBIN = function (SKU, PLATFORM, APPENDOBJ) {
        $.when(
            $.ajax({
                type: 'POST',
                url: "/GetBIN",
                data: { "sSKU": SKU, "platform": PLATFORM },
                cache: false,
                dataType: 'html',
                success: function (data) {
                    
                    APPENDOBJ.append(data)
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(data);
                    console.log(errorThrown);
                }
            })
        ).done(function () {
            $(".bin-PopUp").fadeIn("fast", function () {
                // Animation complete
            });
        })

    }
})(window.isohub.BIN || (window.isohub.BIN = {}));

//start object
isohub.BIN.Start();




