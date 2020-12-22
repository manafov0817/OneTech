$(function() {

	// Initialize news scroll
	$('.js-conveyor').jConveyorTicker({
		anim_duration: 200, // Specify the time (in milliseconds) the animation takes to move 10 pixels
		reverse_elm: false, // Enable the use of the reverse animation trigger HTML element
		force_loop: false // Force the initialization even if the items are too small in total width
	});

});
