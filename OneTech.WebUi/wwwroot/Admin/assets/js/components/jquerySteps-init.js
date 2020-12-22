$(function() {
	"use strict";

	$(document).ready(function() {
		var form = $("#vertical-wizard").show(); // Selct form
		form.steps({
			headerTag: "h3", // Which html tag will be considered as header
			bodyTag: "section", // which tag will be considered as body
			autoFocus: true,
			titleTemplate: '<span class="number">#index#</span> <span class="title">#title#</span>', // Template for title
			stepsOrientation: 1 // 1 is vertical, 0 or nothing is horizontal
		});
	});

	$(document).ready(function() {
		var form = $("#horizontal-wizard").show();
		form.steps({headerTag: "h3", bodyTag: "section", titleTemplate: '<span class="number">#index#</span> <span class="title">#title#</span>', stepsOrientation: 0});
	});

	$(document).ready(function() {
		var form = $("#horizontal-wizard-fullwidth").show();
		form.steps({headerTag: "h3", bodyTag: "section", titleTemplate: '<span class="number">#index#</span> <span class="title">#title#</span>', stepsOrientation: 0});
	});
});
