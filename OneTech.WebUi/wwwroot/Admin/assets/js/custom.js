$(document).ready(function () {
    $('.ui.normal.dropdown')
        .dropdown({

        });
    $('.ui.special.dropdown')
        .dropdown({
            useLabels: false,
        });
    $('.ui.dropdown')
        .dropdown()


    FillCategory($("#mainCategoryForSubCategory"));

    $("#mainCategoryForSubCategory").change(function () {
        FillCategory($(this));
    })

    function FillCategory(mainCategory) {
        var mainCategoryId = mainCategory.val();
        $("#categoryForSubCategory option").remove();
        $.ajax({
            url: "/Admin/SubCategory/FillCategory/" + mainCategoryId,
            dataType: "json",
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    for (var category of response.data) {
                        var element = `<option value='${category.id}'>${category.name}</option>`
                        $("#categoryForSubCategory").append(element);
                    }
                }
                $("#categoryForSubCategory").removeAttr("disabled");
            }
        })
    }

    $("#mainCategoryForProduct").change(function () {
        FillCategoryForProducts($(this));
    })


    function FillCategoryForProducts(mainCategory) {
        var ids = mainCategory.val();
        $("#categoryForProduct option").remove();
        $('#categoryForProduct').siblings('a').remove();
        $('#subCategoryForProduct').siblings('a').remove();
        $.ajax({
            url: "/Admin/Product/FillCategory",
            data: { ids },
            datatype: 'json',
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    for (var category of response.data) {
                        var element = `<option value='${category.id}'>${category.name}</option>`
                        $("#categoryForProduct").append(element);
                    }
                }
                $("#categoryForProduct").removeAttr("disabled");
            }
        })
    }

    $("#categoryForProduct").change(function () {
        FillSubCategoryForProducts($(this));
    })

    function FillSubCategoryForProducts(category) {
        var ids = category.val();
        $("#subCategoryForProduct option").remove();
        $('#subCategoryForProduct').siblings('a').remove();
        $.ajax({
            url: "/Admin/Product/FillSubCategory",
            data: { ids },
            datatype: 'json',
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    for (var subCategory of response.data) {
                        var element = `<option value='${subCategory.subCategoryId}'>${subCategory.name}</option>`
                        $("#subCategoryForProduct").append(element);
                    }
                }
                $("#subCategoryForProduct").removeAttr("disabled");
            }
        })
    }

    $("#brandForProduct").change(function () {
        FillModelsForProducts($(this));
    })


    function FillModelsForProducts(brand) {
        var brandId = brand.val();
        $("#brandModelForProduct option").remove();
        $('#brandModelForProduct').siblings('a').remove();
        $.ajax({
            url: "/Admin/Product/FillBrandModels/" + brandId,
            datatype: 'json',
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    for (var brandModel of response.data) {
                        var element = `<option value='${brandModel.id}'>${brandModel.modelName}</option>`
                        $("#brandModelForProduct").append(element);
                    }
                }
                $("#brandModelForProduct").removeAttr("disabled");
            }
        })
    }


    $("#optionForProduct").change(function () {
        FillOptionValuesForProducts($(this));
    })


    function FillOptionValuesForProducts(options) {
        var ids = options.val();
        $("#optionValueForProduct option").remove();
        $('#optionValueForProduct').siblings('a').remove();
        $.ajax({
            url: "/Admin/Product/FillOptionValues/",
            datatype: 'json',
            data: { ids },
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    for (var optionValue of response.data) {
                        var element = `<option value='${optionValue.id}'>${optionValue.name}</option>`
                        $("#optionValueForProduct").append(element);
                    }
                }
                $("#optionValueForProduct").removeAttr("disabled");
            }
        })
    }


    $(".galleryPhotos").each(function () {
        var img = $(this).find("img").attr("src");
        $(this).click(function (event) {
            $("#choosenImage").find("img").attr("src", img);
            event.preventDefault();
            event.stopImmediatePropagation();
        })
    });


    $(".producColorOption").each(function () {
        var color = $(this);
        $(this).click(function () {
            if (!($("#mainProductPhotos")).hasClass("d-none")) {
                $("#mainProductPhotos").addClass("d-none");
            }
            if (!($("#mainProductName")).hasClass("d-none")) {
                $("#mainProductName").addClass("d-none");
            }
            if (!($("#mainProductPrices")).hasClass("d-none")) {
                $("#mainProductPrices").addClass("d-none");
            }

            
            $(`.productColorOptionsPhoto`).addClass("d-none");
            $(`.productColorOptionsName`).addClass("d-none");
            $(`.productColorOptionsPrice`).addClass("d-none");

            var id = color.attr('id');
            $(`#${id}Photo`).removeClass("d-none");
            $(`#${id}Name`).removeClass("d-none");
            $(`#${id}Price`).removeClass("d-none");
        })

    });

    $("#mainProductColor").click(function () {


        if ($("#mainProductPhotos").hasClass("d-none")) {
            $("#mainProductPhotos").removeClass("d-none");
        }
        if ($("#mainProductName").hasClass("d-none")) {
            $("#mainProductName").removeClass("d-none");
        }
        if ($("#mainProductPrices").hasClass("d-none")) {
            $("#mainProductPrices").removeClass("d-none");
        }

        $(`.productColorOptionsPrice`).addClass("d-none");
        $(`.productColorOptionsPhoto`).addClass("d-none");
        $(`.productColorOptionsName`).addClass("d-none");

    });


    $("#discountWithPercent").change(function () {
        var discount = $("#discountWithPercent").val();
        var defaultPrice = $("#defaulSellingPriceForPercent").text();       
        $("#discountedWithPercent").text(defaultPrice - (defaultPrice * discount / 100));
    })
    $("#discountWithMoney").change(function () {
        var discount = $("#discountWithMoney").val();
        var defaultPrice = $("#defaulSellingPriceForMoney").text();
        $("#discountedWithMoney").text(defaultPrice - discount);
    })

})