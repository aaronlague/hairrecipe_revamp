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
            var BINID = _this.attr("BINID");
            var PARENT = $(this).parent();
            app.ShowHideBin(BINID, "", PARENT, _this)
        });
    },
    /*
    Toggles the popup button
    BINID : BINID code
    GATAG : gaca
    PLATFORM : Mobile or Desktop
    APPENDOBJ :  element where to append the BIN Popup
    CALLER : the element triggered the script
    */
    app.ShowHideBin = function (BINID, PLATFORM, APPENDOBJ, CALLER) {

        if (BINID === undefined ) { return false}
        //Check if theres an existing popup, but dont know where it is
        if ($(".bin .bin-PopUp").length > 0) {
            //check if theres a popup in your target space
            var targetHasPopUp = APPENDOBJ.find(".bin-PopUp").length;
            //fade all pop-up
            $(".bin-PopUp").fadeOut("fast", function () {
                //remove all popup
                $(".bin .bin-PopUp").remove();
                //no popup in your target space? if yes! pop that shit!!
                if (!targetHasPopUp) { app.ReturnBIN(BINID, PLATFORM, APPENDOBJ, CALLER); }
            });
        //No popups pop that BIN
        }else{
            app.ReturnBIN(BINID, PLATFORM, APPENDOBJ, CALLER);
        }
    },
    /*
    Queries all the needed data for BIN from json file
    BINID : BINID code
    GATAG : gaca
    PLATFORM : Mobile or Desktop
    APPENDOBJ :  element where to append the BIN Popup
    */
    app.ReturnBIN = function (BINID, PLATFORM, APPENDOBJ, CALLER) {
        $.when(
            $.ajax({
                type: 'POST',
                url: "/GetBIN",
                data: { "binId": BINID, "platform": PLATFORM },
                cache: false,
                dataType: 'html',
                success: function (data) {
                    var dom = $.parseHTML(data);//create dom for the html return
                    //loop the anchors and add the bin contents
                    $(dom).find('.bin-links').each(function (i, obj) {
                        var gaca = CALLER.attr("binbtngaca"); //get bin from the button
                        var eventLabel = CALLER.attr("binEventLabel"); //get the event from the button
                        var store = $(obj).attr("store");// get the store keyword                 
                        //pass parameters and construct the bin script and add it to the anchor
                        $(obj).attr("onlick", isohub.GACA.CreatBINGACA(gaca, store, eventLabel)); 
                    });
                    //add it to the dom
                    APPENDOBJ.append(dom)
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





