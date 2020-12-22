$(function() {
	'use strict';

	// Datepickers
	$('.datepicker').datepicker({startDate: "11/05/2011", endDate: "11/05/2100"});

	$('.datepicker-format1').datepicker({orientation: "bottom left", format: "dd/mm/yyyy"});

	$('.datepicker-format2').datepicker({format: "dd-mm-yyyy"});

	$('.fixed-datepicker').datepicker({startDate: "11/05/2011", endDate: "11/05/2100"});

	$('.highlighted-datepicker').datepicker({daysOfWeekHighlighted: "0", todayHighlight: true});

	$('.autoclose-datepicker').datepicker({daysOfWeekHighlighted: "0,1", autoclose: true});

	$('.calender-weeks').datepicker({calendarWeeks: true});

	$('.input-group.date').datepicker({});

	$('.input-daterange').datepicker({});

	$('.embeded div').datepicker({todayHighlight: true});

	// Time pickers
	$('.clockpicker').clockpicker({donetext: 'Done', placement: 'top'});
	$('.autoclose').clockpicker({placement: 'top'});

	// Color pickers
	$('#cp1').colorpicker();
	$('#cp2').colorpicker();
	$('#cp3').colorpicker({color: '#AA3399', format: 'rgb'});
	$('#cp4')
		.colorpicker()
		.on('changeColor', function(e) {
			$('body')[0].style.backgroundColor = e
				.color
				.toString('rgba');
		});
	$('#cp5').colorpicker({color: "transparent", format: "hex"});
	$('#cp8').colorpicker({
		colorSelectors: {
			'black': '#000000',
			'white': '#ffffff',
			'red': '#FF0000',
			'default': '#777777',
			'primary': '#337ab7',
			'success': '#5cb85c',
			'info': '#5bc0de',
			'warning': '#f0ad4e',
			'danger': '#d9534f'
		}
	});
});
