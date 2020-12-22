$(function() {
	'use strict';

	// Basic search and autocomplete
	var availableTags = [
		"ActionScript",
		"AppleScript",
		"Asp",
		"BASIC",
		"C",
		"C++",
		"Clojure",
		"COBOL",
		"ColdFusion",
		"Erlang",
		"Fortran",
		"Groovy",
		"Haskell",
		"Java",
		"JavaScript",
		"Lisp",
		"Perl",
		"PHP",
		"Python",
		"Ruby",
		"Scala",
		"Scheme"
	];
	$("#tags").autocomplete({source: availableTags});

	// Normalize and complete names with special characters
	var names = ["Jörn Zaefferer", "Scott González", "John Resig"];
	// Map the characters equivalent to the special ones
	var accentMap = {
		"á": "a",
		"ö": "o"
	};
	// Normalize them
	var normalize = function(term) {
		var ret = "";
		for (var i = 0; i < term.length; i++) {
			ret += accentMap[term.charAt(i)] || term.charAt(i);
		}
		return ret;
	};
	// Search and match strings to autocomplete
	$("#developer").autocomplete({
		source: function(request, response) {
			var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
			response($.grep(names, function(value) {
				value = value.label || value.value || value;
				return matcher.test(value) || matcher.test(normalize(value));
			}));
		}
	});

	// Add custom dropdown list with custom items
	// Here we create the top items based on search string match with 'data'-label
	// Any matched strings based on 'data'-category will be appended below it with selectable 'data'-labels
	$.widget("custom.catcomplete", $.ui.autocomplete, {
		_create: function() {
			this._super();
			this
				.widget()
				.menu("option", "items", "> :not(.ui-autocomplete-category)");
		},
		_renderMenu: function(ul, items) {
			var that = this,
				currentCategory = "";
			$.each(items, function(index, item) {
				var li;
				if (item.category != currentCategory) {
					ul.append("<li class='ui-autocomplete-category'>" + item.category + "</li>");
					currentCategory = item.category;
				}
				li = that._renderItemData(ul, item);
				if (item.category) {
					li.attr("aria-label", item.category + " : " + item.label);
				}
			});
		}
	});

	var data = [
		{
			label: "anders",
			category: ""
		}, {
			label: "andreas",
			category: ""
		}, {
			label: "antal",
			category: ""
		}, {
			label: "annhhx10",
			category: "Products"
		}, {
			label: "annk K12",
			category: "Products"
		}, {
			label: "annttop C13",
			category: "Products"
		}, {
			label: "anders andersson",
			category: "People"
		}, {
			label: "andreas andersson",
			category: "People"
		}, {
			label: "andreas johnson",
			category: "People"
		}
	];
	// Search with strings and select from dropdown
	// Based on 'data' provided
	$("#search").catcomplete({delay: 0, source: data});

	// Select multiple items
	var availableTags = [
		"ActionScript",
		"AppleScript",
		"Asp",
		"BASIC",
		"C",
		"C++",
		"Clojure",
		"COBOL",
		"ColdFusion",
		"Erlang",
		"Fortran",
		"Groovy",
		"Haskell",
		"Java",
		"JavaScript",
		"Lisp",
		"Perl",
		"PHP",
		"Python",
		"Ruby",
		"Scala",
		"Scheme"
	];
	function split(val) {
		return val.split(/,\s*/);
	}
	function extractLast(term) {
		return split(term).pop();
	}
	$("#multiples")
	// Don't navigate away from the field on tab when selecting an item
		.on("keydown", function(event) {
			if (event.keyCode === $.ui.keyCode.TAB && $(this).autocomplete("instance").menu.active) {
				event.preventDefault();
			}
		})
		.autocomplete({
			minLength: 0,
			source: function(request, response) {
				// delegate back to autocomplete, but extract the last term
				response($.ui.autocomplete.filter(availableTags, extractLast(request.term)));
			},
			focus: function() {
				// prevent value inserted on focus
				return false;
			},
			select: function(event, ui) {
				var terms = split(this.value);
				// remove the current input
				terms.pop();
				// add the selected item
				terms.push(ui.item.value);
				// add placeholder to get the comma-and-space at the end
				terms.push("");
				this.value = terms.join(", ");
				return false;
			}
		});

	// Autofill other inputs based on autocomplete string selection
	var availableTags = [
		"ActionScript",
		"AppleScript",
		"Asp",
		"BASIC",
		"C",
		"C++",
		"Clojure",
		"COBOL",
		"ColdFusion",
		"Erlang",
		"Fortran",
		"Groovy",
		"Haskell",
		"Java",
		"JavaScript",
		"Lisp",
		"Perl",
		"PHP",
		"Python",
		"Ruby",
		"Scala",
		"Scheme"
	];
	$("#autofill").autocomplete({
		source: availableTags,
		select: function(event, ui) {
			// Set selection
			$('#id').val('01'); // display the selected text
			$('#name').val('Php'); // display the selected text
			$('#contact').val('865944586'); // display the selected text
			return false;
		}
	});

});
