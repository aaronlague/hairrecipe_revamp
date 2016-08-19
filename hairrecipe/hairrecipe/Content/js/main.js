/*Youtube embed Video*/
$('.play_vid').click(function () {
    video = '<iframe class="embed-responsive-item" src="' + $(this).attr('data-video') + '"></iframe>';
    $(this).replaceWith(video);
});