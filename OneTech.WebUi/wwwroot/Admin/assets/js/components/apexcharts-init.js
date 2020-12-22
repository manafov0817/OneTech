// Basic chart
var options = {
	chart: {
		height: 350,
		type: 'bar'
	},
	plotOptions: {
		bar: {
			horizontal: true,
			columnWidth: '55%',
			endingShape: 'rounded'
		}
	},
	dataLabels: {
		enabled: false
	},
	stroke: {
		show: true,
		width: 2,
		colors: ['transparent']
	},
	series: [
		{
			name: 'Net Profit',
			data: [44, 55, 57, 56, 61]
		}, {
			name: 'Revenue',
			data: [76, 85, 101, 98, 87]
		}, {
			name: 'Free Cash Flow',
			data: [35, 41, 36, 26, 45]
		}
	],
	xaxis: {
		categories: [
			'Feb',
			'Mar',
			'Apr',
			'May',
			'Jun',
			'Jul',
			'Aug',
			'Sep',
			'Oct'
		]
	},
	yaxis: {
		title: {
			text: '$ (thousands)'
		}
	},
	fill: {
		opacity: 1

	},
	tooltip: {
		y: {
			formatter: function(val) {
				return "$ " + val + " thousands"
			}
		}
	}
}

var chart = new ApexCharts(document.querySelector("#chart"), options);
chart.render();

// Init from attr
window.Apex = {
	chart: {
		height: 350
	},
	stroke: {
		curve: "smooth"
	},
	dataLabels: {
		enabled: false
	}
}
ApexCharts.initOnLoad();

// Donut chart
var options = {
	chart: {
		type: 'donut'
	},
	series: [
		44, 55, 41, 17, 15
	],
	responsive: [
		{
			breakpoint: 480,
			options: {
				chart: {
					width: 300
				},
				legend: {
					position: 'bottom'
				}
			}
		}
	]
}

var chart = new ApexCharts(document.querySelector("#donut"), options);
chart.render();

// Semi-circle chart
var options = {
	chart: {
		type: 'radialBar'
	},

	plotOptions: {
		radialBar: {
			startAngle: -90,
			endAngle: 90,
			track: {
				background: "#e7e7e7",
				strokeWidth: '97%',
				margin: 5, // margin is in pixels
				shadow: {
					enabled: true,
					top: 2,
					left: 0,
					color: '#999',
					opacity: 1,
					blur: 2
				}
			},
			dataLabels: {
				name: {
					show: false
				},
				value: {
					offsetY: 15,
					fontSize: '22px'
				}
			}
		}
	},
	fill: {
		type: 'gradient',
		gradient: {
			shade: 'light',
			shadeIntensity: 0.4,
			inverseColors: false,
			opacityFrom: 1,
			opacityTo: 1,
			stops: [0, 50, 53, 91]
		}
	},
	series: [76],
	labels: ['Average Results']
}

var chart = new ApexCharts(document.querySelector("#semi-circle"), options);
chart.render();

// Spark chart
window.Apex = {
	stroke: {
		width: 3
	},
	markers: {
		size: 0
	},
	tooltip: {
		fixed: {
			enabled: true
		}
	}
};

var randomizeArray = function(arg) {
	var array = arg.slice();
	var currentIndex = array.length,
		temporaryValue,
		randomIndex;

	while (0 !== currentIndex) {

		randomIndex = Math.floor(Math.random() * currentIndex);
		currentIndex -= 1;

		temporaryValue = array[currentIndex];
		array[currentIndex] = array[randomIndex];
		array[randomIndex] = temporaryValue;
	}

	return array;
}

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
		height: 160,
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
			data: randomizeArray(sparklineData)
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
		text: '$135,965',
		offsetX: 0,
		style: {
			fontSize: '24px',
			cssClass: 'apexcharts-yaxis-title'
		}
	},
	subtitle: {
		text: 'Profits',
		offsetX: 0,
		style: {
			fontSize: '14px',
			cssClass: 'apexcharts-yaxis-title'
		}
	}
}
var spark3 = new ApexCharts(document.querySelector("#spark3"), spark3);
spark3.render();

// For small cards
var options5 = {
	chart: {
		type: 'bar',
		width: 100,
		height: 35,
		sparkline: {
			enabled: true
		}
	},
	plotOptions: {
		bar: {
			columnWidth: '80%'
		}
	},
	series: [
		{
			data: [
				25,
				66,
				41,
				89,
				63,
				25,
				44,
				12,
				36,
				9,
				54
			]
		}
	],
	labels: [
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8,
		9,
		10,
		11
	],
	xaxis: {
		crosshairs: {
			width: 1
		}
	},
	tooltip: {
		fixed: {
			enabled: false
		},
		x: {
			show: false
		},
		y: {
			title: {
				formatter: function(seriesName) {
					return ''
				}
			}
		},
		marker: {
			show: false
		}
	}
}
new ApexCharts(document.querySelector("#chart5"), options5).render();
