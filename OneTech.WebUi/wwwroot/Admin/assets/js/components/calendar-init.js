$(function() {

	var defaultEvents = {
		backgroundColor: 'rgba(255, 255, 255, 0.1)',
		borderColor: '#565656',

		// Array of events
		events: [
			{
				title: 'Product release party',
				start: new Date($.now() + 506800000),
				guests: [
					'Albert Camus', 'Nietsche', 'Kate Klover'
				],
				location: '120 Cate Avenue, FL',
				details: 'Minima molestiae earum minus, alias dolor in suscipit voluptatibus nostrum mollitia assumenda eum illum explicabo modi?',
				className: 'text-white bg-success'
			}, {
				title: 'Concert of Dave Malmstein',
				start: today,
				end: today,
				guests: [
					'Hans Zimmer', 'Roberto Rodriguez', 'Dave Malmstein'
				],
				location: '23 Dover Street, CA',
				details: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente repudiandae, quo sit temporibus necessitatibus, sint obcaecati illo',
				className: 'text-white bg-warning'
			}, {
				title: 'Official tour to Rega Island, West Indies',
				start: new Date($.now() + 848000000),
				location: '23 Dover Street, CA',
				details: 'Quas dolore labore cupiditate soluta doloremque ad dolorem sunt accusamus vel ab est nemo autem fugiat, atque aliquam iure cumque, aliquid eius!',
				className: 'text-white bg-dark'
			}, {
				title: 'Meeting with David Copperfield',
				start: new Date($.now() - 1099000000),
				guests: [
					'David Copperfield', 'Raza Kiostori'
				],
				location: '430 George Lane, WA',
				details: 'Iste quasi alias tenetur et nulla omnis maiores enim similique, ratione voluptas obcaecati animi hic, voluptatibus beatae repellendus accusamus, totam ipsum. Atque?',
				end: new Date($.now() - 919000000),
				className: 'text-white bg-light'
			}, {
				title: 'Wedding ceremony of Reshizu and after party',
				start: new Date($.now() - 399000000),
				location: '11 Lincoln Street, NY',
				details: 'Unde voluptatibus velit, suscipit molestiae, sint enim pariatur mollitia iure harum necessitatibus voluptas nihil at magni. Quidem, nesciunt? Tempora, sequi natus nemo?',
				end: new Date($.now() - 219000000),
				className: 'text-white bg-primary'
			}, {
				title: 'Youth meetup at Ship Lake Convention Center',
				start: new Date($.now() + 868000000),
				location: 'Track Lane, CA',
				details: 'Laboriosam adipisci architecto, odit similique! Dolore, molestiae, nisi. Veniam voluptas inventore ut delectus pariatur blanditiis tempore asperiores, nobis magni perferendis animi sequi.',
				className: 'text-white bg-secondary'
			}
		]
	};

	var date = new Date();
	var d = date.getDate();
	var m = date.getMonth();
	var y = date.getFullYear();
	var form = '';
	var today = new Date($.now());
	var view_modal = $('#my-event');
	var create_modal = $('#add-new-event');

	// Initialize calendar
	var calendar = $('#calendar').fullCalendar({
		slotDuration: '00:15:00',
		// If we want to split day time each 15minutes
		minTime: '08:00:00',
		maxTime: '19:00:00',
		defaultView: 'month',
		handleWindowResize: true,
		views: {
			day: {
				columnHeader: false
			}
		},
		header: {
			left: 'prev,next today',
			center: 'title',
			right: 'month,agendaWeek,agendaDay,listWeek'
		},
		//events: ,
		eventSources: [defaultEvents],
		editable: true,
		droppable: true, // this allows things to be dropped onto the calendar, just add a list group and drag n drop
		eventLimit: true, // allow "more" link when too many events
		selectable: true,
		unselectAuto: true,
		navLinks: true,
		selectLongPressDelay: 100,
		nowIndicator: true,
		eventRender: function(event, element) {

			if (event.details) {
				element
					.find('.fc-list-item-title')
					.append('<div class="fc-details">' + event.details + '</div>');
				element
					.find('.fc-content')
					.append('<div class="fc-details">' + event.details + '</div>');
			}
		},
		select: function(start, end, allDay) { // When user selects a blank date

			create_modal.modal('show');
			var create_event_form = $('#add-new-event form');

			// Show the modal and create event
			create_event_form
				.find("input[name='start']")
				.val(start.format('LL'));
			create_event_form
				.find("input[name='end']")
				.val(end.format('LL'));

			$('.save-event').on('click', function() { // On save-event button click

				$(create_modal).on('hidden.bs.modal', function() { // Hide the modal, after resetting the fields
					$(this)
						.find('form')
						.trigger('reset');
				});

				// get the input values
				var title = create_event_form
						.find("input[name='event-title']")
						.val(),
					categoryClass = create_event_form
						.find("select[name='category'] option:checked")
						.val();

				// if not title given, alert else...
				if (title !== null && title.length != 0) {
					// Render the event to specific date
					calendar.fullCalendar('renderEvent', {
						title: title,
						start: start,
						end: end,
						allDay: false,
						className: categoryClass
					}, true);
				} else {
					alert('No title provided. Nothing to add.');
				}
				// Important to unbind as the clicks will accumulate
				$('.save-event').unbind();
				calendar.fullCalendar('unselect');
			});

			// Unbind on cancel click
			$('#cancel-event').on('click', function() {
				$('.save-event').unbind();
				calendar.fullCalendar('unselect');
			});
		},
		eventClick: function(calEvent, jsEvent, view) { // If an event is clicked, these params are provided by fullcalendar

			view_modal.modal('show'); // Show the modal with event info by calling in all the fields
			view_modal
				.find('.modal-title')
				.text(calEvent.title);

			if (calEvent.details && calEvent.details.length) { // If there are details, show it or hide the whole element
				view_modal
					.find('.details')
					.text(calEvent.details);
				// view_modal.find('.details').removeClass('d-none');
			} else {
				view_modal
					.find('.details')
					.text('No details found! Sorry.');
			}

			view_modal
				.find('.event-starts')
				.text(moment(calEvent.start).format('LLL')); // Format the dates and show

			calEvent.end = (calEvent.end)
				? moment(calEvent.end).format('LLL')
				: 'Ends today';
			view_modal
				.find('.event-ends span')
				.text(calEvent.end);

			view_modal
				.find('.event-location span')
				.text(calEvent.location);

			if (calEvent.details && calEvent.details.length) {
				view_modal
					.find('.event-location span')
					.text(calEvent.location);
			} else {
				view_modal
					.find('.event-location span')
					.text('N/A');
			}

			var guests = calEvent.guests;
			if (guests) {
				var guest_list = '';
				for (var i = 0; i < guests.length; i++) {
					guest_list += '<li class="list-group-item pdn-y-2 bdr-0"><i class="icon-badge"></i><span class="mgn-l-10">' + guests[i] + '</span></li>';
				}
				view_modal
					.find('.guests-list')
					.html(guest_list);
				view_modal
					.find('.guests')
					.removeClass('d-none');
			} else {
				view_modal
					.find('.guests')
					.addClass('d-none');
			}

			view_modal // Onclick of the delete button, delete the event
				.find('.delete_event')
				.on('click', function() {
					calendar.fullCalendar('removeEvents', function(ev) {
						return (ev._id == calEvent._id);
					});
				});
		}
	});
});
