$(document).ready(function () {
    var menu_click = document.querySelector("#accordion_md_menu_header");
    var accordion_symbol = document.querySelector("#accordion_symbol");
    var accordion_menu = document.querySelector(".accordion_md_menu");
    menu_click.addEventListener("click", function () {
        accordion_symbol.classList.toggle("active");
        accordion_menu.classList.toggle("active");

    });




    var has_childrens = document.querySelectorAll(".has_children");

    has_childrens.forEach(has_children => {
        var has_children_click = has_children.querySelector(".has_children p");
        var accordion_nav_selection = has_children.querySelector(".accordion_nav_selection");
        var down_icon = has_children.querySelector("#down_icon");


        has_children_click.addEventListener("click", event => {
            accordion_nav_selection.classList.toggle("active");
            down_icon.classList.toggle("active");
        });

        var has_childrens_next_gen = accordion_nav_selection.querySelectorAll(".has_children_sec_gen");
        has_childrens_next_gen.forEach(has_children_next_gen => {
            var accordion_nav_selection_next_gen = has_children_next_gen.querySelector(".accordion_nav_selection_sec_gen");
            var has_childrens_next_gen_click = has_children_next_gen.querySelector(".has_children_sec_gen p");
            var has_childrens_next_gen_down_icon = has_children_next_gen.querySelector(".has_children_sec_gen i");
            has_childrens_next_gen_click.addEventListener("click", event => {
                accordion_nav_selection_next_gen.classList.toggle("active");
                has_childrens_next_gen_down_icon.classList.toggle("active");
            })
        })

    })





    $('.recently_viewed_container .owl-carousel').owlCarousel(
        {
            autoplay: true,
            loop: true,
            nav: false,
            dots: false,
            responsive: {
                0: {
                    items: 1
                },
                575: { items: 2 },
                767: { items: 3 },
                991: { items: 4 },
                1199: { items: 6 }
            }
        }
    );

    if ($('.recently_viewed_nav i:first-child').length) {

        var prev_viewed = $('.recently_viewed_nav i:first-child');
        prev_viewed.on('click', function () {
            $('.recently_viewed_container .owl-carousel').trigger('prev.owl.carousel');
        });
    }
    if ($('.recently_viewed_nav i:nth-child(2)').length) {

        var prev_viewed = $('.recently_viewed_nav i:nth-child(2)');
        prev_viewed.on('click', function () {
            $('.recently_viewed_container .owl-carousel').trigger('next.owl.carousel');
        });
    }


    $('.brands_container .owl-carousel').owlCarousel({
        autoplay: true,
        loop: true,
        nav: false,
        dots: false,
        responsive: {
            0: { items: 1 },
            400: { items: 2 },
            575: { items: 3 },
            767: { items: 4 },
            991: { items: 5 },
            1199: { items: 6 }
        }
    });

    if ($('.brands_left i:first-child').length) {

        var prev_brand = $('.brands_left i');
        prev_brand.on('click', function () {

            $('.brands_container .owl-carousel').trigger('prev.owl.carousel');
        });
    }
    if ($('.brands_right i').length) {

        var next_brand = $('.brands_right i');
        next_brand.on('click', function () {

            $('.brands_container .owl-carousel').trigger('next.owl.carousel');
        });
    }

    var product_photos = document.querySelectorAll(".product-photo");
    var selected_image = document.querySelector("#selected-image");
    product_photos.forEach(product_photo => {
        product_photo.addEventListener("click", function () {
            selected_image.querySelector("img").src = product_photo.querySelector("img").src
        })
    })

    var color_choices = document.querySelectorAll(".color-choice");
    var current_product_color = document.querySelector("#current-product-color");
    color_choices.forEach(color_choice => {
        color_choice.addEventListener("click", function () {
            current_product_color.querySelector("div").style.backgroundColor = color_choice.querySelector("div").style.backgroundColor;
        })
    })





    var menu_click = document.querySelector("#accordion_md_menu_header");
    var accordion_symbol = document.querySelector("#accordion_symbol");
    var accordion_menu = document.querySelector(".accordion_md_menu");
    menu_click.addEventListener("click", function () {
        accordion_symbol.classList.toggle("active");
        accordion_menu.classList.toggle("active");

    });




    var has_childrens = document.querySelectorAll(".has_children");

    has_childrens.forEach(has_children => {
        var has_children_click = has_children.querySelector(".has_children p");
        var accordion_nav_selection = has_children.querySelector(".accordion_nav_selection");
        var down_icon = has_children.querySelector("#down_icon");


        has_children_click.addEventListener("click", event => {
            accordion_nav_selection.classList.toggle("active");
            down_icon.classList.toggle("active");
        });

        var has_childrens_next_gen = accordion_nav_selection.querySelectorAll(".has_children_sec_gen");
        has_childrens_next_gen.forEach(has_children_next_gen => {
            var accordion_nav_selection_next_gen = has_children_next_gen.querySelector(".accordion_nav_selection_sec_gen");
            var has_childrens_next_gen_click = has_children_next_gen.querySelector(".has_children_sec_gen p");
            var has_childrens_next_gen_down_icon = has_children_next_gen.querySelector(".has_children_sec_gen i");
            has_childrens_next_gen_click.addEventListener("click", event => {
                accordion_nav_selection_next_gen.classList.toggle("active");
                has_childrens_next_gen_down_icon.classList.toggle("active");
            })
        })

    })
});