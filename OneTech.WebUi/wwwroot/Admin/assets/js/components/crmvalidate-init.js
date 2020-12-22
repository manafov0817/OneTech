$(function() {
	'use strict';

	// Initialize select2
	$('.custom-select2-normal').select2();
	// Dropdown parent needs to be specified if in modal and initially hidden
	$('.custom-select2').select2({dropdownParent: $("#formModal")});

	// Initialize datepicker
	$('.datepicker').datepicker({startDate: "11/05/2011", endDate: "11/05/2100"});

	// Initialize monthpicker
	$('.monthpicker').datepicker({format: "mm-yyyy", viewMode: "months", minViewMode: "months"});

	// Validate add-project form
	$("#addProject").validate({
		rules: {
			protitle: {
				required: true,
				minlength: 8
			},
			client: {
				required: true
			},
			summery: {
				required: true
			},
			startdate: {
				required: true
			},
			enddate: {
				required: true
			}
		}
	});
});
