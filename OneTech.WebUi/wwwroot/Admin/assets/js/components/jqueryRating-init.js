$(function() {

	$('#bars-1to10').barrating('show', {
		theme: 'bars-1to10',
		showSelectedRating: false
	});

	$('#bars-horizontal').barrating('show', {
		theme: 'bars-horizontal',
		reverse: true,
		hoverState: false,
		showSelectedRating: false
	});

	$('#bars-movie').barrating('show', {
		theme: 'bars-movie',
		showSelectedRating: false
	});
	$('#bars-movie').barrating('set', 'Mediocre');

	$('#bars-pill').barrating('show', {
		theme: 'bars-pill',
		initialRating: 'A',
		showValues: true,
		showSelectedRating: false,
		allowEmpty: true,
		emptyValue: '-- no rating selected --',
		onSelect: function(value, text) {
			alert('Selected rating: ' + value);
		}
	});

	$('#bars-reversed').barrating('show', {
		theme: 'bars-reversed',
		reverse: true
	});

	$('#bars-square').barrating('show', {
		theme: 'bars-square',
		showValues: true,
		showSelectedRating: false
	});

	$('#bootstrap-stars').barrating({theme: 'bootstrap-stars', showSelectedRating: false});

	$('#css-stars').barrating({theme: 'css-stars', showSelectedRating: false});

	$('#fontawesome-stars').barrating({theme: 'fontawesome-stars', showSelectedRating: false});

	$('#fontawesome-stars-o').barrating({theme: 'fontawesome-stars-o', showSelectedRating: false});

	// Application of the library
	var currentRating = $('#example-fontawesome-o').data('current-rating');

	// Get current rating
	$('.stars-example-fontawesome-o .current-rating')
		.find('span')
		.html(currentRating);

	// On click to clear, clear rating
	$('.stars-example-fontawesome-o .clear-rating').on('click', function(event) {
		event.preventDefault();

		$('#example-fontawesome-o').barrating('clear');
	});

	// Initialize and set onSelect and onClear CB params
	$('#example-fontawesome-o').barrating({
		theme: 'fontawesome-stars-o',
		showSelectedRating: false,
		initialRating: currentRating,
		onSelect: function(value, text) {
			if (!value) {
				$('#example-fontawesome-o').barrating('clear');
			} else {
				$('.stars-example-fontawesome-o .current-rating').addClass('hidden');

				$('.stars-example-fontawesome-o .your-rating')
					.removeClass('hidden')
					.find('span')
					.html(value);
			}
		},
		onClear: function(value, text) {
			$('.stars-example-fontawesome-o')
				.find('.current-rating')
				.removeClass('hidden')
				.end()
				.find('.your-rating')
				.addClass('hidden');
		}
	});

});
