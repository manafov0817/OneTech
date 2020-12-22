// Jqvmap initialize
jQuery('#vmapWorld').vectorMap({
	map: 'world_en',
	backgroundColor: '#fff',
	color: '#ffffff',
	hoverOpacity: 0.7,
	selectedColor: '#666666',
	enableZoom: false,
	showTooltip: true,
	values: sample_data,
	scaleColors: [
		'#C8EEFF', '#006491'
	],
	normalizeFunction: 'polynomial'
});

jQuery('#vmapWorldZoomable').vectorMap({
	map: 'world_en',
	backgroundColor: '#fff',
	color: '#ffffff',
	hoverOpacity: 0.7,
	selectedColor: '#666666',
	enableZoom: true,
	showTooltip: true,
	values: sample_data,
	scaleColors: [
		'#C8EEFF', '#006491'
	],
	normalizeFunction: 'polynomial'
});

jQuery('#vmapCountryClickable').vectorMap({
	map: 'usa_en',
	backgroundColor: null,
	color: '#ffffff',
	enableZoom: true,
	showTooltip: true,
	selectedColor: null,
	hoverColor: null,
	colors: {
		mo: '#2980b9',
		fl: '#27ae60',
		or: '#8e44ad'
	},
	onRegionClick: function(event, code, region) {
		event.preventDefault();
		console.log(region);
	}
});

jQuery('#vmapCountry').vectorMap({
	map: 'usa_en',
	backgroundColor: '#fff',
	color: '#ffffff',
	hoverOpacity: 0.7,
	selectedColor: '#666666',
	enableZoom: false,
	showTooltip: true,
	values: sample_data,
	scaleColors: [
		'#C8EEFF', '#006491'
	],
	normalizeFunction: 'polynomial'
});

$('#mapSelectedRegion').vectorMap({
	map: 'usa_en',
	backgroundColor: '#fff',
	borderColor: '#fff',
	color: '#8392a5',
	selectedColor: null,
	hoverColor: null,
	hoverOpacity: 0.8,
	enableZoom: false,
	showTooltip: true,
	selectedColor: '#0168fa',
	selectedRegions: [
		'CA', 'TX', 'MO', 'CO'
	],
	multiSelectRegion: true
});
