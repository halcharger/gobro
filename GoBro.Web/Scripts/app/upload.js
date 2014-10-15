$(function () {
    configureYoutubeLinkInput();
});

function configureYoutubeLinkInput() {
    $('#YoutubeLink').change(handleYoutubeLinkChange);
}

function handleYoutubeLinkChange() {
    var youtubeId = getYoutubeId($(this).val());
    updateYoutubeThumbnailImg(youtubeId);
    updateHiddenYoutubeIdInput(youtubeId);
}

function updateYoutubeThumbnailImg(youtubeId) {
    $('#youtubeThumbnailImg').attr('src', 'http://img.youtube.com/vi/' + youtubeId + '/0.jpg')
}

function updateHiddenYoutubeIdInput(youtubeId) {
    $('#YoutubeId').val(youtubeId);
}

function getYoutubeId(url) {
    var regExp = /^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|\&v=)([^#\&\?]*).*/;
    var match = url.match(regExp);
    if (match && match[2].length == 11) {
        return match[2];
    } else {
        return '';
    }
}
