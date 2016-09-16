$(document).ready(function(){


	$(".readReview").colorbox({
	    inline:true, scrolling: false, width:"900px", height:"980px", arrowKey:false,
	    onComplete: function () {
	        $("#cboxContent").append('<button type="button" id="cboxClose2" onclick="$.colorbox.close()">close</button>');



	    }
	});


	$(".writeReview").colorbox({
	    inline: true, scrolling: false, width: "900px", height: "1440px", arrowKey: false,
	    onComplete: function () {

	        //Check if browser is IE or not
	        if (navigator.userAgent.search("MSIE") >= 0) {
	            $(".popups#write").css("height", 1380);
	        }
	        else {

	            h = 1380;
	            $.colorbox.resize({ 'height': h });
	        }



	    }
	});


	$(document).bind('cbox_closed', function () {
	    $("#cboxClose2").remove();
	    document.getElementById("form1").reset();
	    $("#form1 #visible_fields input, #form1 #visible_fields textarea").removeAttr("disabled");
	    $("#form1 #visible_fields input, #form1 #visible_fields textarea").removeAttr("value");
	    $(".br-widget a").removeClass("star-on").addClass("star-off");
	});



});
	