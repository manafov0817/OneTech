//Charts
var sparklineData = [
	47,
	45,
	54,
	38,
	56,
	24,
	65,
	31,
	37,
	39,
	62,
	51,
	35,
	41,
	35,
	27,
	93,
	53,
	61,
	27,
	54,
	43,
	19,
	46
];
var spark3 = {
	chart: {
		type: 'area',
		height: 231,
		sparkline: {
			enabled: true
		}
	},
	stroke: {
		curve: 'straight'
	},
	fill: {
		opacity: 0.3
	},
	series: [
		{
			data: sparklineData
		}
	],
	xaxis: {
		crosshairs: {
			width: 1
		}
	},
	yaxis: {
		min: 0
	},
	title: {
		text: '33M visitors',
		offsetX: 10,
		offsetY: 0,
		style: {
			fontSize: '18px',
			cssClass: 'apexcharts-yaxis-title'
		}
	},
	subtitle: {
		text: 'Visitor count',
		offsetX: 10,
		style: {
			fontSize: '12px',
			cssClass: 'apexcharts-yaxis-subtitle'
		}
	}
}
var spark3 = new ApexCharts(document.querySelector("#spark3"), spark3);
spark3.render();

var optionsCircle = {
		chart: {
			type: "radialBar",
			height: 240,
			offsetY: -30,
			offsetX: 20
		},
		plotOptions: {
			radialBar: {
				inverseOrder: !0,
				hollow: {
					margin: 5,
					size: "55%",
					background: "transparent"
				},
				track: {
					show: !0,
					background: "#ddd",
					strokeWidth: "10%",
					opacity: 1,
					margin: 5
				},
				dataLabels: {
					name: {
						fontSize: "18px"
					},
					value: {
						fontSize: "16px",
						color: "#50649c"
					}
				}
			}
		},
		series: [
			71, 63
		],
		labels: [
			"Domestic", "International"
		],
		legend: {
			show: !0,
			position: "bottom",
			offsetX: -40,
			offsetY: -10,
			formatter: function(e, t) {
				return e + " - " + t
					.w
					.globals
					.series[t.seriesIndex] + "%"
			}
		},
		fill: {
			type: "gradient",
			gradient: {
				shade: "dark",
				type: "horizontal",
				shadeIntensity: .5,
				inverseColors: !0,
				opacityFrom: 1,
				opacityTo: 1,
				stops: [
					0, 100
				],
				gradientToColors: ["#40e0d0", "#ff8c00", "#ff0080"]
			}
		},
		stroke: {
			lineCap: "round"
		}
	},

	chartCircle = new ApexCharts(document.querySelector("#circlechart"), optionsCircle);
chartCircle.render();

// Jvectormap
$(function() {
	$('#map').vectorMap({
		map: 'world_mill',
		backgroundColor: 'transparent',
		strokeWidth: 0,
		zoomOnScroll: false,
		regionStyle: {
			initial: {
				fill: '#fff',
				"fill-opacity": 1,
				stroke: 'rgba(153, 102, 255, 0.5)',
				"stroke-width": 1,
				"stroke-opacity": .4
			},
			hover: {
				fill: 'rgba(153, 102, 255, 0.5)',
				"fill-opacity": 0.8,
				cursor: 'pointer'
			},
			selected: {
				fill: 'yellow'
			},
			selectedHover: {}
		},
		markerStyle: {
			initial: {
				fill: '#fff',
				stroke: 'red',
				'fill-opacity': 1,
				'stroke-width': 8,
				'stroke-opacity': 0.3,
				'cursor': 'pointer',
				r: 5
			},
			hover: {
				r: 8,
				stroke: 'info',
				'stroke-width': 10
			}
		},
		series: {
			regions: [
				{
					values: {
						"CA": 'rgba(54, 162, 235, 0.5)',
						"US": 'rgba(75, 192, 192, 0.5)',
						"RU": 'rgba(153, 102, 255, 0.5)',
						"GB": 'rgba(255, 99, 132, 0.5)',
						"ES": 'rgba(54, 162, 235, 0.5)',
						"FR": 'rgba(153, 102, 255, 0.5)',
						"DE": 'rgba(255, 99, 132, 0.5)',
						"AU": 'rgba(255, 99, 132, 0.5)'
					},
					attribute: 'fill'
				}
			]
		},
		markers: [
			{
				latLng: [
					37.09024, -95.712891
				],
				name: "USA",
				style: {
					fill: "#f93b7a"
				}
			}, {
				latLng: [
					71.70694, -42.604301
				],
				name: "Greenland",
				style: {
					fill: "#f0961f"
				}
			}, {
				latLng: [
					-21.943369, 123.102198
				],
				name: "Australia",
				style: {
					fill: "#5766da"
				}
			}, {
				latLng: [
					40.43, -74.00
				],
				name: "New York City",
				style: {
					fill: "#f0961f"
				}
			}
		]
	});
});

// Widget slimscroll
$(".timeline-analytics").slimScroll({
	height: "535px",
	color: "rgb(236, 230, 230)",
	disableFadeOut: !0,
	borderRadius: 0,
	size: "0",
	alwaysVisible: !1
});
