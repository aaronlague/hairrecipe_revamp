﻿function openShareWindow(url) {
    var w = 602;
    var h = 369;
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);

    return window.open(url, 'feedDialog', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}

function shareToFaceboook(d) {
    var baseUrl = "http://" + window.location.host;
    var fbAppId = 1466029163666184;
    var targetUrl = '';

    fbDetails = {
                picture: baseUrl + '/Content/images/sp/OGP.png',
                name: '',
                caption: '',
                description: '髪に、ごちそう。【新ブランド、ごちそうシャンプー　ヘアレシピ誕生！】 栄養士×ヘアエキスパート共同開発コンセプト。髪に、ごちそうフルコースを召し上がれ。あなたにピッタリな髪のごちそうレシピは？ ',

            }

    var url = 'https://www.facebook.com/dialog/feed?app_id=' + fbAppId +
			'&link=' + encodeURIComponent(targetUrl) +
			'&picture=' + encodeURIComponent(fbDetails.picture) +
			'&name=' + encodeURIComponent(fbDetails.name) +
			'&caption=' + encodeURIComponent(fbDetails.caption) +
			'&description=' + encodeURIComponent(fbDetails.description) +
			'&redirect_uri=' + encodeURIComponent(baseUrl + '/FbPopupClose/Index') +
			'&display=popup';

    openShareWindow(url);
}

function shareToTwitter(d) {

    twDetails = {
        description: '髪に、ごちそう。【新ブランド、ごちそうシャンプー　ヘアレシピ誕生！】 栄養士×ヘアエキスパート共同開発コンセプト。髪に、ごちそうフルコースを召し上がれ。あなたにピッタリな髪のごちそうレシピは？ http://hairrecipe.jp  ',
    }
    var pageUrl = 'http://' + window.location.href;
    var content = twDetails.description;

    var url = 'http://twitter.com/share?url=' + encodeURIComponent(".  ") + '&text=' + encodeURIComponent(content) + '';

    openShareWindow(url);
}

$.ajax({
    url: "//media.line.me/js/line-button.js",
    dataType: "script",
    success: function () {
        console.log("script loaded");
        setTimeout(function () {
            $('.line-btn span a img').addClass('test');
            $('.line-btn span a img.test').attr('src', '/Content/images/sp/sp_footer-social-line.png');
            $('.line-btn span a img.test').attr('width', '');
            $('.line-btn span a img.test').attr('height', '');
        }, 3000);
    }
});

$(".facebook-share").click(function () {

    shareToFaceboook()
});

$(".twitter-share").click(function () {

    shareToTwitter()
});