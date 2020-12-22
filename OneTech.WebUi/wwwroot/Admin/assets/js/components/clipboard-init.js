var clipboard = new ClipboardJS(".btn-clipboard");

// Helpful to show user any feedback!
clipboard.on('success', function(e) {
	console.info('Action:', e.action);
	console.info('Text:', e.text);
	console.info('Trigger:', e.trigger);

	// To clear selection
	// e.clearSelection();
});

clipboard.on('error', function(e) {
	console.error('Action:', e.action);
	console.error('Trigger:', e.trigger);
});
