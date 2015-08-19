var Bloggable = Bloggable || {};

Bloggable.CommentActions = (function () {
    var onCreateCommentSuccess = function (data) {
        throw new Error('Not implemented');
    };

    var onCreateCommentFailure = function (jqXHR) {
        var response = Bloggable.Helpers.ErrorResponseParser.parse(jqXHR);

        debugger;
        // TODO: Show user-friendly error notification
        alert(response.errorMessage || 'An error has occured. Please try again later...');
    };

    var onUpdateCommentFormLoaded = function (data) {
        var formId = $(data).find('form').prop('id');
        Bloggable.Helpers.FormValidation.reAttach('#' + formId);
    };

    var onUpdateCommentSuccess = function (data) {
        throw new Error('Not implemented');
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
        onUpdateCommentSuccess: onUpdateCommentSuccess,
        onUpdateCommentFailure: onUpdateCommentFailure
    };
})();