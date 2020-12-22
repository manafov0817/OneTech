$(function() {
	'use strict';

	// myAwesomeDropzone is the html element ID
	Dropzone.options.myAwesomeDropzone = {
		paramName: "file", // The name that will be used to transfer the file
		maxFilesize: 100, // MB
		url: "https://httpstat.us/200",
		accept: function(file, done) {
			if (file.name == "justinbieber.jpg") {
				done("Naha, you don't.");
			} else {
				done();
			}
		}
	};

	// https://codepen.io/fuxy22/pen/pyYByO?editors=0010

	// You can set things globally like this
	// Dropzone.autoDiscover = false;
	//
	// Dropzone.options.myDropzone = {
	//     url: "https://httpstat.us/200"
	// };

	var previewNode = document.querySelector("#template");
	previewNode.id = "";
	var previewTemplate = previewNode.parentNode.innerHTML;
	previewNode
		.parentNode
		.removeChild(previewNode);

	var myDropzone = new Dropzone('.dz-wrapper', {
		url: "https://httpstat.us/200",
		parallelUploads: 20,
		maxFilesize: 1000, // Max filesize in MB
		previewTemplate: previewTemplate,
		previewsContainer: "#previews", // Preview container of preview template
		clickable: "#fileinput-button", // Upload trigger button
		accept: function(file, done) {
			if (file.name == "justinbieber.jpg") {
				done("Nah, you don't upload Justine Bieber pics.");
			} else {
				done();
			}
		}
	});

});

$('.dropify').dropify();
