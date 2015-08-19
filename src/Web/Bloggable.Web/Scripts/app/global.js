(function () {
    window.onerror = function() {
        if (Bloggable.Alerts) {
            Bloggable.Alerts.error('There was a problem with your last action. Please reload the page and try again.');
        } else {
            alert('Something serious went wrong. Please close the application and try again.');
        }
    }
})();