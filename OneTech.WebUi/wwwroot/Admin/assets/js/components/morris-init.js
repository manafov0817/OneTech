$(function() {
	'use strict';

	var data = [
		{
			y: '2014',
			a: 50,
			b: 20
		}, {
			y: '2015',
			a: 100,
			b: 80
		}, {
			y: '2016',
			a: 60,
			b: 70
		}, {
			y: '2017',
			a: 180,
			b: 150
		}, {
			y: '2018',
			a: 140,
			b: 120
		}, {
			y: '2019',
			a: 100,
			b: 80
		}, {
			y: '2020',
			a: 150,
			b: 200
		}
	];

	if ($('#morrislinechart').length) {
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
			resize: true,
			barGap: 4,
			barSizeRatio: 0.55,
			lineColors: ['rgba(54, 162, 235, 0.5)', 'rgba(153, 102, 255, 0.5)']
		};
		config.element = 'morrislinechart';
		Morris.Line(config);
	}

	if ($('#morrisareachart').length) {
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
			resize: true,
			lineColors: ['rgba(54, 162, 235, 0.43)', 'rgba(75, 192, 192, 0.5)']
		};
		config.element = 'morrisareachart';
		Morris.Area(config);
	}

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
					label: "Friends",
					value: 30
				}, {
					label: "Allies",
					value: 15
				}, {
					label: "Enemies",
					value: 45
				}, {
					label: "Neutral",
					value: 10
				}
			]
		});
	}

	if ($('#morrisstackedchart').length) {
		var data = [
				{
					y: '2010',
					a: 50,
					b: 90
				}, {
					y: '2011',
					a: 65,
					b: 75
				}, {
					y: '2012',
					a: 50,
					b: 50
				}, {
					y: '2013',
					a: 75,
					b: 60
				}, {
					y: '2014',
					a: 80,
					b: 65
				}, {
					y: '2015',
					a: 90,
					b: 70
				}, {
					y: '2016',
					a: 100,
					b: 75
				}, {
					y: '2017',
					a: 115,
					b: 75
				}, {
					y: '2018',
					a: 120,
					b: 85
				}, {
					y: '2019',
					a: 145,
					b: 85
				}, {
					y: '2020',
					a: 160,
					b: 95
				}
			],
			formatY = function(y) {
				return '$' + y;
			},
			formatX = function(x) {
				return x.src.y;
			},

			config = {
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
				stacked: true,
				barGap: 4,
				barSizeRatio: 0.44,
				resize: true,
				barColors: [
					'rgba(54, 162, 235, 0.43)', 'rgb(233, 235, 238)'
				],
				yLabelFormat: formatY,
				xLabelFormat: formatX,
				hoverCallback: function(index, options, content, row) {
					return 'custom 1';
				}
			};

		config.element = 'morrisstackedchart';
		Morris.Bar(config);
	}

});
