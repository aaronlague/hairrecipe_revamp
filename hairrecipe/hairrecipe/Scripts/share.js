function openShareWindow(url) {
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
                picture: 'http://i.imgur.com/ZnxbzLg.jpg',
                name: '髪に、ごちそう。',
                caption: '【ヘアレシピ ｜秘密のレシピ公開中 】 ',
                description: '新ブランド、ごちそうシャンプー　ヘアレシピ誕生！<center></center>栄養士× ヘアエキスパート共同開発コンセプト。<center></center>髪に、ごちそうフルコースを召し上がれ。あなたにピッタリなごちそうレシピは？<center></center>http://hairrecipe.jp <center></center> <center></center>ヘアレシピ ',

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

    var url = 'http://twitter.com/share?url=' + encodeURIComponent(pageUrl) + '&text=' + encodeURIComponent(content) + '';

    openShareWindow(url);
}

$(".facebook-share").click(function () {

    shareToFaceboook()
});

$(".twitter-share").click(function () {

    shareToTwitter()
});