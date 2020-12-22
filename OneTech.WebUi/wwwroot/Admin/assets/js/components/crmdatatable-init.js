$(function() {
	'use strict';

	// Initialize datatables
	$('#listClient').DataTable({
		dom: 'Bfrtip',
		lengthChange: false,
		buttons: ['copy', 'excel', 'pdf', 'colvis']
	});

	$('#listTasks').DataTable({
		dom: 'Bfrtip',
		lengthChange: false,
		buttons: ['copy', 'excel', 'pdf', 'colvis']
	});

	$('#payments').DataTable({
		dom: 'Bfrtip',
		lengthChange: false,
		buttons: ['copy', 'excel', 'pdf', 'colvis']
	});

	$('#yearlypay').DataTable({
		dom: 'Bfrtip',
		lengthChange: false,
		buttons: ['copy', 'excel', 'pdf', 'colvis']
	});

	$('#attendance').DataTable({
		dom: 'Bfrtip',
		lengthChange: false,
		buttons: ['copy', 'excel', 'pdf', 'colvis']
	});

	$('#leaves').DataTable({
		dom: 'Bfrtip',
		lengthChange: false,
		buttons: ['copy', 'excel', 'pdf', 'colvis']
	});

	$('#payrolllist').DataTable({
		dom: 'Bfrtip',
		lengthChange: false,
		buttons: ['copy', 'excel', 'pdf', 'colvis']
	});

	$('#alltickets').DataTable({
		dom: 'Bfrtip',
		lengthChange: false,
		buttons: ['copy', 'excel', 'pdf', 'colvis']
	});
});
