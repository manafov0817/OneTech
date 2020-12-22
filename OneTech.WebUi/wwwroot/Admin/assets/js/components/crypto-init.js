$(function() {
	'use strict';

	// Chartjs line chart - mullti
	var multiLineData = {
		labels: [
			"2012",
			"2013",
			"2014",
			"2015",
			"2016",
			"2017",
			"2018"
		],
		datasets: [
			{
				label: 'Bitcoin',
				data: [
					400,
					600,
					500,
					600,
					700,
					600,
					800
				],
				borderColor: ['rgba(255, 206, 86, 0.5)'],
				borderWidth: 2,
				fill: false
			}, {
				label: 'NEO',
				data: [
					200,
					500,
					400,
					500,
					600,
					500,
					600
				],
				borderColor: ['rgba(75, 192, 192, 0.5)'],
				borderWidth: 2,
				fill: false
			}, {
				label: 'DASH',
				data: [
					300,
					600,
					500,
					300,
					600,
					300,
					400
				],
				borderColor: ['rgba(54, 162, 235, 0.5)'],
				borderWidth: 2,
				fill: false
			}
		]
	};
	var options = {
		scales: {
			xAxes: [
				{
					gridLines: {
						color: '#f5f6f7'
					}
				}
			],
			yAxes: [
				{
					gridLines: {
						color: '#f5f6f7'
					}
				}
			]
		},
		legend: {
			display: false,
			labels: {
				fontColor: "#8f8f8f",
				fontSize: 12
			}
		},
		elements: {
			point: {
				radius: 2
			}
		}

	};

	// Get context with jQuery - using jQuery's .get() method.
	if ($("#linechart-multi").length) {
		var multiLineCanvas = $("#linechart-multi")
			.get(0)
			.getContext("2d");
		var lineChart = new Chart(multiLineCanvas, {
			type: 'line',
			data: multiLineData,
			options: options
		});
	}

	// News scroller initialization
	$('.js-conveyor').jConveyorTicker({
		anim_duration: 200, // Specify the time (in milliseconds) the animation takes to move 10 pixels
		reverse_elm: false, // Enable the use of the reverse animation trigger HTML element
		force_loop: false // Force the initialization even if the items are too small in total width
	});

	// Small charts widgets
	function cryptoData(dataStats, color) {
		return {
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
					data: dataStats,
					backgroundColor: [color],
					borderColor: [color],
					borderWidth: 2,
					fill: true
				}
			]
		};
	}
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

	if ($("#linechart1").length) {
		var lineChartCanvas = $("#linechart1")
			.get(0)
			.getContext("2d");
		var lineChart = new Chart(lineChartCanvas, {
			type: 'line',
			data: cryptoData([
				5,
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
			], 'rgba(7, 191, 88, 0.1)'),
			options: options
		});
	}
	if ($("#linechart2").length) {
		var lineChartCanvas = $("#linechart2")
			.get(0)
			.getContext("2d");
		var lineChart = new Chart(lineChartCanvas, {
			type: 'line',
			data: cryptoData([
				6,
				7,
				8,
				6,
				7,
				7,
				6,
				9,
				7,
				8,
				6,
				8,
				5
			], 'rgba(0, 116, 241, 0.1)'),
			options: options
		});
	}
	if ($("#linechart3").length) {
		var lineChartCanvas = $("#linechart3")
			.get(0)
			.getContext("2d");
		var lineChart = new Chart(lineChartCanvas, {
			type: 'line',
			data: cryptoData([
				3,
				6,
				4,
				7,
				6,
				6,
				4,
				6,
				5,
				4,
				6,
				5,
				7
			], 'rgba(239, 31, 62, 0.1)'),
			options: options
		});
	}
	if ($("#linechart4").length) {
		var lineChartCanvas = $("#linechart4")
			.get(0)
			.getContext("2d");
		var lineChart = new Chart(lineChartCanvas, {
			type: 'line',
			data: cryptoData([
				6,
				5,
				8,
				6,
				7,
				5,
				6,
				4,
				7,
				4,
				6,
				3,
				5
			], 'rgba(255, 191, 0, 0.1)'),
			options: options
		});
	}
});
