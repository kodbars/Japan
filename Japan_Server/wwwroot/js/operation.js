window.scrollToElement = function (elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
};

window.scrollToTopInterop = {
    init: function (dotNetHelper) {
        // Порог появления — высота шапки (например, 150px)
        const threshold = 150; // можно изменить под свою шапку

        window.addEventListener('scroll', function () {
            const scrollY = window.scrollY || window.pageYOffset;
            const isVisible = scrollY > threshold;
            dotNetHelper.invokeMethodAsync('OnScroll', isVisible);
        });
    },
    scrollToTop: function () {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    }
};