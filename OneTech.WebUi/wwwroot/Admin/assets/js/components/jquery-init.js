// Just calling the function and let validator take care of the rest
$(function() {
	$("#commentForm").validate({});
});

// Detailed customization with params
jQuery
	.validator
	.setDefaults({debug: true, success: "valid"});
$("#myform").validate({
	rules: {
		firstname: {
			required: true,
			minlength: 2
		},
		lastname: {
			required: true,
			minlength: 2
		},
		username: {
			required: true,
			range: [2, 23]
		},
		password: {
			required: true
		},
		confirmpasswords: {
			equalTo: "#password2",
			required: true
		},
		email: {
			required: true,
			email: true
		},
		date: {
			required: true,
			date: true
		},
		url: {
			required: true,
			url: true
		},
		city: {
			required: true,
			minlength: 2
		},
		state: {
			required: true,
			minlength: 2
		},
		zip: {
			required: true,
			minlength: 2
		},
		image: {
			required: true,
			accept: "image/*"
		}
	}
});
