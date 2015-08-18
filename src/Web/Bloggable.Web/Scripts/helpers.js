var Bloggable = Bloggable || {};

Bloggable.Helpers = (function () {
    var ErrorResponseParser = {
        parse: function (jqXHR) {
            var responseObject = JSON.parse(jqXHR.responseText);

            if (responseObject.errorMessages) {
                responseObject.errorMessage = responseObject.errorMessages.join('\n');
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
