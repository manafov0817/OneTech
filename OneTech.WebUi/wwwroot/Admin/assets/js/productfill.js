$(document).ready(function () {
    $('.js-example-basic-multiple').select2();
});
$(document).ready(function () {

    FillCategory($("#mainCategory"));
    FillBrandModel($("#brand"));

    $("#mainCategory").change(function () {
        FillCategory($(this));
    })

    $("#category").change(function () {
        FillProductType($(this));
    })

    $("#brand").change(function () {
        FillBrandModel($(this));
    })


    function FillCategory(mainCategory) {
        var mainCategoryId = mainCategory.val();
        $("#category option").remove();
        $.ajax({
            url: "/Admin/Product/FillCategory/" + mainCategoryId,
            dataType: "json",
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    for (var category of response.data) {
                        var element = `<option value='${category.id}'>${category.name}</option>`
                        $("#category").append(element);
                    }
                }
                $("#category").removeAttr("disabled");
                FillProductType($("#category"));

            }
        })
    }
    function FillProductType(category) {
        var categoryId = category.val();
        $("#productType option").remove();
        $.ajax({
            url: "/Admin/Product/FillProductType/" + categoryId,
            dataType: "json",
            type: "post",
            success: function (response) {
                var counter = 0;
                for (var productType of response.data) {
                    if (counter == 0) {
                        var element = `<option  selected value='${productType.id}'>${productType.name}</option>`
                    }
                    else {
                        var element = `<option value='${productType.id}'>${productType.name}</option>`
                    }
                    counter++;
                    $("#productType").append(element);
                }
                $("#productType").removeAttr("disabled");

            }
        })
    }

    function FillBrandModel(brand) {
        var brandId = brand.val();
        $("#brandModel option").remove();

        $.ajax({
            url: "/Admin/Product/FillBrandModel/" + brandId,
            dataType: "json",
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    var counter = 0;
                    for (var brandModel of response.data) {
                        if (counter == 0) {
                            var element = `<option  selected value='${brandModel.id}'>${brandModel.name}</option>`
                        }
                        else {
                            var element = `<option value='${brandModel.id}'>${brandModel.name}</option>`
                        }
                        counter++;
                        $("#brandModel").append(element);
                    }
                    $("#brandModel").removeAttr("disabled");
                }
            }
        })
     
    }
    })