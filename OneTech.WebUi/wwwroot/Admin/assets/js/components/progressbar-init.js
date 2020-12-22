$(function() {
	var progressbar = new ProgressBar.Line('#progress_line', {
		strokeWidth: 1,
		easing: 'easeInOut',
		duration: 5000,
		color: '#FFEA82',
		trailColor: '#eee',
		trailWidth: 1,
		svgStyle: { // sets the height and width of the progressbars
			width: '100%',
			height: '10px'
		},
		from: {
			color: '#FFEA82'
		},
		to: {
			color: '#ED6A5A'
		},
		step: (state, bar) => {
			bar
				.path
				.setAttribute('stroke', state.color);
		}
	});
	progressbar.animate(1.0);

	var progressbar = new ProgressBar.Circle('#progress_rounded', {
		strokeWidth: 3,
		easing: 'easeInOut',
		duration: 5000,
		color: '#21abe9',
		trailColor: '#f4f4f4',
		trailWidth: 1,
		svgStyle: { // sets the height and width of the progressbars
			width: 'auto',
			height: '120px'
		}
	});
	progressbar.animate(0.8);

	var progressbar = new ProgressBar.SemiCircle('#progress_semicircle', {
		strokeWidth: 3,
		easing: 'easeInOut',
		duration: 5000,
		color: '#21abe9',
		trailColor: '#f4f4f4',
		trailWidth: 1,
		svgStyle: { // sets the height and width of the progressbars
			width: 'auto',
			height: '120px'
		},
		fill: 'rgba(0, 0, 0, 0)',
		text: {
			value: 'Market',

			className: 'progressbar__label',
			style: {
				color: '#f5f5f5',
				position: 'absolute',
				left: '50%',
				top: '50%',
				padding: 0,
				margin: 0,
				transform: {
					prefix: true,
					value: 'translate(-50%, -50%)'
				}
			},
			autoStyleContainer: true,
			alignToBottom: true
		}
	});
	progressbar.animate(0.8);

	var progressbar = new ProgressBar.Path('#heart-path', {
		easing: 'easeInOut',
		duration: 2400
	});
	progressbar.set(0);
	progressbar.animate(1.0);

});
