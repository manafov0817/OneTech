// Summernote initialization
$('#summernote').summernote({placeholder: 'Hello from Summernote', tabsize: 2, height: 100});
$('#summernoteAirmode').summernote({placeholder: 'Hello from Summernote airMode', tabsize: 2, height: 100, airMode: true});

// Quill editor initialization
var quillEditor = new Quill('#quillEditor', {theme: 'snow'});
var quillButtle = new Quill('#quillBubble', {theme: 'bubble'});

// Quill with detailed params
var quillStandard = new Quill("#quillStandard", {
	modules: {
		toolbar: [
			[
				"bold", "italic", "underline", "strike"
			],
			[
				"blockquote", "code-block"
			],
			[
				{
					header: 1
				}, {
					header: 2
				}
			],
			[
				{
					list: "ordered"
				}, {
					list: "bullet"
				}
			],
			[
				{
					script: "sub"
				}, {
					script: "super"
				}
			],
			[
				{
					indent: "-1"
				}, {
					indent: "+1"
				}
			],
			[
				{
					direction: "rtl"
				}
			],
			[
				{
					size: [
						"small", !1,
						"large",
						"huge"
					]
				}
			],
			[
				{
					header: [
						1,
						2,
						3,
						4,
						5,
						6,
						!1
					]
				}
			],
			[
				{
					color: []
				}, {
					background: []
				}
			],
			[
				{
					font: []
				}
			],
			[
				{
					align: []
				}
			],
			["clean"]
		]
	},
	theme: "snow"
});
