$(function() {
	'use strict';

	// Init #myTable - detailed example
	if ($('#myTable').length) {
		// Execute function that initializes the table
		setDataTable();
	}

	// #myTable initialization function called above
	function setDataTable() {
		var myTable = $('#myTable').DataTable({
			searching: true,
			bLengthChange: true,
			destroy: true,
			info: true,
			responsive: true,
			"pagingType": "simple_numbers",
			dom: '<"row table-filter"<"col-sm-12"<"float-left"l><"float-sm-right"f><"clearfix">>>t<"row table-pagination"<"col-sm-12"<"text-center"ip>>>',
			language: {
				paginate: {
					previous: "<i class='icon-arrow-left'></i>",
					next: "<i class='icon-arrow-right'></i>"
				},
				searchPlaceholder: 'Search...',
				sSearch: '',
				lengthMenu: '_MENU_ items/page'
			},
			columns: [
				{
					className: "first-column"
				},
				null,
				null,
				null,
				null,
				null
			],
			drawCallback: function() {
				$($(".dataTables_wrapper .pagination li:first-of-type"))
					.find("a")
					.addClass("prev");
				$($(".dataTables_wrapper .pagination li:last-of-type"))
					.find("a")
					.addClass("next");

				$(".dataTables_wrapper .pagination").addClass("pagination-sm");
			}
		});
	}

	// Example responsive datatable
	// Add .responsive .nowrap classes to the <table>
	if ($('#example-responsive').length) {
		$('#example-responsive').DataTable();
	}

	if ($('#ajaxTable').length) {
		$('#ajaxTable').DataTable({"ajax": 'assets/js/ajax/arrays.txt'});
	}

	// Example buttons datatable
	if ($('#example-buttons').length) {
		$('#example-buttons').DataTable({
			dom: 'Bfrtip',
			lengthChange: false,
			buttons: ['copy', 'excel', 'pdf', 'colvis']
		});
	}

	// List product datatable
	if ($('#listProduct').length) {
		$('#listProduct').DataTable({
			dom: 'Bfrtip',
			lengthChange: false,
			buttons: ['copy', 'excel', 'pdf', 'colvis']
		});
	}

	//Editable Table
	if ($('#mainTable').length) {
		$('#mainTable')
			.editableTableWidget()
			.numericInputExample()
			.find('td:first')
			.focus();
	}
});
