// Reviews 

// Stage API request configuration
var api_server = "http://stg.api.bazaarvoice.com/data";
// Stage API key
 var api_key = "ndhxusgk9hj9arfay95nsxjd";

// Prod API request configuration
//var api_server = "http://api.bazaarvoice.com/data";
// Prod API key
//var api_key = "dk182v936arkrh2e68gqaucus";


// Refer to http://developer.bazaarvoice.com to find the latest version
var api_version = "5.4";
var num_items = 20;
var form = $("#rrform");
var validator;
var mode = "";
var reviewmode = false;

$(document).ready(function () {

    // Allow for API results to be cached
    $.ajaxSetup({ cache: true });

    form.attr("action", api_server + "/submitreview.json?");

    $('input[name = "passkey"]').val(api_key);

    var productSKU = $(".rr-section").attr("data-sku")

    mode = $(".rr-section").attr("data-mode")

    // Overall review parameters
    $(".bvOverallRating").bvOverallRatingWidget({ bvproductID: productSKU, bvTemplate: 'overall_rating_template' });

    // Initialize Rating Widget
    $(".rating_selector").bvRatingSelectorWidget();

    var underage = getCookie("underage");

    if (underage) {
        $('.write-review').attr('data-target', '#rnrw_age_error_modal');
        // redirect to homepage
        var myTvar = setInterval(function () { window.location.replace("/index.html"); clearInterval(myTvar); }, 4000);
    }

    // Display Ratings and Reviews
    $(".read-review").click(function () {

        var productSKU = $(this).attr("data-sku");
        var productID = $(this).attr("data-pid");
        var productLine = $(this).attr("data-line");

        var icon = "/Content/images/" + mode + "/product/" + productLine + "/" + productLine + "-" + productID + "-rnr.png";
        $(".modal-header-image").css('background-image', "url(" + icon + ")");

        var productName = $("#" + productID + " .jp-title-1").html()
            + $("#" + productID + " .jp-title-2").html()
            + " " + $("#" + productID + " .size").html();

        $(".modal-title").html(productName);
 
        // Overall review parameters
        $(".bvOverallRatingPopup").bvOverallRatingWidget({ bvproductID: productSKU, bvTemplate: 'overall_rating_popup_template' });

        $("#reviews").bvDisplayRatingReviewWidget({ bvproductID: productSKU, bvTemplate: 'read_review_template' });

    });

    // Display Submission form
    $(".write-review").click(function (e) {
	
		$("#rnrw_modal").show();
		var scrollTop = $(window).scrollTop();
		$("#rnrw_modal").css("top", scrollTop );		
		
		

        var productSKU = $(this).attr("data-sku");
        var productID = $(this).attr("data-pid");
        var productLine = $(this).attr("data-line");

        var icon = "/Content/images/" + mode + "/product/" + productLine + "/" + productLine + "-" + productID + "-rnr.png";
        $(".modal-header-image").css('background-image', "url(" + icon + ")");

        var productName = $("#" + productID + " .jp-title-1").html()
            + $("#" + productID + " .jp-title-2").html()
            + " " + $("#" + productID + " .size").html();

        $(".modal-title").html(productName);


        $("input[name='productid']").val(productSKU);

    });
	
	$(".close").click(function () {
		$("#rnrw_modal").hide();
    });

    /* Compute remaining character count */
    $("#usernickname, #title, #reviewtext, #useremail").keydown(function () {
        var val = $(this).val();
        var remain = $(this).siblings(".character-limit").html = $(this).attr("maxlength") - val.length;
        $(this).siblings(".character-limit").html(remain);
    });




    /* Validate the form */

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
            required: "ーザー名を入力して下さい。※5文字以上25文字以内［全角英数字のみ］",
            minlength: "※ユーザー名は5〜25文字以内で入力して下さい",
            loginRegex: "ユーザー名に使用できるのは全角英数字のみです"
        }
    });

    // Form Submission
    $("#btnSubmit").click(function () {
        if (form.valid()) {
            var year = $("#birthYear").val();
            var month = $("#birthMonth").val();
            var age = calculateAge(year, month);

            if (age < 20) {
                $('#rnrw_modal').modal('hide');
                $('#rnrw_age_error_modal').modal('show');

                //create a cookie to track underage user
                setCookie("underage", true, 1);

                // redirect to homepage
                var myTvar = setInterval(function () { window.location.replace("/index.html"); clearInterval(myTvar); }, 4000);
            }
            else {
                $.ajax({
                    type: form.attr('method'),
                    url: form.attr('action'),
                    data: form.serialize()
                }).done(function (result) {
                    $('#rnrw_modal').modal('hide');
                    $('#rnrw_success_modal').modal('show');

                }).fail(function () {
                    // Optionally alert the user of an error here...
                });
            }
        }
        else {
            if (!$(".pseudo-checkbox").hasClass("checked")) {
                $(".pseudo-checkbox").addClass("error");
            }
        }

    });


    // When write review modal is closed, reset the form
    $('#rnrw_modal').on('hide.bs.modal', function () {
        resetForm();
    });


    $("#useremail").change(function () {
        $("input[name='HostedAuthentication_AuthenticationEmail']").val($(this).val());
    });

    // custom checkbox
    $(".pseudo-checkbox").click(function () {
        var cbID = $(this).attr("data-id");
        $(this).removeClass("error");
        if ($(this).hasClass("checked")) {
            $(this).removeClass("checked");
            $("#" + cbID).prop("checked", false);
        }
        else {
            $(this).addClass("checked");
            $("#" + cbID).prop("checked", true);
            $("#terms-error").hide();
        }
    });

});

(function () {
    // Truncate a string on word boundaries rather than character boundries. 
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

    this.calculateAge = function calculateAge(year, month) {
        var dateString = year + "/" + month + "/" + "1";
        var today = new Date();
        var birthDate = new Date(dateString);
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        return age;
    };

    this.setCookie = function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + "; " + expires;
    };

    this.getCookie = function getCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    };

    this.resetForm = function resetForm(cname, cvalue, exdays) {
        validator.resetForm();
        form[0].reset();
        $(".rating_selector").attr("value", "");
        $(".br-widget a").removeClass("star-on");
        $(".br-widget a").addClass("star-off");
        $(".pseudo-checkbox").removeClass("error");

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
			    //console.log(json)
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
			        //var output = _.template(document.getElementById(options.bvTemplate + '_empty').innerHTML, json);
			        //$(selector).children().remove();
			        //$(selector).append(output);
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
		        console.log(reviewmode);
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


