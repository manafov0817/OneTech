$(function() {
	"use strict";

	/***
	Aside-specific scripts
	***/

	// Initialize aside scrollbar
	var psAside = new PerfectScrollbar('.aside-inner', {
		suppressScrollX: true,
		wheelPropagation: false
	});

	// Expanding dropdown on menu-dropdown click
	$('.aside-nav .has-submenu > a').on('click', function(e) {
		e.preventDefault();
		$(this)
			.closest('.has-submenu')
			.toggleClass('drop-down');
		psAside.update();
	});

	// Show collapsed aside on mouse-enter
	$('body').on('mouseenter', '.aside-wrapper.aside-minimized', function(e) {
		$(this).addClass('aside-display-full');
	});

	// Back to collapsed mode on mouse-leave
	$('body').on('mouseleave', '.aside-wrapper.aside-minimized', function(e) {
		$(this).removeClass('aside-display-full');
		psAside.update();
	});

	// Minimize aside based on screen-size
	if (matchMedia) {
		var mq = window.matchMedia("(min-width:992px) and (max-width: 1199px)");
		mq.addListener(activateMiniSidebar);
		activateMiniSidebar(mq);
	}

	function activateMiniSidebar(mq) {
		if (mq.matches) {
			$(".aside-wrapper").addClass("aside-minimized");
		} else {
			$(".aside-wrapper").removeClass("aside-minimized");
		}
		psAside.update();
	}

	// Remove ID attr and add relevant class for vertical version
	$('#show-menubar')
		.addClass('switch-sidebar-mode')
		.removeAttr('id');

	// Switch aside collapsing on button-click
	$(".switch-sidebar-mode").on("click", function(e) {
		e.preventDefault();
		if (window.matchMedia("(min-width: 992px)").matches) {
			$(".aside-wrapper").toggleClass("aside-minimized");
		} else {
			$("#app").toggleClass("aside-display");
		}
		psAside.update();
	});
});
