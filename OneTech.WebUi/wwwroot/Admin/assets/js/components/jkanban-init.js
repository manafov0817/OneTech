// Jkanban board
var KanbanTest = new jKanban({
	element: "#myKanban",
	gutter: "0",
	widthBoard: "100%",
	responsivePercentage: false,
	buttonContent: '+',
	click: function(el) {},
	buttonClick: function(el, boardId) {
		var formItem = document.createElement("form");
		formItem.setAttribute("class", "itemform");
		formItem.innerHTML = '<div class="form-group"><textarea class="form-control" rows="2" autofocus></textarea></div><div class="form-group"><button type="submit" class="btn btn-primary-soft pull-right">Submit</button><button type="button" id="CancelBtn" class="btn btn-default pull-right">Cancel</button></div>';

		KanbanTest.addForm(boardId, formItem);
		formItem.addEventListener("submit", function(e) {
			e.preventDefault();
			var text = e
				.target[0]
				.value;
			KanbanTest.addElement(boardId, {title: text});
			formItem
				.parentNode
				.removeChild(formItem);
		});
		document
			.getElementById("CancelBtn")
			.onclick = function() {
				formItem
					.parentNode
					.removeChild(formItem);
			};
	},
	addItemButton: true,
	boards: [
		{
			id: "_todo",
			title: "To Do (drag me)",
			class: "todos", // board header class
			dragTo: ["_working"],
			item: [
				{
					id: "dev_app",
					class: "todo-item", // kanban-item class
					title: "Develop the app",
					drag: function(el, source) {},
					dragend: function(el) {},
					drop: function(el) {}
				}, {
					title: "Click the item please",
					click: function(el) {
						alert("Clicked!");
					}
				}, {
					title: "Submit the proposal"
				}, {
					title: "Wait till she drops by"
				}
			]
		}, {
			id: "_working",
			title: "Ongoing",
			class: "warning",
			item: [
				{
					title: "Drop by the store to buy office supply"
				}, {
					title: "Design the logo"
				}, {
					title: "Meet the new client"
				}, {
					title: "Drop by mom's house"
				}, {
					title: "Set up a meeting"
				}, {
					title: "Pick up a printer"
				}
			]
		}, {
			id: "_done",
			title: "Done",
			class: "success",
			dragTo: ["_working"],
			item: [
				{
					title: "Website launch"
				}, {
					title: "Store staff recruitment"
				}
			]
		}
	]
});

// Add item with buton click
var toDoButton = document.getElementById("addToDo");
toDoButton.addEventListener("click", function() {
	KanbanTest.addElement("_todo", {title: "Test Add"});
});

// Add a board
var addBoardDefault = document.getElementById("addDefault");
addBoardDefault.addEventListener("click", function() {
	KanbanTest.addBoards([
		{
			id: "_default",
			title: "Kanban Default",
			item: [
				{
					title: "Default Item"
				}, {
					title: "Default Item 2"
				}, {
					title: "Default Item 3"
				}
			]
		}
	]);
});

// Remove a board
var removeBoard = document.getElementById("removeBoard");
removeBoard.addEventListener("click", function() {
	KanbanTest.removeBoard("_todo");
});

// Remove particular element
var removeElement = document.getElementById("removeElement");
removeElement.addEventListener("click", function() {
	KanbanTest.removeElement("dev_app");
});

// Get elements of a board
var allEle = KanbanTest.getBoardElements("_todo");
allEle.forEach(function(item, index) {
	//console.log(item);
});
