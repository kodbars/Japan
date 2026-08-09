window.scrollToElement = function (elementId) {
    const element = document.getElementById(elementId);
    if (!element) return;

    const header = document.querySelector('.top-header');
    const offset = header ? header.offsetHeight : 0;

    const extraOffset = 35; // подберите нужное значение
    const elementPosition = element.getBoundingClientRect().top + window.scrollY;
    const offsetPosition = elementPosition - offset + extraOffset;

    window.scrollTo({
        top: offsetPosition,
        behavior: 'smooth'
    });
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