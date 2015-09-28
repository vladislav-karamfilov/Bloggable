var Bloggable = Bloggable || {};

Bloggable.Helpers = (function () {
    var INTERNAL_SERVER_ERROR_STATUS_CODE = 500;

    var ErrorResponseParser = {
        parse: function (jqXHR) {
            var responseObject = JSON.parse(jqXHR.responseText);

            if (jqXHR.status === INTERNAL_SERVER_ERROR_STATUS_CODE) {
                // Show generic error message in case of server failure
                responseObject.errorMessage = 'An error has occurred. Please try again later...';
            } else if (responseObject.errorMessages) {
                responseObject.errorMessage = responseObject.errorMessages.join('<br/>');
            }

            return responseObject;
        }
    };

    var FormValidation = {
        reAttach: function (formSelector) {
            $(formSelector).removeData('validator');
            $(formSelector).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse(formSelector);
        }
    };

    return {
        ErrorResponseParser: ErrorResponseParser,
        FormValidation: FormValidation
    };
})();
