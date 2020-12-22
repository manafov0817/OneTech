$(document).ready(function() {

	// Simple initialization
	$(".sweetalert1").click(function() {
		swal("Hello world!");
	});

	$(".sweetalert2").click(function() {
		swal("Here's the title!", "...and here's the text!");
	});

	$(".sweetalert3").click(function() {
		swal("Good job!", "You clicked the button!", "success");
	});

	$(".sweetalert4").click(function() {
		swal({title: "Good job!", text: "You clicked the button!", icon: "success"});
	});

	//With custom feedback
	$(".sweetalert5").click(function() {
		swal({title: "Good job!", text: "You clicked the button!", icon: "success", button: "Aww yiss!"});
	});

	$(".sweetalert6").click(function() {
		swal("Good job!", "You clicked the button!", "success", {button: "Aww yiss!"});
	});

	$(".sweetalert7").click(function() {
		swal("Click on either the button or outside the modal.").then((value) => {
			swal(`The returned value is: ${value}`);
		});
	});

	//Delete and recall
	$(".sweetalert8").click(function() {
		swal({title: "Are you sure?", text: "Once deleted, you will not be able to recover this imaginary file!", icon: "warning", buttons: true, dangerMode: true}).then((willDelete) => {
			if (willDelete) {
				swal("Poof! Your imaginary file has been deleted!", {icon: "success"});
			} else {
				swal("Your imaginary file is safe!");
			}
		});
	});

	// Permission
	$(".sweetalert9").click(function() {
		swal("Are you sure you want to do this?", {
			buttons: ["Oh noez!", "Aww yiss!"]
		});
	});

	// Promise
	$(".sweetalert10").click(function() {
		swal("A wild Pikachu appeared! What do you want to do?", {
			buttons: {
				cancel: "Run away!", catch  : {
					text : "Throw Pokéball!",
					value: "catch"
				},
				defeat: true
			}
		}).then((value) => {
			switch (value) {

				case "defeat":
					swal("Pikachu fainted! You gained 500 XP!");
					break;

				case "catch":
					swal("Gotcha!", "Pikachu was caught!", "success");
					break;

				default:
					swal("Got away safely!");
			}
		});
	});

	// Input
	$(".sweetalert11").click(function() {
		swal({
			text: 'Search for a movie. e.g. "La La Land".',
			content: "input",
			button: {
				text: "Search!",
				closeModal: false
			}
		})
			.then(name => {
				if (!name) 
					throw null;
				
				return fetch(`https://itunes.apple.com/search?term=${name}&entity=movie`);
			})
			.then(results => {
				return results.json();
			})
			.then(json => {
				const movie = json.results[0];

				if (!movie) {
					return swal("No movie was found!");
				}

				const name = movie.trackName;
				const imageURL = movie.artworkUrl100;

				swal({title: "Top result:", text: name, icon: imageURL});
			})
			.catch(err => {
				if (err) {
					swal("Oh noes!", "The AJAX request failed!", "error");
				} else {
					swal.stopLoading();
					swal.close();
				}
			});
	});
});
