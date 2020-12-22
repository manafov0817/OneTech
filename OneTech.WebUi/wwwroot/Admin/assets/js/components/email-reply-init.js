var quill = new Quill('#reply-box', {theme: 'snow'});

$('.mail-header').on('click', function(e) {
	if (!treeHasClass(e.target, "dropdown-parent", this)) { // params: intended-clicked-element, class-to-have, element-actually-clicked
		$(this)
			.parent('.mail-body')
			.toggleClass('mail-contracted');
	}
});

// To find if the cliked element is a dropdown child
function treeHasClass(elm, className, stopAtElm) {
	while (elm != null && elm != stopAtElm) {
		if (elm.classList.contains(className)) {
			return true;
		}
		elm = elm.parentNode;
	}
	return false;
}

// Mail compose cc Bcc
var cc = $('.cc-btn'),
	bcc = $('.bcc-btn'),
	ccClose = $('.cc-close'),
	bccClose = $('.bcc-close');

cc.on('click', function() {
	$('.cc-wrapper').css('display', 'flex');
});
ccClose.on('click', function() {
	$('.cc-wrapper').css('display', 'none');
});

bcc.on('click', function() {
	$('.bcc-wrapper').css('display', 'flex');
});
bccClose.on('click', function() {
	$('.bcc-wrapper').css('display', 'none');
});

var inputEmail = document.querySelector('input[name=emailAddress]');
var inputCc = document.querySelector('input[name=ccAddress]');
var inputBcc = document.querySelector('input[name=bccAddress]');

// init Tagify script on the email address input
tagifyEmail = new Tagify(inputEmail, {
	blacklist: [
		".NET", "PHP"
	],
	dropdown: {
		classname: "basicDropdown"
	},
	delimiters: ", ",
	maxTags: 10,
	whitelist: [
		{
			value: 'David Wong',
			email: 'david@dwong.com',
			pic: './assets/images/user/thumb/user-thumb-1.png',
			class: 'tagify__tag--brand'
		}, {
			value: 'Nedar Rosh',
			email: 'nedar@example.com',
			pic: './assets/images/user/thumb/user-thumb-2.png'
		}, {
			value: 'Miss Rangitas',
			email: 'rangitas@missrang.com',
			pic: './assets/images/user/thumb/user-thumb-3.png'
		}, {
			value: 'Weibo Ringo',
			email: 'weibo@example.com',
			pic: './assets/images/user/thumb/user-thumb-4.png'
		}, {
			value: 'Margarita Schneider',
			email: 'schneider@gmail.com',
			pic: './assets/images/user/thumb/user-thumb-5.png'
		}
	],
	templates: {
		dropdownItem: function(tagData) {
			try {
				var html = '';

				html += '<div class="tagify__dropdown__item" style="cursor: pointer;">';
				html += '   <div class="media pdn-x-7 pdn-y-10">';
				html += '       <img src="' + tagData.pic + '" class="wth-45 rounded mgn-r-10" alt="receiver image">';
				html += '       <div class="media-body">';
				html += '             <h5 class="mgn-b-0 txt-14">' + tagData.value + '</h5>';
				html += '             <p class="txt-12 mgn-b-0 text-muted">' + tagData.email + '</p>';
				html += '         </div>';
				html += '   </div>';
				html += '</div>';

				return html;
			} catch (err) {}
		}
	},
	transformTag: function(tagData) {
		tagData.class = 'tagify__tag tagify__tag--brand';
	},
	dropdown: {
		classname: "tagify-item",
		enabled: 1
	}
})

// init Tagify script on the Cc address input
tagifyCc = new Tagify(inputCc, {
	blacklist: [
		".NET", "PHP"
	],
	dropdown: {
		classname: "basicDropdown"
	},
	delimiters: ", ",
	maxTags: 10,
	whitelist: [
		{
			value: 'David Wong',
			email: 'david@dwong.com',
			pic: './assets/images/user/thumb/user-thumb-8.png',
			class: 'tagify__tag--brand'
		}, {
			value: 'Nedar Rosh',
			email: 'nedar@example.com',
			pic: './assets/images/user/thumb/user-thumb-3.png'
		}, {
			value: 'Miss Rangitas',
			email: 'rangitas@missrang.com',
			pic: './assets/images/user/thumb/user-thumb-9.png'
		}, {
			value: 'Weibo Ringo',
			email: 'weibo@example.com',
			pic: './assets/images/user/thumb/user-thumb-4.png'
		}, {
			value: 'Margarita Schneider',
			email: 'schneider@gmail.com',
			pic: './assets/images/user/thumb/user-thumb-6.png'
		}
	],
	templates: {
		dropdownItem: function(tagData) {
			try {
				var html = '';

				html += '<div class="tagify__dropdown__item" style="cursor: pointer;">';
				html += '   <div class="media pdn-x-7 pdn-y-10">';
				html += '       <img src="' + tagData.pic + '" class="wth-45 rounded mgn-r-10" alt="receiver image">';
				html += '       <div class="media-body">';
				html += '             <h5 class="mgn-b-0 txt-14">' + tagData.value + '</h5>';
				html += '             <p class="txt-12 mgn-b-0 text-muted">' + tagData.email + '</p>';
				html += '         </div>';
				html += '   </div>';
				html += '</div>';

				return html;
			} catch (err) {}
		}
	},
	transformTag: function(tagData) {
		tagData.class = 'tagify__tag tagify__tag--brand';
	},
	dropdown: {
		classname: "tagify-item",
		enabled: 1
	}
})

// init Tagify script on the Bcc address input
tagifyBcc = new Tagify(inputBcc, {
	blacklist: [
		".NET", "PHP"
	],
	dropdown: {
		classname: "basicDropdown"
	},
	delimiters: ", ",
	maxTags: 10,
	whitelist: [
		{
			value: 'David Wong',
			email: 'david@dwong.com',
			pic: './assets/images/user/thumb/user-thumb-10.png',
			class: 'tagify__tag--brand'
		}, {
			value: 'Nedar Rosh',
			email: 'nedar@example.com',
			pic: './assets/images/user/thumb/user-thumb-9.png'
		}, {
			value: 'Miss Rangitas',
			email: 'rangitas@missrang.com',
			pic: './assets/images/user/thumb/user-thumb-8.png'
		}, {
			value: 'Weibo Ringo',
			email: 'weibo@example.com',
			pic: './assets/images/user/thumb/user-thumb-7.png'
		}, {
			value: 'Margarita Schneider',
			email: 'schneider@gmail.com',
			pic: './assets/images/user/thumb/user-thumb-7.png'
		}
	],
	templates: {
		dropdownItem: function(tagData) {
			try {
				var html = '';

				html += '<div class="tagify__dropdown__item" style="cursor: pointer;">';
				html += '   <div class="media pdn-x-7 pdn-y-10">';
				html += '       <img src="' + tagData.pic + '" class="wth-45 rounded mgn-r-10" alt="receiver image">';
				html += '       <div class="media-body">';
				html += '             <h5 class="mgn-b-0 txt-14">' + tagData.value + '</h5>';
				html += '             <p class="txt-12 mgn-b-0 text-muted">' + tagData.email + '</p>';
				html += '         </div>';
				html += '   </div>';
				html += '</div>';

				return html;
			} catch (err) {}
		}
	},
	transformTag: function(tagData) {
		tagData.class = 'tagify__tag tagify__tag--brand';
	},
	dropdown: {
		classname: "tagify-item",
		enabled: 1
	}
});

// Tagify event listeners for the email address input field which can be used for callbacks
tagifyEmail
	.on('add', onAddTag)
	.on('remove', onRemoveTag)
	.on('input', onInput)
	.on('edit', onTagEdit)
	.on('invalid', onInvalidTag)
	.on('click', onTagClick)
	.on('dropdown:show', onDropdownShow)
	.on('dropdown:hide', onDropdownHide)

// tag added callback
function onAddTag(e) {}

// tag remvoed callback
function onRemoveTag(e) {}

// on character(s) added/removed
function onInput(e) {}

// tag edited callback
function onTagEdit(e) {}

// invalid tag added callback
function onInvalidTag(e) {}

// invalid tag added callback
function onTagClick(e) {}

// self-explanatory
function onDropdownShow(e) {}

// self-explanatory
function onDropdownHide(e) {}

// Dropzone custom container to show uploaded file
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
