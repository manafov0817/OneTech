$(function() {
	'use strict';

	// C3 line chart
	var c3LineChart = c3.generate({
		bindto: '#c3linechart',
		data: {
			columns: [
				[
					'data1',
					40,
					190,
					110,
					390,
					160,
					240
				],
				[
					'data2',
					40,
					30,
					20,
					40,
					25,
					35
				]
			]
		},
		color: {
			pattern: ['rgba(75, 192, 192, 0.5)', 'rgba(54, 162, 235, 0.5)', 'rgba(153, 102, 255, 0.5)']
		},
		padding: {
			top: 0,
			right: 0,
			bottom: 30,
			left: 0
		}
	});

	// To mock data animation, changig the values on the fly
	setTimeout(function() {
		c3LineChart.load({
			columns: [
				[
					'data1',
					240,
					200,
					290,
					490,
					310,
					400
				]
			]
		});
	}, 1000);

	setTimeout(function() {
		c3LineChart.load({
			columns: [
				[
					'data3',
					130,
					150,
					200,
					300,
					200,
					100
				]
			]
		});
	}, 1500);

	setTimeout(function() {
		c3LineChart.unload({ids: 'data1'});
	}, 2000);

	// C3 spline chart
	var c3SplineChart = c3.generate({
		bindto: '#c3splinechart',
		data: {
			columns: [
				[
					'data1',
					40,
					190,
					110,
					390,
					160,
					240
				],
				[
					'data2',
					130,
					100,
					140,
					200,
					150,
					50
				]
			],
			type: 'spline'
		},
		color: {
			pattern: ['rgba(75, 192, 192, 0.5)', 'rgba(153, 102, 255, 0.5)', 'rgba(54, 162, 235, 0.5)']
		},
		padding: {
			top: 0,
			right: 0,
			bottom: 30,
			left: 0
		}
	});

	// C3 barchart
	var c3BarChart = c3.generate({
		bindto: '#c3barchart',
		data: {
			columns: [
				[
					'data1',
					40,
					190,
					110,
					390,
					160,
					240
				],
				[
					'data2',
					130,
					100,
					140,
					200,
					150,
					50
				]
			],
			type: 'bar'
		},
		color: {
			pattern: ['rgba(54, 162, 235, 0.5)', 'rgba(153, 102, 255, 0.5)', 'rgb(233, 235, 238)']
		},
		padding: {
			top: 0,
			right: 0,
			bottom: 30,
			left: 0
		},
		bar: {
			width: {
				ratio: 0.7 // this makes bar width 50% of length between ticks
			}
		}
	});

	setTimeout(function() {
		c3BarChart.load({
			columns: [
				[
					'data3',
					130,
					-150,
					200,
					300,
					-200,
					100
				]
			]
		});
	}, 1000);

	// C3 step shart
	var c3StepChart = c3.generate({
		bindto: '#c3stepchart',
		data: {
			columns: [
				[
					'data1',
					300,
					350,
					300,
					0,
					0,
					100
				],
				[
					'data2',
					130,
					100,
					140,
					200,
					150,
					50
				]
			],
			types: {
				data1: 'step',
				data2: 'area-step'
			}
		},
		color: {
			pattern: ['rgba(75, 192, 192, 0.5)', 'rgba(153, 102, 255, 0.5)', 'rgba(54, 162, 235, 0.5)']
		},
		padding: {
			top: 0,
			right: 0,
			bottom: 30,
			left: 0
		}
	});

	//  C3 pie chart
	var c3PieChart = c3.generate({
		bindto: '#c3piechart',
		data: {
			// iris data from R
			columns: [
				[
					'data1', 30
				],
				[
					'data2', 120
				]
			],
			type: 'pie',
			onclick: function(d, i) {
				console.log("onclick", d, i);
			},
			onmouseover: function(d, i) {
				console.log("onmouseover", d, i);
			},
			onmouseout: function(d, i) {
				console.log("onmouseout", d, i);
			}
		},
		color: {
			pattern: ['rgba(75, 192, 192, 0.5)', 'rgba(153, 102, 255, 0.5)', 'rgba(54, 162, 235, 0.5)']
		},
		padding: {
			top: 0,
			right: 0,
			bottom: 30,
			left: 0
		}
	});

	setTimeout(function() {
		c3PieChart.load({
			columns: [
				[
					"Income",
					0.2,
					0.2,
					0.2,
					0.2,
					0.2,
					0.4,
					0.3,
					0.2,
					0.2,
					0.1,
					0.2,
					0.2,
					0.1,
					0.1,
					0.2,
					0.4,
					0.4,
					0.3,
					0.3,
					0.3,
					0.2,
					0.4,
					0.2,
					0.5,
					0.2,
					0.2,
					0.4,
					0.2,
					0.2,
					0.2,
					0.2,
					0.4,
					0.1,
					0.2,
					0.2,
					0.2,
					0.2,
					0.1,
					0.2,
					0.2,
					0.3,
					0.3,
					0.2,
					0.6,
					0.4,
					0.3,
					0.2,
					0.2,
					0.2,
					0.2
				],
				[
					"Outcome",
					1.4,
					1.5,
					1.5,
					1.3,
					1.5,
					1.3,
					1.6,
					1.0,
					1.3,
					1.4,
					1.0,
					1.5,
					1.0,
					1.4,
					1.3,
					1.4,
					1.5,
					1.0,
					1.5,
					1.1,
					1.8,
					1.3,
					1.5,
					1.2,
					1.3,
					1.4,
					1.4,
					1.7,
					1.5,
					1.0,
					1.1,
					1.0,
					1.2,
					1.6,
					1.5,
					1.6,
					1.5,
					1.3,
					1.3,
					1.3,
					1.2,
					1.4,
					1.2,
					1.0,
					1.3,
					1.2,
					1.3,
					1.3,
					1.1,
					1.3
				],
				[
					"Revenue",
					2.5,
					1.9,
					2.1,
					1.8,
					2.2,
					2.1,
					1.7,
					1.8,
					1.8,
					2.5,
					2.0,
					1.9,
					2.1,
					2.0,
					2.4,
					2.3,
					1.8,
					2.2,
					2.3,
					1.5,
					2.3,
					2.0,
					2.0,
					1.8,
					2.1,
					1.8,
					1.8,
					1.8,
					2.1,
					1.6,
					1.9,
					2.0,
					2.2,
					1.5,
					1.4,
					2.3,
					2.4,
					1.8,
					1.8,
					2.1,
					2.4,
					2.3,
					1.9,
					2.3,
					2.5,
					2.3,
					1.9,
					2.0,
					2.3,
					1.8
				]
			]
		});
	}, 1500);

	setTimeout(function() {
		c3PieChart.unload({ids: 'data1'});
		c3PieChart.unload({ids: 'data2'});
	}, 2500);

	// C3 donut chart
	var c3DonutChart = c3.generate({
		bindto: '#c3donutchart',
		data: {
			columns: [
				[
					'data1', 30
				],
				[
					'data2', 120
				]
			],
			type: 'donut',
			onclick: function(d, i) {
				console.log("onclick", d, i);
			},
			onmouseover: function(d, i) {
				console.log("onmouseover", d, i);
			},
			onmouseout: function(d, i) {
				console.log("onmouseout", d, i);
			}
		},
		color: {
			pattern: ['rgba(75, 192, 192, 0.5)', 'rgba(153, 102, 255, 0.5)', 'rgba(54, 162, 235, 0.5)']
		},
		padding: {
			top: 0,
			right: 0,
			bottom: 30,
			left: 0
		},
		donut: {
			title: "Iris Petal Width"
		}
	});

	setTimeout(function() {
		c3DonutChart.load({
			columns: [
				[
					"setosa",
					0.2,
					0.2,
					0.2,
					0.2,
					0.2,
					0.4,
					0.3,
					0.2,
					0.2,
					0.1,
					0.2,
					0.2,
					0.1,
					0.1,
					0.2,
					0.4,
					0.4,
					0.3,
					0.3,
					0.3,
					0.2,
					0.4,
					0.2,
					0.5,
					0.2,
					0.2,
					0.4,
					0.2,
					0.2,
					0.2,
					0.2,
					0.4,
					0.1,
					0.2,
					0.2,
					0.2,
					0.2,
					0.1,
					0.2,
					0.2,
					0.3,
					0.3,
					0.2,
					0.6,
					0.4,
					0.3,
					0.2,
					0.2,
					0.2,
					0.2
				],
				[
					"versicolor",
					1.4,
					1.5,
					1.5,
					1.3,
					1.5,
					1.3,
					1.6,
					1.0,
					1.3,
					1.4,
					1.0,
					1.5,
					1.0,
					1.4,
					1.3,
					1.4,
					1.5,
					1.0,
					1.5,
					1.1,
					1.8,
					1.3,
					1.5,
					1.2,
					1.3,
					1.4,
					1.4,
					1.7,
					1.5,
					1.0,
					1.1,
					1.0,
					1.2,
					1.6,
					1.5,
					1.6,
					1.5,
					1.3,
					1.3,
					1.3,
					1.2,
					1.4,
					1.2,
					1.0,
					1.3,
					1.2,
					1.3,
					1.3,
					1.1,
					1.3
				],
				[
					"virginica",
					2.5,
					1.9,
					2.1,
					1.8,
					2.2,
					2.1,
					1.7,
					1.8,
					1.8,
					2.5,
					2.0,
					1.9,
					2.1,
					2.0,
					2.4,
					2.3,
					1.8,
					2.2,
					2.3,
					1.5,
					2.3,
					2.0,
					2.0,
					1.8,
					2.1,
					1.8,
					1.8,
					1.8,
					2.1,
					1.6,
					1.9,
					2.0,
					2.2,
					1.5,
					1.4,
					2.3,
					2.4,
					1.8,
					1.8,
					2.1,
					2.4,
					2.3,
					1.9,
					2.3,
					2.5,
					2.3,
					1.9,
					2.0,
					2.3,
					1.8
				]
			]
		});
	}, 1500);

	setTimeout(function() {
		c3DonutChart.unload({ids: 'data1'});
		c3DonutChart.unload({ids: 'data2'});
	}, 2500);
});
