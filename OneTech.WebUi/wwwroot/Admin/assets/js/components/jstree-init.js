$(function() {
	$('#jstree_demo_div').jstree();

	$("#checkbox-plugin").jstree({
		"checkbox": {
			"keep_selected_style": false
		},
		"plugins": ["checkbox"]
	});

	$("#contextmenu-plugin").jstree({
		"core": {
			"check_callback": true
		},
		"plugins": ["contextmenu"]
	});
});
