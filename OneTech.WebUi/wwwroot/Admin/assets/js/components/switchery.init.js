$(function() {
	'use strict';

	var primary = Array
		.prototype
		.slice
		.call(document.querySelectorAll('.switch-primary'));
	var secondary = Array
		.prototype
		.slice
		.call(document.querySelectorAll('.switch-secondary'));
	var success = Array
		.prototype
		.slice
		.call(document.querySelectorAll('.switch-success'));
	var danger = Array
		.prototype
		.slice
		.call(document.querySelectorAll('.switch-danger'));
	var warning = Array
		.prototype
		.slice
		.call(document.querySelectorAll('.switch-warning'));
	var info = Array
		.prototype
		.slice
		.call(document.querySelectorAll('.switch-info'));
	var large = Array
		.prototype
		.slice
		.call(document.querySelectorAll('.switch-large'));
	var small = Array
		.prototype
		.slice
		.call(document.querySelectorAll('.switch-small'));

	// Colored
	primary.forEach(function(html) {
		var switchery = new Switchery(html, {
			color: '#746cda',
			secondaryColor: '#f1f1f5',
			size: 'small'
		});
	});

	secondary.forEach(function(html) {
		var switchery = new Switchery(html, {
			color: '#6582b7',
			secondaryColor: '#f1f1f5',
			size: 'small'
		});
	});

	success.forEach(function(html) {
		var switchery = new Switchery(html, {
			color: '#2fbfa0',
			secondaryColor: '#f1f1f5',
			size: 'small'
		});
	});

	danger.forEach(function(html) {
		var switchery = new Switchery(html, {
			color: '#ec4863',
			secondaryColor: '#f1f1f5',
			size: 'small'
		});
	});

	warning.forEach(function(html) {
		var switchery = new Switchery(html, {
			color: '#f9d054',
			secondaryColor: '#f1f1f5',
			size: 'small'
		});
	});

	info.forEach(function(html) {
		var switchery = new Switchery(html, {
			color: '#64afff',
			secondaryColor: '#f1f1f5',
			size: 'small'
		});
	});

	// Sizing
	large.forEach(function(html) {
		var switchery = new Switchery(html, {
			color: '#64afff',
			secondaryColor: '#f1f1f5',
			size: 'large'
		});
	});

	small.forEach(function(html) {
		var switchery = new Switchery(html, {
			color: '#64afff',
			secondaryColor: '#f1f1f5',
			size: 'small'
		});
	});

});
