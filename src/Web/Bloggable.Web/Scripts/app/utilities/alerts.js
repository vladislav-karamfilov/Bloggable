var Bloggable = Bloggable || {};

Bloggable.Alerts = (function () {
    var ALERTS_CONTAINER_SELECTOR = '.alert-container';

    var showAlert = function (alert) {
        var alertElementHtml =
            '<div class="alert ' + alert.alertClass + ' alert-dismissable">\
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">\
                    &times;\
                </button>\
                ' + alert.message + '\
            </div>';

        var alertElement = $(alertElementHtml);
        $(ALERTS_CONTAINER_SELECTOR).append(alertElement);

        setTimeout(function () {
            alertElement.fadeOut();
        }, 3000);
    };

    var success = function (message) {
        showAlert({ alertClass: 'alert-success', message: message });
    };

    var info = function (message) {
        showAlert({ alertClass: 'alert-info', message: message });
    };

    var warning = function (message) {
        showAlert({ alertClass: 'alert-warning', message: message });
    };

    var error = function (message) {
        showAlert({ alertClass: 'alert-danger', message: message });
    };

    return {
        showAlert: showAlert,
        success: success,
        info: info,
        warning: warning,
        error: error
    };
})();