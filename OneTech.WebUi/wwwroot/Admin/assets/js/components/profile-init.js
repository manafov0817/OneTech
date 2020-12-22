$('#magnific-popup').magnificPopup({
    delegate: 'a', // child items selector, by clicking on it popup will open
    type: 'image',
    removalDelay: 300,
    mainClass: 'mfp-with-zoom', // this class is for CSS animation below
    zoom: {
        enabled: true, // By default it's false, so don't forget to enable it
        duration: 300, // duration of the effect, in milliseconds
        easing: 'ease-in-out', // CSS transition easing function
        opener: function (openerElement) {
            return openerElement.is('img') ? openerElement : openerElement.find('img');
        }
    }
});
