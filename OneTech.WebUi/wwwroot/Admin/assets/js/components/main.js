$(function () {
    "use strict";



    /***
    Initializing Bootstrap popover and tooltip
    ***/
    $('[data-toggle="popover"]').popover();
    $('[data-toggle="tooltip"]').tooltip();

    // Add shade while overlay-view
    $('body').append('<div class="shade"></div>');

    /***
    Topbar search
    ***/
    $('#searchIcon').on('click', function (e) {
        e.preventDefault();
        $('.search-input-field').addClass('show');
        $('.shade').addClass('visible');
    });

    $('#closeSearchBox').on('click', function (e) {
        e.preventDefault();
        $('.search-input-field').removeClass('show');
        $('.shade').removeClass('visible');
    });

    // Topbar notification dropdown scroll init
    var psNotificationDropdown = new PerfectScrollbar('.notification-wrapper', {
        suppressScrollX: true,
        wheelPropagation: false
    });

    /***
    Main navigation menu to sidebar transition
    Remove this section in any version other than Horizontal
    ***/

    // Initializing the side-nav scrollbar
    if (window.matchMedia('(max-width: 991px)').matches) {
        if ($('#horizontalNavWrapper').length) {
            var psTopNav = new PerfectScrollbar('#horizontalNavWrapper', {
                suppressScrollX: true,
                wheelPropagation: false
            });
        }

    }

    // Checking if smallscreen
    var isSmallWindow;
    function checkResize(win) {
        isSmallWindow = win.width() <= 991;
    }
    checkResize($(window));

    // On window resize
    var psTopNav;
    $(window).on('resize', function () {

        // Checking if resized to smallscreen
        checkResize($(this));

        // If smallscreen, redeclaring side-nav scrollbar to init the scrolling functionality
        // Can be romoved in production
        if (window.matchMedia('(max-width: 991px)').matches) {
            if ($('#horizontalNavWrapper').length) {
                psTopNav = new PerfectScrollbar('#horizontalNavWrapper', {
                    suppressScrollX: true,
                    wheelPropagation: false
                });
            }
        }

        // Removing .drop-down class added on small screen by user-click and window resized to bigscreen on that state
        // so that we avoid the dropped menu being permanently shown on bigscreen
        if (!isSmallWindow) {
            $('.has-submenu').removeClass('drop-down');
        }

    });

    // Expanding dropdown on click in smallscreen
    $('.navbar-custom .has-submenu > a').on('click', function (e) {
        e.preventDefault();
        if (isSmallWindow) {
            $(this)
                .closest('.has-submenu')
                .toggleClass('drop-down');
            if ($('#horizontalNavWrapper').length)
                psTopNav.update();
        }
    });

    // Hiding sidenav
    $('#navbar-close').on('click', function (e) {
        e.preventDefault();
        $('#app').removeClass('horizontal-nav-show');
    });

    // Showing sidennav
    if ($('#show-menubar').length) {
        $('#show-menubar').on('click', function (e) {
            e.preventDefault();
            $('#app').addClass('horizontal-nav-show');
        });
    }

    /***
    Bootstrap upload file-name fix (filename on upload button not shown by default)
    ***/
    $('input[type="file"]').change(function (e) {
        var fileName = e
            .target
            .files[0]
            .name;
        $('.custom-file-label').html(fileName);
    });

    /***
    Upload multiple image custom button script
    ***/
    $("#preview_image").on("change", function () {

        var imgPrev = $(".image-preview");

        this.files && $.each(this.files, function (key, value) {

            // Finding if the uploaded file is an image
            if (!/\.(jpe?g|png|gif)$/i.test(value.name)) {
                return alert(value.name + " is not an image");
            }

            // Appending the files to the preview wrapper
            var fileReader = new FileReader;
            $(fileReader).on("load", function () {
                imgPrev.append("<span class='upload-wrapper'><span class='upload-wrapper-delete'>X</span><img src='" + this.result + "'></span>")
            });
            fileReader.readAsDataURL(value);

            // Removing the image on click to delete icon
            $(document).on("click", ".upload-wrapper-delete", function (imgPrev) {
                $(this)
                    .parents(".upload-wrapper")
                    .remove();
                $(this).remove();
            });
        });
    });
});
