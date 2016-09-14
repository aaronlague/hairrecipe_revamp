function openShareWindow(url) {
    var w = 602;
    var h = 369;
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);

    return window.open(url, 'feedDialog', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}

function shareToFacebook(d) {
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

function shareToFacebookResults(d) {

    fbDetails = {
        picture: baseUrl + 'content/images/sp/diagnosis/results/OGP_diagnosis.png',
        name: '',
        caption: '',
        description: 'あなたの髪、うるおっている？髪のジューシー度をチェックすると結果に応じて、あなたの髪にピッタリな“レシピ”を提案！今すぐチェック！',

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
        description: '髪に、ごちそう。【新ブランド、ごちそうシャンプー　ヘアレシピ誕生！】 栄養士×ヘアエキスパート共同開発コンセプト。髪に、ごちそうフルコースを召し上がれ。あなたにピッタリな髪のごちそうレシピは？ http://hairrecipe.jp'
    }

    var pageUrl = 'http://' + window.location.href;
    var content = twDetails.description;
    
    var url = 'http://twitter.com/share?url=' + encodeURIComponent(".  ") + '&text=' + encodeURIComponent(content) + '';

    openShareWindow(url);
}

function shareToTwitterResults(d) {

    twDetails = {
        description: 'あなたの髪、うるおっている？髪のジューシー度をチェックすると結果に応じて、あなたの髪にピッタリな“レシピ”を提案！今すぐチェック！ヘアレシピ ｜http://hairrecipe.jp/diagnosis/index.html'
    }

    var pageUrl = 'http://' + window.location.href;
    var content = twDetails.description;

    var url = 'http://twitter.com/share?url=' + encodeURIComponent(".  ") + '&text=' + encodeURIComponent(content) + '';

    openShareWindow(url);
}


$(".facebook-share").click(function () {

    shareToFacebook()
});

$(".sns-cols.results .facebook-share").click(function () {
    shareToFacebookResults();
});

$(".twitter-share").click(function () {

    shareToTwitter()
});

$(".sns-cols.results .twitter-share").click(function () {
    shareToTwitterResults();
});

$(".line-share").click(function () {
    var text = "髪に、ごちそう。【新ブランド、ごちそうシャンプー　ヘアレシピ誕生！】 栄養士×ヘアエキスパート共同開発コンセプト。髪に、ごちそうフルコースを召し上がれ。あなたにピッタリな髪のごちそうレシピは？";

    location.href = "http://line.me/R/msg/text/?" + text;

});

$(".line-share").click(function () {
    var text = "髪に、ごちそう。【新ブランド、ごちそうシャンプー　ヘアレシピ誕生！】 栄養士×ヘアエキスパート共同開発コンセプト。髪に、ごちそうフルコースを召し上がれ。あなたにピッタリな髪のごちそうレシピは？";

    location.href = "http://line.me/R/msg/text/?" + text;

});

$(".sns-cols.results .line-share").click(function () {
    var text = "あなたの髪、うるおっている？髪のジューシー度をチェックすると結果に応じて、あなたの髪にピッタリな“レシピ”を提案！今すぐチェック！";

    location.href = "http://line.me/R/msg/text/?" + text;
});
