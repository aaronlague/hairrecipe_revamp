/*
* isohubBIN Isobar GACA Function
* Description : function made for querying the BIN data
* online stores
* prerequesite : jquery
*
*/
window.isohub = window.isohub || {};

(function (app) {
    //Bind onlick function on pageload
    app.Start = function () {
        app.AlterElement();
    },
    /*
      Fires the google analytics by passing the attribute
    */
    app.BindOnClick = function () {
        $(".gaca-btn").click(function (e) {
            var _this = $(this);
            var GACA = _this.attr("gaca");
            var EVENTLABEL = _this.attr("eventlabel");
            app.Execute(GACA);            
        });
    },
    /*
      Fires the google analytics by passing the attribute
    */
    app.Execute = function (GACode, EventLabel) {
        if (typeof GACode === 'undefined') { return false }
        EventLabel = (typeof EventLabel !== 'undefined') ? EventLabel : 'internal';
        typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', EventLabel, GACode]);
    },
    /*
        Alters all the element that has .gaca-btn class on page load
        Loops all that dom, get the attribute and use it to construct a new onclick event
    */
    app.AlterElement = function () {
        $('.gaca-btn').each(function (i, obj) {
            var GACA = $(obj).attr("gaca");
            if (typeof GACA === 'undefined' || GACA === null) {
                console.log('gaca undefined');
                return null;
            }
            var EVENTLABEL = $(obj).attr("eventlabel");
            EVENTLABEL = (typeof EVENTLABEL !== 'undefined') ? EVENTLABEL : 'internal';
            $(obj).removeAttr("gaca");
            $(obj).removeAttr("eventlabel");
            $(obj).attr("onlick", "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', '" + EVENTLABEL + "', '" + GACA.replace("[platform]", isohub.helper.ReturnPlatformKeyword()) + "'])");
        });
    },
    /*
        customized function made only for diagnosis
        Loops all that dom, get the attribute and use it to construct a new onclick event
    */
    app.DiagnosisAlterElement = function () {        
        var pageKeyword = $("#pageKey").val();
        var GACABase = "[platform]_hairrepi_20161001_".replace("[platform]", isohub.helper.ReturnPlatformKeyword());
        //question block
        $('.choices a').each(function (i, obj) {
            var letterKey = $(obj).find(".title").html();
            GACA = GACABase + pageKeyword + "_" + letterKey.toLowerCase();
            $(obj).attr("onlick", "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', 'internal', '" + GACA + "'])");
        });
        //return link
        var keyInt = pageKeyword.substr(11, 1);
        var returnKeyword = (parseInt(keyInt - 1) < 1 ? "top" : "q" + parseInt(keyInt - 1));
        var GACABaseTop = GACABase + pageKeyword + "_" + returnKeyword;
        $(".desc a").attr("onlick", "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', 'internal', '" + GACABaseTop + "'])");

        //results Block
        $('.content-block .bin .gaca-btn, .results-page-bottom .bin .gaca-btn').each(function (i, obj) {
            GACA = GACABase + pageKeyword + "_" + "bin_" + parseInt(i + 1);
            $(obj).attr("onlick", "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', 'internal', '" + GACA + "'])");
        });
        //result SNS
        $(".results-sns .twitter-share").attr("onlick", "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', 'internal', '" + GACABase + pageKeyword + "_twitter'])");
        $(".results-sns .facebook-share").attr("onlick", "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', 'internal', '" + GACABase + pageKeyword + "_facebook'])");
        $(".results-sns .line-share").attr("onlick", "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', 'internal', '" + GACABase + pageKeyword + "_line'])");

    },
    /*
        Create the BIN script for BIN's individual store
        GACA :  GA code
        StoreKeyword : store keyword ex. amazon, lohaco, etc.
        EventLabel : optional* will be set to internal if null
    */
    app.CreatBINGACA = function (GACA, StoreKeyword, EventLabel)
    {
        if (typeof GACA === 'undefined' || GACA === null) {
            console.log('gaca undefined');
            return null;
        }
        EventLabel = (typeof EventLabel !== 'undefined') ? EventLabel : 'internal';       
        var newgaca = GACA.replace("[store]", StoreKeyword).replace("[platform]", isohub.helper.ReturnPlatformKeyword());
        return "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', '" + EventLabel + "', '" + newgaca + "']);";
    },
    app.SetUp = function () {
        //no script
    }

})(window.isohub.GACA || (window.isohub.GACA = {}));

//start object
isohub.GACA.Start();




