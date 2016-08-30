/*
* isohubBIN Isobar BIN Function
* Description : function made for querying the BIN data
* online stores
* prerequesite : jquery
*
*/
window.isohub = window.isohub || {};

(function (app) {
    app.ShowHideBin = function (SKU, GATAG, PLATFORM, APPENDOBJ) {
        if ($(".bin .bin-PopUp").length > 0) {
            console.log("has");
            $(".bin-PopUp").fadeOut("fast", function () {
                $(".bin .bin-PopUp").remove();
            });
        }else{
            this.ReturnBIN(SKU, GATAG, PLATFORM, APPENDOBJ);
        }
    },
    /*
    SKU : sku code
    GATAG : gaca
    PLATFORM : Mobile or Desktop
    APPENDOBJ :  element where to append the BIN Popup
    */
    app.ReturnBIN = function (SKU, GATAG, PLATFORM, APPENDOBJ) {
        console.log("request bin");
        $.when(
            $.ajax({
                type: 'POST',
                url: "/GetBIN",
                data: { "sSKU": SKU, "gaca": GATAG },
                cache: false,
                dataType: 'html',
                success: function (data) {
                    APPENDOBJ.append(data)
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            })
        ).done(function () {
            $(".bin-PopUp").fadeIn("slow", function () {
                // Animation complete
            });
        })

    }
})(window.isohub.BIN || (window.isohub.BIN = {}));




