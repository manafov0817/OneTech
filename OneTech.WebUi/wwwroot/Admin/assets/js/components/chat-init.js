(function() {

	// Scroll initialization
	var psChatContact = new PerfectScrollbar('.chat-contact-list', {
		suppressScrollX: true,
		wheelPropagation: true
	});

	// Scroll initialization
	var psMessageGroup = new PerfectScrollbar('.message-group', {
		suppressScrollX: true,
		wheelPropagation: true
	});

	// Scroll initialization
	var psMessageGroup = new PerfectScrollbar('.chat-content', {
		suppressScrollX: true,
		wheelPropagation: false
	});

	// File upload with dropzone
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

	// Drop chat-pop-window body down
	$('#live-chat header').on('click', function() {
		$('.chat-toggle').toggleClass('active');
	});

	// Close chat-pop-window
	$('.close-window').on('click', function(e) {
		e.preventDefault();
		$('#live-chat').fadeOut(300);
	});

	// Send message notification sample
	$('#send-message').keypress(function(event) {
		var messageText = $('#send-message').val();
		var keycode = (
			event.keyCode
			? event.keyCode
			: event.which);
		if (keycode == '13') {
			if (messageText.length == 0) {
				alert('Write something!');
			} else {
				alert('Message sent.');
			}
		}
	});

})();
