$(function() {
	'use strict';

	// initialize datatable
	if ($('#listProduct').length > 0) {
		$('#listProduct').DataTable({
			dom: 'Bfrtip',
			lengthChange: false,
			buttons: ['copy', 'excel', 'pdf', 'colvis']
		});
	};

	if ($('#listCustomer').length > 0) {
		$('#listCustomer').DataTable({
			dom: 'Bfrtip',
			lengthChange: false,
			buttons: ['copy', 'excel', 'pdf', 'colvis']
		});
	};
});
