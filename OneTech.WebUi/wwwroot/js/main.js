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



    const slider = document.querySelector(".slider");
    const carousel = document.querySelector(".slider_carousel");

    const prev = document.querySelector(".prev");
    const next = document.querySelector(".next");

    var direction = -1;
    if (prev != null) {
        prev.addEventListener("click", function () {
            if (direction === -1) {
                slider.appendChild(slider.firstElementChild);
                direction = 1;
            }
            slider.style.transform = 'translate(20%)';
            carousel.style.justifyContent = "flex-end";
        });
    }
    if (next != null) {
        next.addEventListener("click", function () {
            direction = -1;
            slider.style.transform = 'translate(-20%)';
            carousel.style.justifyContent = "flex-start";
            if (direction === 1) {
                direction = -1;
                slider.prepend(slider.lastElementChild);
            }
        });
    }




    $('.fob .owl-carousel').owlCarousel({
        autoplay: true,
        loop: true,
        nav: false,
        dotsSpeed: 500,
        dots: true,
        slideTransition: 'ease',
        autoplayHoverPause: true,
        items: 2,
        slideBy: 2,
        lazyLoad: true,
        responsive: {
            576: {
                items: 3,
                slideBy: 3,
            },
            768: {
                items: 4,
                slideBy: 4,
            },
        }
    });

    if (document.querySelector(".fob") != null) {
        var items = document.querySelectorAll(".fob .item");
        items.forEach(item => {
            item.addEventListener("mouseenter", function () {
                document.querySelector(".fob .owl-dots").style.display = "none";
            })
            item.addEventListener("mouseleave", function () {
                document.querySelector(".fob .owl-dots").style.display = "block";
            })

        })



        var featured_button = document.querySelector(".featured_title")
        var on_sale_button = document.querySelector(".on_sale_title");
        var best_rated_button = document.querySelector(".best_rated_title")

        var featured_navs = document.querySelectorAll(".fob_nav li");
        featured_navs.forEach(featured_nav => {
            featured_nav.addEventListener("click", function () {
                for (const featured_nav of featured_navs) {
                    if (featured_nav.classList.contains("active")) {
                        featured_nav.classList.remove("active");
                    }
                }
                featured_nav.classList.add("active");


                var fob_containers = document.querySelectorAll(".fob_container");
                var fob_nav_line_inner = document.querySelector(".fob_nav_line_inner");
                if (featured_nav == featured_navs[0]) {
                    console.log("1");
                    for (const fob_container of fob_containers) {
                        if (fob_container.classList.contains("active")) {
                            fob_container.classList.remove("active");
                        }
                    }
                    fob_containers[0].classList.add("active");
                    fob_nav_line_inner.style.left = "0px";
                    fob_nav_line_inner.style.width = "79px";


                }
                else if (featured_nav == featured_navs[1]) {
                    for (const fob_container of fob_containers) {
                        if (fob_container.classList.contains("active")) {
                            fob_container.classList.remove("active");
                        }
                    }
                    fob_containers[1].classList.add("active");

                    fob_nav_line_inner.style.left = "134px";
                    fob_nav_line_inner.style.width = "64px";
                }
                else {
                    for (const fob_container of fob_containers) {
                        if (fob_container.classList.contains("active")) {
                            fob_container.classList.remove("active");
                        }
                    }
                    fob_containers[2].classList.add("active");

                    fob_nav_line_inner.style.left = "250px";
                    fob_nav_line_inner.style.width = "96px";
                }




            })
        })

    }











    var popular_categories_slider = document.querySelector(".popular_categories_slider");

    var popular_categories_slider_prev = document.querySelector(".popular_categories_controls_prev");
    var popular_categories_slider_next = document.querySelector(".popular_categories_controls_next");
    var sectionInde2 = 0;
    if (popular_categories_slider_prev != null) {
        popular_categories_slider_prev.addEventListener('click', function () {

            sectionInde2 = (sectionInde2 > 0) ? sectionInde2 - 1 : 0;
            popular_categories_slider.style.transform = 'translate(' + (sectionInde2) * -50 + '%)';
        });
    }
    if (popular_categories_slider_next != null) {
        popular_categories_slider_next.addEventListener('click', function () {

            sectionInde2 = (sectionInde2 < 1) ? sectionInde2 + 1 : 1;

            popular_categories_slider.style.transform = 'translate(' + (sectionInde2) * -50 + '%)';

        });
    }



    var offered_info_slider = document.querySelector(".offered_info_slider");
    var sectionIndex3 = 0;

    document.querySelectorAll(".offered_info_slider_controls li").forEach(function (indicator, ind) {

        indicator.addEventListener('click', function () {
            sectionIndex3 = ind;
            document.querySelector(".offered_info_slider_controls .selected").classList.remove("selected");
            indicator.classList.add("selected");
            offered_info_slider.style.transform = 'translate(' + (sectionIndex3) * -33.33 + '%)';

        })
    })




    var hot_new_arrivals_navigates = document.querySelectorAll(".hot_new_arrivals_navigates ul li");

    var hot_new_arrivals_containers = document.querySelectorAll(".hot_new_arrivals_container");
    if (hot_new_arrivals_navigates != null) {
        hot_new_arrivals_navigates.forEach(hot_new_arrivals_navigate => {
            hot_new_arrivals_navigate.addEventListener("click", function () {
                document.querySelector(".hot_new_arrivals_navigates ul .active").classList.remove("active");
                hot_new_arrivals_navigate.classList.add("active");
                if (hot_new_arrivals_navigate == hot_new_arrivals_navigates[0]) {
                    classList = document.querySelector(".hot_new_arrivals_nav_line span").classList;
                    while (classList.length > 0) {
                        classList.remove(classList.item(0));
                    }
                    document.querySelector(".hot_new_arrivals_nav_line span").classList.add("active1");
                    hot_new_arrivals_containers.forEach(hot_new_arrivals_container => {
                        classList = hot_new_arrivals_container.classList;
                        classList.remove("selected");
                    })
                    hot_new_arrivals_containers[0].classList.add("selected");



                } else if (hot_new_arrivals_navigate == hot_new_arrivals_navigates[1]) {
                    classList = document.querySelector(".hot_new_arrivals_nav_line span").classList;
                    while (classList.length > 0) {
                        classList.remove(classList.item(0));
                    }
                    document.querySelector(".hot_new_arrivals_nav_line span").classList.add("active2");
                    hot_new_arrivals_containers.forEach(hot_new_arrivals_container => {
                        classList = hot_new_arrivals_container.classList;
                        classList.remove("selected");
                    })
                    hot_new_arrivals_containers[1].classList.add("selected");

                    var sectionIndex4 = 0;
                    // test
                    var selected_hot_new_arrivals_container = document.querySelector(".hot_new_arrivals_container.selected");
                    var hot_new_arrivals_slider = selected_hot_new_arrivals_container.querySelector(".hot_new_arrivals_slider");
                    selected_hot_new_arrivals_container.addEventListener("click", function () {

                    })
                    // test


                    selected_hot_new_arrivals_container.querySelectorAll(".hot_new_arrivals_controls li").forEach(function (indicator, ind) {
                        indicator.addEventListener('click', function () {
                            sectionIndex4 = ind;
                            selected_hot_new_arrivals_container.querySelector(".hot_new_arrivals_controls .selected").classList.remove("selected");
                            indicator.classList.add("selected");

                            hot_new_arrivals_slider.style.transform = 'translate(' + (sectionIndex4) * -50 + '%)';
                        })
                    })





                } else {
                    classList = document.querySelector(".hot_new_arrivals_nav_line span").classList;
                    while (classList.length > 0) {
                        classList.remove(classList.item(0));
                    }

                    document.querySelector(".hot_new_arrivals_nav_line span").classList.add("active3");
                    hot_new_arrivals_containers.forEach(hot_new_arrivals_container => {
                        classList = hot_new_arrivals_container.classList;
                        classList.remove("selected");
                    })



                    hot_new_arrivals_containers[2].classList.add("selected");
                    var sectionIndex4 = 0;
                    // test
                    var selected_hot_new_arrivals_container = document.querySelector(".hot_new_arrivals_container.selected");
                    var hot_new_arrivals_slider = selected_hot_new_arrivals_container.querySelector(".hot_new_arrivals_slider");
                    selected_hot_new_arrivals_container.addEventListener("click", function () {

                    })
                    // test


                    selected_hot_new_arrivals_container.querySelectorAll(".hot_new_arrivals_controls li").forEach(function (indicator, ind) {
                        indicator.addEventListener('click', function () {
                            sectionIndex4 = ind;
                            selected_hot_new_arrivals_container.querySelector(".hot_new_arrivals_controls .selected").classList.remove("selected");
                            indicator.classList.add("selected");

                            hot_new_arrivals_slider.style.transform = 'translate(' + (sectionIndex4) * -50 + '%)';
                        })
                    })



                }
            })
        })
    }
    var sectionIndex4 = 0;
    // test
    var selected_hot_new_arrivals_container = document.querySelector(".hot_new_arrivals_container.selected");

    if (selected_hot_new_arrivals_container != null) {

        var hot_new_arrivals_slider = selected_hot_new_arrivals_container.querySelector(".hot_new_arrivals_slider");
        selected_hot_new_arrivals_container.addEventListener("click", function () {

        })


        selected_hot_new_arrivals_container.querySelectorAll(".hot_new_arrivals_controls li").forEach(function (indicator, ind) {
            indicator.addEventListener('click', function () {
                sectionIndex4 = ind;
                selected_hot_new_arrivals_container.querySelector(".hot_new_arrivals_controls .selected").classList.remove("selected");
                indicator.classList.add("selected");

                hot_new_arrivals_slider.style.transform = 'translate(' + (sectionIndex4) * -50 + '%)';
            })
        })

    }






    var hot_new_arrivals = document.querySelectorAll(".hot_new_arrival");
    hot_new_arrivals.forEach(hot_new_arrival => {
        hot_new_arrival.addEventListener("mouseover", function () {
            document.querySelectorAll(".hot_new_arrivals_controls")
                .forEach(hot_new_arrival_control => {
                    hot_new_arrival_control.style.display = "none";
                })
        });
        hot_new_arrival.addEventListener("mouseout", function () {
            document.querySelectorAll(".hot_new_arrivals_controls")
                .forEach(hot_new_arrival_control => {
                    hot_new_arrival_control.style.display = "block";
                })
        })
    })

    var hot_bestsellers_tab_navigations = document.querySelectorAll(".hot_bestsellers_tab_nav li");
    var hot_bestsellers_line = document.querySelector(".hot_bestsellers_line span");
    if (hot_bestsellers_line != null) {
        var hot_bestsellers_line_cl = hot_bestsellers_line.classList;
        var hot_bestsellers_main_containers = document.querySelectorAll(".hot_bestsellers_main_container");

    }
    hot_bestsellers_tab_navigations.forEach(hot_bestsellers_tab_navigation => {



        hot_bestsellers_tab_navigation.addEventListener("click", function () {


            if (hot_bestsellers_tab_navigation == hot_bestsellers_tab_navigations[0]) {
                classList = hot_bestsellers_line.classList;
                while (classList.length > 0) {
                    classList.remove(classList.item(0));
                }
                hot_bestsellers_line.classList.add("active1");
                document.querySelector(".hot_bestsellers_tab_nav .selected").classList.remove("selected")
                hot_bestsellers_tab_navigation.classList.add("selected");
                hot_bestsellers_main_containers.forEach(hot_bestsellers_main_container => {
                    hot_bestsellers_main_container.classList.remove("active");
                })
                hot_bestsellers_main_containers[0].classList.add("active")



            }
            else if (hot_bestsellers_tab_navigation == hot_bestsellers_tab_navigations[1]) {
                classList = hot_bestsellers_line.classList;
                while (classList.length > 0) {
                    classList.remove(classList.item(0));
                }
                hot_bestsellers_line.classList.add("active2");

                document.querySelector(".hot_bestsellers_tab_nav .selected").classList.remove("selected")
                hot_bestsellers_tab_navigation.classList.add("selected");

                hot_bestsellers_main_containers.forEach(hot_bestsellers_main_container => {
                    hot_bestsellers_main_container.classList.remove("active");
                })
                hot_bestsellers_main_containers[1].classList.add("active")



            }
            else {
                classList = hot_bestsellers_line.classList;
                while (classList.length > 0) {
                    classList.remove(classList.item(0));
                }
                hot_bestsellers_line.classList.add("active3");

                document.querySelector(".hot_bestsellers_tab_nav .selected").classList.remove("selected")
                hot_bestsellers_tab_navigation.classList.add("selected");

                hot_bestsellers_main_containers.forEach(hot_bestsellers_main_container => {
                    hot_bestsellers_main_container.classList.remove("active");
                })
                hot_bestsellers_main_containers[2].classList.add("active")
            }
        })
    });




    $('.hot_bestsellers_main_container .owl-carousel').owlCarousel({
        loop: true,
        autoplay: true,
        responsive: {
            250: {
                items: 1,
                slideBy: 1,
            },
            768: {
                items: 2,
                slideBy: 2,
            },
            992: {
                items: 3,
                slideBy: 3,
            },
        }
    });



    var trendsSlider = $('.trends_slider .owl-carousel');
    $('.trends_slider .owl-carousel').owlCarousel(
        {
            loop: false,
            margin: 30,
            nav: false,
            dots: false,
            autoplayHoverPause: true,
            autoplay: false,
            responsive: {
                0: { items: 1 },
                575: { items: 2 },
                991: { items: 3 }
            }
        }
    );
    if ($('.trend_navs .prev').length) {

        var prev_trend = $('.trend_navs .prev');
        prev_trend.on('click', function () {
            trendsSlider.trigger('prev.owl.carousel');
        });
    }
    if ($('.trend_navs .next').length) {
        var next_trend = $('.trend_navs .next');
        next_trend.on('click', function () {
            trendsSlider.trigger('next.owl.carousel');
        });
    };





    $('.latest_reviews_container .owl-carousel').owlCarousel({
        responsive: {
            0: {
                items: 1,
                dots: false
            },
            767: {
                items: 2,
                dots: true
            },
            991: { items: 3 }
        }
    })




    $('.recently_viewed_container .owl-carousel').owlCarousel(
        {
            autoplay: false,
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



    $('.deals_of_week .owl-carousel').owlCarousel({
        autoplay: true,
        autoplaySpeed: 1500,
        loop: true,
        nav: false,
        dotsSpeed: 1000,
        dots: true,
        slideTransition: 'ease',
        autoplayHoverPause: true,
        items: 1,
        lazyLoad: true,

    });

    if ($('.dow_left').length) {

        var deal_prev = $('.dow_left');
        deal_prev.on('click', function () {

            $('.deals_of_week .owl-carousel').trigger('prev.owl.carousel');
        });
    }
    if ($('.dow_right').length) {

        var deal_next = $('.dow_right');
        deal_next.on('click', function () {

            $('.deals_of_week .owl-carousel').trigger('next.owl.carousel');
        });
    }
    // Set the date we're counting down to
    if (document.querySelectorAll(".dow_container") != 0) {
        document.querySelectorAll(".dow_container").forEach(dow_container => {
            var countDownDate = new Date(dow_container.querySelector("input").value).getTime();

            // Update the count down every 1 second
            var x = setInterval(function () {

                // Get today's date and time
                var now = new Date().getTime();

                // Find the distance between now and the count down date
                var distance = countDownDate - now;

                // Time calculations for days, hours, minutes and seconds
                var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                // Output the result in an element with id="demo"
                // dow_container.querySelector(".dow_timer").innerHTML = days + "d " + hours + "h "
                //     + minutes + "m " + seconds + "s ";
                dow_container.querySelector(".dow_timer").querySelector(".dow_timer_unit:first-child").innerHTML = days;
                dow_container.querySelector(".dow_timer").querySelector(".dow_timer_unit:nth-child(2)").innerHTML = hours;
                dow_container.querySelector(".dow_timer").querySelector(".dow_timer_unit:nth-child(3)").innerHTML = minutes;
                dow_container.querySelector(".dow_timer").querySelector(".dow_timer_unit:last-child").innerHTML = seconds;




                // If the count down is over, write some text 
                if (distance < 0) {
                    clearInterval(x);
                    dow_container.querySelector(".dow_timer").innerHTML = "Discount Ended";
                }
            }, 1000);

        })
    }

});