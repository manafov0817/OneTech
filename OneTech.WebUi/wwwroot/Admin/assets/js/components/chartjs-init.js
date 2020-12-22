$(function() {
	'use strict';

	// Common options for several chart types
	var options = {
		scales: {
			yAxes: [
				{
					ticks: {
						beginAtZero: true
					}
				}
			]
		},
		legend: {
			display: false
		},
		elements: {
			point: {
				radius: 2
			}
		}

	};

	// Bar chart
	var bardata = {
		labels: [
			"January",
			"February",
			"March",
			"April",
			"May",
			"June",
			"July",
			"August"
		],
		datasets: [
			{
				label: '# Sales',
				data: [
					1,
					19,
					7,
					11,
					4,
					6,
					11,
					6
				],
				backgroundColor: [
					'rgba(54, 162, 235, 0.5)',
					'rgba(54, 162, 235, 0.5)',
					'rgba(255, 206, 86, 0.5)',
					'rgba(75, 192, 192, 0.5)',
					'rgba(153, 102, 255, 0.5)',
					'rgba(255, 159, 64, 0.5)',
					'rgba(47, 191, 160, 0.5)',
					'rgba(236, 72, 99, 0.5)'
				],
				borderColor: [
					'rgba(54, 162, 235, 1)',
					'rgba(54, 162, 235, 1)',
					'rgba(255, 206, 86, 1)',
					'rgba(75, 192, 192, 1)',
					'rgba(153, 102, 255, 1)',
					'rgba(255, 159, 64, 1)',
					'rgb(47, 191, 160)',
					'rgb(236, 72, 99)'
				],
				borderWidth: 1,
				fill: false
			}
		]
	};

	// Get context with jQuery - using jQuery's .get() method.
	if ($("#barChart").length) {
		var barChartCanvas = $("#barChart")
			.get(0)
			.getContext("2d");

		// This will get the first returned node in the jQuery collection.
		var barChart = new Chart(barChartCanvas, {
			type: 'bar',
			data: bardata,
			options: options
		});
	}

	// Line chart
	// Options same as above charts
	var data = {
		labels: [
			"2013",
			"2014",
			"2015",
			"2016",
			"2017",
			"2018"
		],
		datasets: [
			{
				label: '# Sales',
				data: [
					1,
					19,
					7,
					11,
					4,
					6
				],
				backgroundColor: ['rgba(54, 162, 235, 1)'],
				borderColor: ['rgba(54, 162, 235, 1)'],
				borderWidth: 1,
				fill: false
			}
		]
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

	// Donut and Pie chart
	var doughnutPieData = {
		datasets: [
			{
				data: [
					30, 40, 30
				],
				backgroundColor: [
					'rgba(75, 192, 192, 0.5)',
					'rgba(54, 162, 235, 0.5)',
					'rgba(153, 102, 255, 0.5)',
					'rgba(255, 206, 86, 0.5)',
					'rgba(75, 192, 192, 0.5)',
					'rgba(255, 159, 64, 0.5)'
				],
				borderColor: [
					'rgba(75, 192, 192, 1)',
					'rgba(54, 162, 235, 1)',
					'rgba(153, 102, 255, 1)',
					'rgba(255, 206, 86, 1)',
					'rgba(75, 192, 192, 1)',
					'rgba(255, 159, 64, 1)'
				]
			}
		],

		// These labels appear in the legend and in the tooltips when hovering different arcs
		labels: ['Activated', 'Pending', 'Deactivated']
	};
	var doughnutPieOptions = {
		responsive: true,
		animation: {
			animateScale: true,
			animateRotate: true
		}
	};
	if ($("#doughnutchart").length) {
		var doughnutChartCanvas = $("#doughnutchart")
			.get(0)
			.getContext("2d");
		var doughnutChart = new Chart(doughnutChartCanvas, {
			type: 'doughnut',
			data: doughnutPieData,
			options: doughnutPieOptions
		});
	}

	// Data and options same as the previous donut chart
	if ($("#piechart").length) {
		var pieChartCanvas = $("#piechart")
			.get(0)
			.getContext("2d");
		var pieChart = new Chart(pieChartCanvas, {
			type: 'pie',
			data: doughnutPieData,
			options: doughnutPieOptions
		});
	}

	// Area chart
	var areaData = {
		labels: [
			"2013",
			"2014",
			"2015",
			"2016",
			"2017",
			"2018"
		],
		datasets: [
			{
				label: '# Sales',
				data: [
					1,
					19,
					7,
					11,
					4,
					3
				],
				backgroundColor: ['rgba(54, 162, 235, 0.5)'],
				borderColor: ['rgba(54, 162, 235, 1)'],
				borderWidth: 1,
				fill: true, // 3: no fill
			}, {
				label: '# Expenses',
				data: [
					12,
					17,
					4,
					9,
					3,
					9
				],
				backgroundColor: ['rgba(153, 102, 255, 0.5)'],
				borderColor: ['rgba(153, 102, 255, 1)'],
				borderWidth: 1,
				fill: true, // 3: no fill
			}
		]
	};
	var areaOptions = {
		plugins: {
			filler: {
				propagate: true
			}
		}
	}
	if ($("#areaChart").length) {
		var areaChartCanvas = $("#areaChart")
			.get(0)
			.getContext("2d");
		var areaChart = new Chart(areaChartCanvas, {
			type: 'line',
			data: areaData,
			options: areaOptions
		});
	}

	// Scatter chart
	var scatterChartOptions = {
		scales: {
			xAxes: [
				{
					type: 'linear',
					position: 'bottom'
				}
			]
		}
	}
	var scatterChartData = {
		datasets: [
			{
				label: 'First Dataset',
				data: [
					{
						x: -10,
						y: 0
					}, {
						x: 0,
						y: 3
					}, {
						x: -25,
						y: 5
					}, {
						x: 40,
						y: 5
					}
				],
				backgroundColor: ['rgba(255, 99, 132, 0.5)'],
				borderColor: ['rgba(255,99,132,1)'],
				borderWidth: 1
			}, {
				label: 'Second Dataset',
				data: [
					{
						x: 10,
						y: 5
					}, {
						x: 20,
						y: -30
					}, {
						x: -25,
						y: 15
					}, {
						x: -10,
						y: 5
					}
				],
				backgroundColor: ['rgba(54, 162, 235, 0.5)'],
				borderColor: ['rgba(54, 162, 235, 1)'],
				borderWidth: 1
			}
		]
	}
	if ($("#scatterchart").length) {
		var scatterChartCanvas = $("#scatterchart")
			.get(0)
			.getContext("2d");
		var scatterChart = new Chart(scatterChartCanvas, {
			type: 'scatter',
			data: scatterChartData,
			options: scatterChartOptions
		});
	}
});
