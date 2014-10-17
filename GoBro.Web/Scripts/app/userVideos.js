$(function () {
    attachConfirmDeleteHandlers();
});

function attachConfirmDeleteHandlers() {
    $('a[name="confirmDeleteLink"]').click(function () {
        var videoId = $(this).attr('data-videoId');
        confirmDelete(videoId);
    });
}

function confirmDelete(videoId) {
    var videoTitleSelector = '#video_' + videoId + ' div span h4';
    var videoTitle = $(videoTitleSelector).text();
    $('.modal-body p').text(videoTitle);

    var videoImgSelector = '#video_' + videoId + ' div a img';
    var videoImgUrl = $(videoImgSelector).attr('src');
    $('.modal-body img').attr('src', videoImgUrl);

    $('#confirmDeleteModal').modal('show');
}