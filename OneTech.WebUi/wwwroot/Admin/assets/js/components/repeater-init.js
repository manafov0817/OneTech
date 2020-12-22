$(document).ready(function() {

	$(".repeater-default").repeater();

	$(".repeater-custom").repeater({
		show: function() {
			$(this).slideDown()
		},
		hide: function(e) {
			confirm("Delete?") && $(this).slideUp();
		}
	});

});
