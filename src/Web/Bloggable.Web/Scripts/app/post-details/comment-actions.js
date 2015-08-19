var Bloggable = Bloggable || {};

Bloggable.CommentActions = (function () {
    var onCreateCommentSuccess = function (data) {
        throw new Error('Not implemented');
    };

    var onCreateCommentFailure = function (jqXHR) {
        var response = Bloggable.Helpers.ErrorResponseParser.parse(jqXHR);

        var failureMessageContainer = $(this).find('.general-error-message-container');
        failureMessageContainer.html(response.errorMessage || 'An error has occured. Please try again later...').removeClass('hidden');
    };

    var onUpdateCommentFormLoaded = function (data) {
        var formId = $(data).find('form').prop('id');
        Bloggable.Helpers.FormValidation.reAttach('#' + formId);
    };

    var onUpdateCommentFormLoadFailure = function(jqXHR) {
        var response = Bloggable.Helpers.ErrorResponseParser.parse(jqXHR);
        Bloggable.Alerts.error(response.errorMessage || 'An error has occured. Please try again later...');
    }

    var onUpdateCommentSuccess = function () {
        Bloggable.Alerts.success('Comment successfully updated!');
    };

    var onUpdateCommentFailure = function (jqXHR) {
        var response = Bloggable.Helpers.ErrorResponseParser.parse(jqXHR);

        var failureMessageContainer = $(this).find('.general-error-message-container');
        failureMessageContainer.html(response.errorMessage || 'An error has occured. Please try again later...').removeClass('hidden');
    };

    return {
        onCreateCommentSuccess: onCreateCommentSuccess,
        onCreateCommentFailure: onCreateCommentFailure,
        onUpdateCommentFormLoaded: onUpdateCommentFormLoaded,
        onUpdateCommentFormLoadFailure: onUpdateCommentFormLoadFailure,
        onUpdateCommentSuccess: onUpdateCommentSuccess,
        onUpdateCommentFailure: onUpdateCommentFailure
    };
})();