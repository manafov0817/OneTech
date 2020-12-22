$(function() {
	// Initialize sparkline
	$("#linechart").sparkline([
		5,
		6,
		7,
		9,
		9,
		5,
		3,
		2,
		2,
		4,
		6,
		7
	], {type: 'line'});

	$("#barchart").sparkline([
		5,
		6,
		7,
		2,
		0,
		-4,
		-2,
		4
	], {type: 'bar'});

	$("#tristate").sparkline([
		1,
		1,
		0,
		1,
		-1,
		-1,
		1,
		-1,
		0,
		0,
		1,
		1
	], {type: 'tristate'});

	$("#discreet").sparkline([
		4,
		6,
		7,
		7,
		4,
		3,
		2,
		1,
		4,
		4
	], {type: 'discrete'});

	$("#bullet").sparkline([
		10, 12, 12, 9, 7
	], {type: 'bullet'});

	$("#pie").sparkline([
		1, 1, 2
	], {type: 'pie'});

	$("#boxplot").sparkline([
		4,
		27,
		34,
		52,
		54,
		59,
		61,
		68,
		78,
		82,
		85,
		87,
		91,
		93,
		100
	], {type: 'box'});
});
