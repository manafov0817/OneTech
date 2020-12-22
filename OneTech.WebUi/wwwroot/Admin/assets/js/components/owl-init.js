$('.owl-carousel-1').owlCarousel({
	margin: 10,
	items: 4,
	nav: false,
	dots: true,
	loop: true, // Global loop
	autoplay: true,
	responsive: {
		0: {
			items: 1,
			nav: false
		},
		600: {
			items: 3,
			nav: false
		},
		1000: {
			items: 5,
			nav: false,
			loop: true // Responsive screen loop
		}
	}
});

$('.owl-carousel-2').owlCarousel({
	margin: 10,
	items: 4,
	nav: false,
	responsive: {
		0: {
			items: 1,
			nav: true
		},
		600: {
			items: 3,
			nav: false
		},
		1000: {
			items: 5,
			nav: true,
			loop: false
		}
	}
});
