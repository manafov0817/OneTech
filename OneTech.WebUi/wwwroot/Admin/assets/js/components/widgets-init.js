// datepicker
$(function() {
	$("#datepicker").datepicker({
		beforeShowDay: function(date) {
			var day = date.getDate();
			return [
				true,
				(
					day < 10
					? "add-zero"
					: "")
			];
		}
	});
});

// rating
$(function() {
	$('.example').each(function() {
		var data = $(this).attr('data-current-rating');
		$(this).barrating({theme: 'fontawesome-stars-o', showSelectedRating: true, initialRating: data, readonly: false});
	});
});

// chartjs line chart for widgets
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
			fill: true
		}
	]
};

var options = {
	scales: {
		responsive: !1,
		maintainAspectRatio: !0,
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
if ($("#linechart1").length) {
	var lineChartCanvas = $("#linechart1")
		.get(0)
		.getContext("2d");
	var lineChart = new Chart(lineChartCanvas, {
		type: 'line',
		data: data,
		options: options
	});
}
