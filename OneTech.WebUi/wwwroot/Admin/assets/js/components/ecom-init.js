//Progressbar Library

$(function() {

	var progressbar = new ProgressBar.SemiCircle('#progress_semicircle', {
		strokeWidth: 3,
		easing: 'easeInOut',
		duration: 2000,
		color: '#21abe9',
		trailColor: '#f4f4f4',
		trailWidth: 3,
		svgStyle: { // sets the height and width of the progressbars
			width: 'auto',
			height: '85px'
		},
		fill: 'rgba(0, 0, 0, 0)',
		text: {
			value: '80%',

			className: 'progressbar__label',
			style: {
				color: '#05353e',
				position: 'absolute',
				left: '50%',
				top: '100%',
				padding: 0,
				fontSize: '25px',
				margin: 0,
				transform: {
					prefix: true,
					value: 'translate(-50%, -100%)'
				}
			},

			autoStyleContainer: true,

			alignToBottom: true
		}
	});
	progressbar.animate(0.8);

	//Chartist
	var chart = Chartist.Bar('.chartoverlapping', {
		labels: [
			'Jan',
			'Feb',
			'Mar',
			'Apr',
			'May',
			'Jun',
			'Jul',
			'Aug',
			'Sep',
			'Oct',
			'Nov',
			'Dec'
		],
		series: [
			[
				5,
				4,
				3,
				7,
				5,
				10,
				3,
				4,
				8,
				10,
				6,
				8
			],
			[
				3,
				2,
				9,
				5,
				4,
				6,
				4,
				6,
				7,
				8,
				7,
				4
			]
		]
	}, {
		chartPadding: 0,
		showPoint: true,
		showLine: true,
		fullWidth: true,
		showLabel: false,
		axisX: {
			showGrid: false,
			showLabel: true,
			offset: 50
		},
		axisY: {
			showGrid: false,
			showLabel: false,
			offset: 0
		},
		low: 0,
		seriesBarDistance: 5
	});

	// Listening for draw events that get emitted by the Chartist chart
	chart.on('draw', function(data) {
		// If the draw event was triggered from drawing a point on the line chart
		if (data.type === 'label' && data.axis === 'x') {

			// We just offset the label X position to be in the middle between the current and next axis grid
			data
				.element
				.attr({
					dx: data.x + data.space / 2
				});
		}
	});

	//ChartJs
	var data = {
		labels: [
			"2013",
			"2014",
			"2015",
			"2016",
			"2017",
			"2018",
			"2019",
			"2021",
			"2022",
			"2023",
			"2025",
			"2026",
			"2028"
		],
		datasets: [
			{
				label: '# Sales',
				data: [
					4,
					6,
					9,
					7,
					8,
					6,
					8,
					6,
					7,
					8,
					6,
					7,
					7
				],
				backgroundColor: ['rgba(54, 162, 235, 1)'],
				borderColor: ['rgba(54, 162, 235, 1)'],
				borderWidth: 2,
				fill: false
			}
		]
	};

	var options = {
		scales: {
			responsive: 1,
			maintainAspectRatio: 1,
			yAxes: [
				{
					display: !1
				}
			],
			xAxes: [
				{
					display: !1
				}
			]
		},
		legend: {
			display: !1
		},
		elements: {
			point: {
				radius: 0
			}
		},
		stepsize: 100,
		responsive: true,
		maintainAspectRatio: false
	};

	if ($("#linechart").length) {
		var lineChartCanvas = $("#linechart")
			.get(0)
			.getContext("2d");
		var lineChart = new Chart(lineChartCanvas, {
			type: 'line',
			data: data,
			options: options
		});
	}

	//Rating initialization
	$('.example').each(function() {
		var data = $(this).attr('data-current-rating');
		$(this).barrating({theme: 'fontawesome-stars-o', showSelectedRating: true, initialRating: data, readonly: false});
	});

});
