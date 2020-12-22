$(function() {
	'use street';

	$("#addProduct").validate({
		rules: {
			productid: {
				required: true
			},
			product_sku: {
				required: true,
				minlength: 2
			},
			product_name: {
				required: true,
				minlength: 2
			},
			product_price: {
				required: true
			},
			selling_price: {
				required: true,
				number: true
			},
			discount_starts: {
				date: true
			},
			quantity: {
				required: true
			},
			barcode: {
				required: true
			},
			category: {
				required: true
			},
			product_image: {
				required: true,
				accept: "image/*"
			}
		}
	});

	$(".color-select2").select2();

	$(".size-select2").select2();

	$('.datepicker').datepicker({startDate: "11/05/2011", endDate: "11/05/2100"});

	$("#addCustomer").validate({
		rules: {
			customername: {
				required: true
			},
			customerid: {
				required: true
			},
			email: {
				required: true,
				email: true
			},
			contact: {
				required: true
			},
			dob: {
				date: true
			},
			customer_image: {
				required: true,
				accept: "image/*"
			}
		}
	});
})
