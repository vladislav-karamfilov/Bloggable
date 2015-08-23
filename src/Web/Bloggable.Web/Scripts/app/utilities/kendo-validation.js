var Bloggable = Bloggable || {};

Bloggable.KendoValidation = (function () {
    function _showValidationMessageTemplateForPopUpEditing(container, name, errors) {
        // Add the validation message to the form
        var validationMessageTmpl = kendo.template($('#validationMessageTemplateForPopUpEditing').html());

        container.find('[data-valmsg-for=' + name + '],[data-val-msg-for=' + name + ']')
            .replaceWith(validationMessageTmpl({ field: name, message: errors[0] }));
    }

    function displayAllValidationMessagesForGrid(args) {
        if (args.errors) {
            var grid, current;

            $('.k-grid').each(function () {
                current = $(this).data('kendoGrid');
                if (current.dataSource === args.sender) {
                    grid = current;
                    return false;
                }
            });

            if (grid) {
                var errors = args.errors;
                for (var err in errors) {
                    if (err === 'alert' || err === '') {
                        var errorMessageDisplayedToUser = 'Errors:';
                        var errorMessages = errors[err].errors;

                        for (var i = 0, len = errorMessages.length; i < len; i++) {
                            errorMessageDisplayedToUser += '\n' + errorMessages[i];
                        }

                        Bloggable.Alerts.error(errorMessageDisplayedToUser);
                        this.cancelChanges();
                    }
                }

                grid.one('dataBinding', function (e) {
                    e.preventDefault(); // Cancel grid rebind if error occurs            

                    for (var error in args.errors) {
                        _showValidationMessageTemplateForPopUpEditing(grid.editable.element, error, errors[error].errors);
                    }
                });
            }
        }
    }

    return {
        displayAllValidationMessagesForGrid: displayAllValidationMessagesForGrid
    };
})();