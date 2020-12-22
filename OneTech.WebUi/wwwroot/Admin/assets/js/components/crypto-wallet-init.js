// Apex charts for Wallet
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
	}

}
var spark3 = new ApexCharts(document.querySelector("#spark3"), spark3);
spark3.render();
