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

    */
    app.AlterElement = function () {
        $('.gaca-btn').each(function (i, obj) {            
            var GACA = $(obj).attr("gaca");
            var EVENTLABEL = $(obj).attr("eventlabel");
            EVENTLABEL = (typeof EVENTLABEL !== 'undefined') ? EVENTLABEL : 'internal';
            $(obj).removeAttr("gaca");
            $(obj).removeAttr("eventlabel");
            $(obj).attr("onlick", "typeof _gaq != 'undefined' && _gaq.push(['_trackEvent', 'link', '" + EVENTLABEL + "', '" + GACA + "'])");
        });
    },
    app.AddBINOnClick = function (dom) {
        
    },
    app.SetUp = function () {
        //no script
    }

})(window.isohub.GACA || (window.isohub.GACA = {}));

//start object
isohub.GACA.Start();




