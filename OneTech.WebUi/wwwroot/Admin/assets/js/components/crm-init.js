//title:Demo code for CRM Dashboard

$(function() {
	'use strict';

	// line chart
	var config = {
		type: 'line',
		data: {
			labels: [
				'January',
				'February',
				'March',
				'April',
				'May',
				'June',
				'July'
			],
			datasets: [
				{
					label: 'Target',
					borderColor: '#2489be',
					backgroundColor: '#2489be',
					data: [
						44,
						66,
						98,
						79,
						80,
						64,
						86,
						68,
						79,
						80,
						62,
						67,
						87
					]
				}, {
					label: 'Earning',
					borderColor: '#2494fd',
					backgroundColor: '#2494fd',
					data: [
						40,
						60,
						90,
						70,
						80,
						60,
						80,
						60,
						70,
						80,
						60,
						70,
						70
					]
				}, {
					label: 'Sales',
					borderColor: '#546aaa',
					backgroundColor: '#546aaa',
					data: [
						14,
						66,
						97,
						73,
						87,
						68,
						83,
						65,
						78,
						89,
						60,
						73,
						74
					]
				}
			]
		},
		options: {
			responsive: true,
			title: {
				display: false,
				text: 'Chart.js Line Chart - Stacked Area'
			},
			legend: {
				display: !1
			},
			tooltips: {
				mode: 'index'
			},
			elements: {
				point: {
					radius: 0
				}
			},
			hover: {
				mode: 'index'
			},
			responsive: true,
			maintainAspectRatio: false,
			scales: {
				xAxes: [
					{
						scaleLabel: {
							display: false,
							labelString: 'Month'
						}
					}
				],
				yAxes: [
					{
						stacked: true,
						scaleLabel: {
							display: false,
							labelString: 'Value'
						}
					}
				]
			}
		}
	};
	if ($("#canvas").length) {
		var lineChartCanvas = $("#canvas")
			.get(0)
			.getContext("2d");
		var lineChart = new Chart(lineChartCanvas, {
			type: config.type,
			data: config.data,
			options: config.options
		});
	}

	// Randomizing data for animation purpose
	function shuffle(array) {
		for (var i = array.length - 1; i > 0; i--) {
			var j = Math.floor(Math.random() * (i + 1));
			[
				array[i], array[j]
			] = [
				array[j], array[i]
			];
		}
	}
	document
		.getElementById('randomizeData')
		.addEventListener('click', function() {
			config
				.data
				.datasets
				.forEach(function(dataArr) {
					return shuffle(dataArr.data);
				});
			lineChart.update();
		});

	// Changing datasets each 03 seconds
	setInterval(function() {
		config
			.data
			.datasets
			.forEach(function(dataArr) {
				return shuffle(dataArr.data);
			});
		lineChart.update();
	}, 3000);

	// Radialbar chart
	var options = {
		chart: {
			height: 305,
			type: 'radialBar'
		},
		plotOptions: {
			radialBar: {
				offsetY: -10,
				startAngle: 0,
				endAngle: 210,
				hollow: {
					margin: 5,
					size: '40%',
					background: 'transparent',
					image: undefined
				},
				dataLabels: {
					name: {
						show: true
					},
					value: {
						show: true
					}
				}
			}
		},
		colors: [
			'#0084ff', '#39539E', '#0077B5'
		],
		series: [
			76, 67, 61
		],
		labels: [
			'New', 'Old', 'Others'
		],
		legend: {
			show: true,
			floating: true,
			fontSize: '12px',
			position: 'left',
			offsetX: 0,
			offsetY: 10,
			labels: {
				useSeriesColors: true
			},
			markers: {
				size: 0
			},
			itemMargin: {
				horizontal: 1
			}
		},
		responsive: [
			{
				breakpoint: 480,
				options: {
					legend: {
						show: false
					}
				}
			}
		]
	}
	var chart = new ApexCharts(document.querySelector("#chart"), options);
	chart.render();

	// Morrischart
	var data = [
		{
			y: 'Monday',
			a: 5000,
			b: 4500
		}, {
			y: 'Tuesday',
			a: 1000,
			b: 800
		}, {
			y: 'Wednesday',
			a: 4000,
			b: 5000
		}, {
			y: 'Thursday',
			a: 9000,
			b: 8000
		}, {
			y: 'Friday',
			a: 12000,
			b: 8000
		}, {
			y: 'Saturday',
			a: 5000,
			b: 3500
		}, {
			y: 'Sunday',
			a: 13000,
			b: 1100
		}
	];
	if ($('#morrisbarchart').length) {
		var config = {
			data: data,
			xkey: 'y',
			ykeys: [
				'a', 'b'
			],
			labels: [
				'Total Income', 'Total Outcome'
			],
			fillOpacity: 0.6,
			hideHover: 'auto',
			behaveLikeLine: true,
			barGap: 4,
			barSizeRatio: 0.44,
			resize: true,
			redraw: true,
			barColors: ['rgba(54, 162, 235, 0.43)', 'rgb(233, 235, 238)']
		};
		config.element = 'morrisbarchart';
		Morris.Bar(config);
	}
	if ($('#morrisdonutchart').length) {
		Morris.Donut({
			element: 'morrisdonutchart',
			colors: [
				'rgba(54, 162, 235, 1)', 'rgb(236, 72, 99)', 'rgba(153, 102, 255, 1)', 'rgba(75, 192, 192, 1)'
			],
			labelColor: 'rgba(54, 162, 235, 0.43)',
			data: [
				{
					label: "New Started",
					value: 20
				}, {
					label: "In Progress",
					value: 45
				}, {
					label: "On Hold",
					value: 10
				}, {
					label: "Finished",
					value: 25
				}
			],
			resize: true,
			redraw: true
		});
	}
});
