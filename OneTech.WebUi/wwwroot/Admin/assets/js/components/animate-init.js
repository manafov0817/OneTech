$(document).ready(function() {

	function testAnim(x) {
		$('#animationSandbox')
			.removeClass()
			.addClass(x + ' animated')
			.one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function() {
				$(this).removeClass();
			});
	};

	$('.js--triggerAnimation').click(function(e) {
		e.preventDefault();
		var anim = $('.js--animations').val();
		testAnim(anim);
	});

	$('.js--animations').change(function() {
		var anim = $(this).val();
		testAnim(anim);
	});

	$(".btn-animate").on("click", function(n) {
		$(".animate-this").attr("class", "animate-this  " + $(this).data("type") + "  animated");
	});

	$('h6:first').on('click', function(e) {
		$(this).addClass('swing');
	});

});
