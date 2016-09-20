// Reviews 

// Stage API request configuration
// var api_server = "http://stg.api.bazaarvoice.com/data";
// Stage API key
// var api_key = "ndhxusgk9hj9arfay95nsxjd";

// Prod API request configuration
var api_server = "http://api.bazaarvoice.com/data";
// Prod API key
var api_key = "dk182v936arkrh2e68gqaucus";


// Refer to http://developer.bazaarvoice.com to find the latest version
var api_version = "5.4";
var num_items = 20;
var form = $("#form1");
var validator;
var reviewmode = false;

$(document).ready(function () {

    // Allow for API results to be cached
    $.ajaxSetup({ cache: true });

    var productSKU = $(".rr-section").attr("data-sku")

    // Overall review parameters
    $(".bvOverallRating").bvOverallRatingWidget({ bvproductID: productSKU, bvTemplate: 'overall_rating_template' });


    // Initialize Rating Widget
    $(".rating_selector").bvRatingSelectorWidget();


    // Display Ratings and Reviews
    $(".read-review").click(function () {

        productSKU = $(this).attr("data-sku");
        productID = $(this).attr("data-pid");
        productLine = $(this).attr("data-line");

        icon = "/Content/images/pc/product/" + productLine + "/" + productLine + "-" + productID + "-rnr.png";

        // Overall review parameters
        $(".bvOverallRatingPopup").bvOverallRatingWidget({ bvproductID: productSKU, bvTemplate: 'overall_rating_popup_template' });

        $("#reviews").bvDisplayRatingReviewWidget({ bvproductID: productSKU, bvTemplate: 'read_review_template' });

        $(".modal-header-image").css('background-image', "url(" + icon + ")");
        

       

        //if ($("body").attr("id") == "booster") {
        //    var course = $(this).attr("data-course");
        //} else {
        //    var course = $(this).parent().attr("data-course");
        //    var dataItem = $(this).parent().attr("data-review-item");
        //}
        
        //var productName = $("#" + course + " .productNameImg").attr("alt");
        var productName = $("#" + productID + " .main-details .jp-title-1").html()
            + $("#" + productID + " .main-details .jp-title-2").html()
            + $("#" + productID + " .main-details .size").html();

        $(".modal-title").html(productName);

        //if ((dataItem != "refill")) {
        //    productName = productName.replace(/[0-9l]+ml/, "");
        //    productName = productName.replace(/[0-9l]+\g/, "");
        //    $(".productName").text(productName);
        //} else {
        //    var trimmedProductName = productName.split('ml')[0]
            
        //    $(".productName").text(trimmedProductName + "ml");

        //}

        //$(".reviewSKU").attr("src", "/images/pc/common/review-" + icon + "-" + course + ".png").addClass(icon);
    });

    // Display Submission form
    $(".writeReview").click(function () {
        reviewmode = false;
        form.show();
        productID = $(this).attr("rel");
        $("input[name='productid']").val(productID);

        var icon = $(this).parent().attr("data-icon");
        var course = $(this).parent().attr("data-course");
        var dataItem = $(this).parent().attr("data-review-item");
        var productName = $("#" + course + " .productNameImg").attr("alt");

        if ((dataItem != "refill")) {
            productName = productName.replace(/[0-9l]+ml/, "");
            productName = productName.replace(/[0-9l]+\g/, "");
            $(".productName").text(productName);
        } else {
            var trimmedProductName = productName.split('ml')[0]
            //alert(trimmedProductName);
            $(".productName").text(trimmedProductName + "ml");
        }

        $(".reviewSKU").attr("src", "/images/pc/common/review-" + icon + "-" + course + ".png").addClass(icon);

    });

    // Validate the form

    validator = form.validate();

    // Extend validation - Alphanumeric
    $.validator.addMethod("loginRegex", function (value, element) {
        return this.optional(element) || /^[a-z0-9]+$/i.test(value);
    }, "Nickname must contain only letters, numbers, or dashes.");

    // Nickname validation rules
    $("#usernickname").rules("add", {
        loginRegex: true,
        required: true,
        minlength: 5,
        maxlength: 25,
        messages: {
            required: "※ユーザー名は5〜25文字以内で入力して下さい",
            minlength: "※ユーザー名は5〜25文字以内で入力して下さい",
            loginRegex: "ユーザー名に使用できるのは全角英数字のみです"
        }
    });

    // Form Submission
    $("#btnSubmit").click(function () {
        if (form.valid()) {
            $("#form1 input, #form1 textarea").removeAttr("disabled");
            $.ajax({
                type: form.attr('method'),
                url: form.attr('action'),
                data: form.serialize()
            }).done(function (result) {
                // Optionally alert the user of success here...
                form[0].reset();
                $(".result").hide();
                $("#cboxClose").hide();
                $(".formfields").hide();
                $(".reviewSKU, .productName").hide();

                $(".popups#write").addClass("successful");

                $.colorbox.resize({ 'height': 320 });

                $(".success").show();
                //$("html, body").delay(500).animate({ scrollTop: 0 }, 500);
                //console.log(result);
            }).fail(function () {
                // Optionally alert the user of an error here...
            });
        }
    });

    $("#btnConfirm").click(function () {
        if (form.valid()) {
            reviewmode = true;
            $(".formbutton, #required").hide();
            $(".result, #reviewmessage").show();
            $("#form1 #visible_fields input, #form1 #visible_fields textarea").attr("disabled", "disabled");
        }
        //$("html, body").delay(500).animate({ scrollTop: 0 }, 500);
    });

    $("#btnBack").click(function () {
        reviewmode = false;
        $(".formbutton, #required").show();
        $(".result, #reviewmessage").hide();
        $("#form1 #visible_fields input, #form1 #visible_fields textarea").removeAttr("disabled");
        // $("html, body").delay(500).animate({ scrollTop: 0 }, 500);
    });


    // Close the read review popup
    $("#cboxClose").click(function () {
        reviewmode = false;
        validator.resetForm();
    });


    // Close the write review form popup
    $("#btnCloseReview").click(function () {

        $(".popups#write").removeClass("successful");

        //Check if browser is IE or not
        if (navigator.userAgent.search("MSIE") >= 0) {
            $(".popups#write").css("height", 1380);
        }
        else {
            h = 1380;
            $.colorbox.resize({ 'height': h });
        }

        document.getElementById("form1").reset();
        $("#form1 #visible_fields input, #form1 #visible_fields textarea").removeAttr("disabled");
        $("#form1 #visible_fields input, #form1 #visible_fields textarea").removeAttr("value");
        $(".br-widget a").removeClass("star-on").addClass("star-off");


        $("#cboxClose").show();
        $(".productName, .reviewSKU").show();
        $(".formfields").show();
        $(".success").hide();
        $(".result, #reviewmessage").hide();
        $(".formbutton").show();

        $.colorbox.close();


    });

    $("#useremail").change(function () {
        $("input[name='HostedAuthentication_AuthenticationEmail']").val($(this).val());
    });

    // Close the form popup
    //$("#btnConfirm").click(function () {
    //    $("#isRecommended").text("[ " + $("[type='radio']:checked").next().text() + " ]");
    //    $("#input_nickname .value").text($("#usernickname").val());
    //    $("#input_title .value").text($("#title").val());
    //    $("#input_review .value").text($("#reviewtext").val());
    //});

});


// Truncate a string on word boundaries rather than character boundries. 
// Dustin Mihalik
(function(){
  this.truncate = function truncate(str, length) {
	  var trunc = str;
	  if (trunc && trunc.length > length) {
		  /* Truncate the content of the P, then go back to the end of the previous word. */
		  trunc = trunc.substring(0, length);
		  trunc = trunc.replace(/\w+$/, '');
		  return trunc + "...";
	  } else {
		  return trunc;
	  }
  };
  
  // Date Format
  this.formatDate = function formatDate(str) {
	var fdate = str;
	var myarr = fdate.split("T");
	return myarr[0].replace(/-/g, ".");
  };  
})();


// Bazaarvoice widgets
(function($) {
	// Overall Rating
    $.fn.bvOverallRatingWidget = function (options) {
        var defaults = {
			bvTemplate:"",
			bvproductID:""
        };
        var options = $.extend(defaults, options);
        var bvParam = "passkey=" + api_key + "&apiversion=" + api_version + "&filter=ProductId:" + options.bvproductID + "&stats=NativeReviews";

        return this.each(function () {
            var selector = $(this);
			var jqxhr = $.getJSON( api_server + "/statistics.json?callback=?", bvParam,
			function (json) {
			    console.log(json)
				// Render the template into a variable
			    var output = _.template(document.getElementById(options.bvTemplate).innerHTML, json);
			    $(selector).children().remove();
				$(selector).append(output);
			});
        });	
	}
	
	// Ratings and Reviews
    $.fn.bvDisplayRatingReviewWidget = function (options) {
        var defaults = {
			bvTemplate:"",
			bvproductID:""
        };
        var options = $.extend(defaults, options);
        //var bvParam = "passkey=" + api_key + "&apiversion=" + api_version + "&filter=DisplayLocale:ja_JP&filter=ProductId:" + options.bvproductID;// + "&Limit="+num_items + "&filter=SecondaryRating_Recommendation:gte:1";
        var bvParam = "passkey=" + api_key + "&apiversion=" + api_version + "&filter=ProductId:" + options.bvproductID;// + "&Limit="+num_items + "&filter=SecondaryRating_Recommendation:gte:1";
        return this.each(function() {
            var selector = $(this);
			var jqxhr = $.getJSON( api_server + "/reviews.json?callback=?", bvParam,
			function(json){
			    // Render the template into a variable
			    if (json.TotalResults != 0) {
			        var output = _.template(document.getElementById(options.bvTemplate).innerHTML, json);
			        $(selector).children().remove();
			        $(selector).append(output);
			    }
			    else {
			        var output = _.template(document.getElementById(options.bvTemplate + '_empty').innerHTML, json);
			        $(selector).children().remove();
			        $(selector).append(output);
			    }
			});				
        });
	}
	
	
	// Rating Selector Widget
    $.fn.bvRatingSelectorWidget = function(options) { 
        var defaults = {
			bvTemplate:"",
			bvproductID:""
        };
        var options = $.extend(defaults, options);
		var selector = $(this); 
		
		// Create Rating Widget
		var widget = "<div class='br-widget'>";
		widget += "<a href='javascript:void(0);' data-rating-value='1' data-rating-text='よくない' class='star-off'><span></span></a>";
		widget += "<a href='javascript:void(0);' data-rating-value='2' data-rating-text='まあまあ' class='star-off'><span></span></a>";
		widget += "<a href='javascript:void(0);' data-rating-value='3' data-rating-text='平均' class='star-off'><span></span></a>";
		widget += "<a href='javascript:void(0);' data-rating-value='4' data-rating-text='良い' class='star-off'><span></span></a>";
		widget += "<a href='javascript:void(0);' data-rating-value='5' data-rating-text='非常に良い' class='star-off'><span></span></a>";
		widget += "</div>";
		selector.parent().append(widget);


		selector.siblings().find('a').mouseover(function () {
		    if (reviewmode == false) {
		        var currSelected = $(this);
		        var rating = currSelected.attr('data-rating-value');
		        currSelected.parent().find('a').each(function () {
		            if ($(this).attr('data-rating-value') <= rating) {
		                $(this).removeClass('star-off');
		                $(this).addClass('star-on');
		            }
		            else {
		                $(this).removeClass('star-on');
		                $(this).addClass('star-off');
		            }
		        });
		    }
		});

		selector.siblings().find('a').click(function () {
		    if (reviewmode == false) {
		        var rating = $(this).attr('data-rating-value');
		        var txt = $(this).attr('data-rating-text');
		        var currSelected = $(this);
		        currSelected.parent().siblings('input').attr('value', rating);
		        currSelected.parents(".ratings").find('label').hide();
		        currSelected.parents(".ratings").find('.rate').text(txt);

		        $("#result_" + currSelected.parents(".ratings").attr('name')).width(rating * 28);

		        currSelected.parent().find('a').each(function () {
		            if ($(this).attr('data-rating-value') <= rating) {
		                $(this).removeClass('star-off');
		                $(this).addClass('star-on');
		            }
		            else {
		                $(this).removeClass('star-on');
		                $(this).addClass('star-off');
		            }
		        });
		    }
		});

		selector.parent().mouseout(function () {
		    if (reviewmode == false) {
		        var currSelected = $(this);
		        var rating = currSelected.find('input').attr('value');
		        if (!rating) {
		            currSelected.find('a').removeClass('star-on');
		            currSelected.find('a').addClass('star-off');
		        }
		        else {
		            currSelected.find('a').each(function () {
		                if ($(this).attr('data-rating-value') <= rating) {
		                    $(this).removeClass('star-off');
		                    $(this).addClass('star-on');
		                }
		                else {
		                    $(this).removeClass('star-on');
		                    $(this).addClass('star-off');
		                }
		            });
		        }
		    }
		});
	}	
})(jQuery);


