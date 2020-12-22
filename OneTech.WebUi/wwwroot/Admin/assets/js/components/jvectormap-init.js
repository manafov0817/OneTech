$(function() {

	// jVectormap initialization
	$('#map').vectorMap({
		map: 'world_mill', // add the map object
		backgroundColor: 'transparent',
		strokeWidth: 0,
		zoomOnScroll: false,
		regionStyle: {
			initial: {
				fill: '#fff',
				"fill-opacity": 1,
				stroke: 'rgba(153, 102, 255, 0.5)',
				"stroke-width": 1,
				"stroke-opacity": .4
			},
			hover: {
				fill: 'rgba(153, 102, 255, 0.5)',
				"fill-opacity": 0.8,
				cursor: 'pointer'
			},
			selected: {
				fill: 'yellow'
			},
			selectedHover: {}
		},
		markerStyle: {
			initial: {
				fill: '#fff',
				stroke: 'red',
				'fill-opacity': 1,
				'stroke-width': 8,
				'stroke-opacity': 0.3,
				'cursor': 'pointer',
				r: 5
			},
			hover: {
				r: 8,
				stroke: 'info',
				'stroke-width': 10
			}
		},
		series: {
			regions: [
				{
					values: {
						"CA": 'rgba(54, 162, 235, 0.5)',
						"US": 'rgba(75, 192, 192, 0.5)',
						"RU": 'rgba(153, 102, 255, 0.5)',
						"GB": 'rgba(255, 99, 132, 0.5)',
						"ES": 'rgba(54, 162, 235, 0.5)',
						"FR": 'rgba(153, 102, 255, 0.5)',
						"DE": 'rgba(255, 99, 132, 0.5)',
						"AU": 'rgba(255, 99, 132, 0.5)'
					},
					attribute: 'fill'
				}
			]
		},
		markers: [
			{
				latLng: [
					37.09024, -95.712891
				],
				name: "USA",
				style: {
					fill: "#f93b7a"
				}
			}, {
				latLng: [
					71.70694, -42.604301
				],
				name: "Greenland",
				style: {
					fill: "#f0961f"
				}
			}, {
				latLng: [
					-21.943369, 123.102198
				],
				name: "Australia",
				style: {
					fill: "#5766da"
				}
			}, {
				latLng: [
					40.43, -74.00
				],
				name: "New York City",
				style: {
					fill: "#f0961f"
				}
			}
		]
	});
});
