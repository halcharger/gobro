$(function () {
    attachConfirmDeleteHandlers();
});

function attachConfirmDeleteHandlers() {
    $('a[name="confirmDeleteLink"]').click(function () {
        var videoId = $(this).attr('data-videoId');
        var username = $(this).attr('data-username');
        $('#confirmDeleteYesButton').attr('onclick', 'deleteVideo("' + videoId + '", "' + username + '")');
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

function deleteVideo(videoId, username) {
    var postUrl = '/' + username + '/delete/' + videoId;
    toastr.options = {positionClass : 'toast-bottom-right'};
    var jxhr = $.post(postUrl)
        .done(function (data) {
            if (data === 'SUCCESS') {
                $('#video_' + videoId).remove();
                toastr.success('Video successfully deleted.', 'SUCCESS');
            }
            else {
                toastr.error('There was an error trying to delete the video: ' + data, 'Delete failed');
            }
        })
        .fail(function (data) {
            toastr.error('Failed sending request to delete video: ' + data);
        })
        .always(function () {
            $('#confirmDeleteModal').modal('hide');
        });
}