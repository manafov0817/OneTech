$(document).ready(function () {

    $.ajaxSetup({ headers: { 'csrftoken': '{{ csrf_token() }}' } });

    $(document).on("click", ".page-link", function (event) {
        event.preventDefault();
        var colorIds = new Array();
        var brandIds = new Array();

        $(".colorFilter").each(function () {
            if ($(this).is(":checked")) {
                colorIds.push($(this).attr("id").slice(1));
            }
        })

        $(".brandFilter").each(function () {
            if ($(this).is(":checked")) {
                brandIds.push($(this).attr("id").slice(1))
            }
        })

        FillProducts($(this), colorIds, brandIds)
        event.stopImmediatePropagation();
    })

    $(".page-size").click(function (event) {
        event.preventDefault();
        var colorIds = new Array();
        var brandIds = new Array();
        $(".colorFilter").each(function () {
            if ($(this).is(":checked")) {
                colorIds.push($(this).attr("id").slice(1));
            }
        })

        $(".brandFilter").each(function () {
            if ($(this).is(":checked")) {
                brandIds.push($(this).attr("id").slice(1))
            }
        })

        FillProducts($(this), colorIds, brandIds)


        var productFound = $(".productFound").text();
        var pageSize = $(this).text();
        var pageCount = Math.ceil(productFound / pageSize);

        $(".page-item").remove();



        for (var i = 1; i < pageCount + 1; i++) {
            var element = ` <li class="page-item active">
                                <a class="page-link" href="/Shop?pageSize=${pageSize}&amp;pageNumber=${i}">${i}</a>
                            </li>`
            $(".pagination").append(element);
        }

        event.preventDefault();
    })

    function GetName(name, id) {
        if (name.length > 25) {
            var myName = name.slice(0, 25) + "...";
            return `<a href="/Product?productId=${id}">${myName}</a>`
        }
        else {
            return `<a href="/Product?productId=${id}">${name} ...</a>`
        }
    }

    $("#filter").click(function (event) {

        var colorIds = new Array();
        var brandIds = new Array();
        $(".colorFilter").each(function () {
            if ($(this).is(":checked")) {
                colorIds.push($(this).attr("id").slice(1));
            }
        })

        $(".brandFilter").each(function () {
            if ($(this).is(":checked")) {
                brandIds.push($(this).attr("id").slice(1))
            }
        })

        console.log(colorIds);
        console.log(brandIds);

        FillProducts($(".pagination:first-child .page-link"), colorIds, brandIds)

        event.preventDefault();
    })

    function IsNew(addedDate) {
        var addedDateNumbers = addedDate.split("T")[0].split("-");

        var finalNumber = addedDateNumbers[0] * addedDateNumbers[1] + parseInt(addedDateNumbers[2]);

        var date = new Date();
        var nowDate = date.getDate();
        var nowMonth = date.getMonth();
        var nowYear = date.getFullYear();
        var nowDay = (nowMonth + 1) * nowYear + nowDate;

        if (nowDay - finalNumber < 7) {
            return `<div class="shop-product-new">
                       New
                   </div>`
        }

    }

    function DiscountWithMoney(money) {
        if (money > 0) {
            return `<div class="shop-product-discount">
                   -${money}$
                      </div>`
        }
        else {
            return ""
        }
    }

    function DiscountWithPercent(percent) {
        if (percent > 0) {
            return `<div class="shop-product-discount">
                   -${percent}%
                      </div>`
        }
        else {
            return ""
        }
    }

    function FillProducts(clickedPageNumber, colorIds, brandIds) {
        var link;
        if (clickedPageNumber.attr("href") === undefined || clickedPageNumber.attr("href") == undefined) {
            link = `href="/Shop?pageSize=${2}&amp;pageNumber=${1}"`;
        }
        else {
            link = clickedPageNumber.attr("href");
        }
        var categoryId = $(".categoryId").attr("id");
        var questionSymbol = link.indexOf("?");
        link = link.slice(questionSymbol + 1);
        var array = link.split("&");
        var array2 = new Array();
        var pageSize = 0;
        var pageNumber = 0;
        for (var mySring of array) {
            if (mySring.includes("pageSize")) {
                pageSize = mySring.slice((mySring.indexOf("=") + 1));
                array2.push(pageSize);
            }
            if (mySring.includes("pageNumber")) {
                pageNumber = mySring.slice((mySring.indexOf("=") + 1));
                array2.push(pageNumber);
            }
        }
        $(".shop-product").remove();
        $.ajax({
            url: "/Shop/ProductList/",
            data: { pageSize, pageNumber, categoryId, colorIds, brandIds },
            datatype: 'json',
            type: "post",
            success: function (response) {
                response = JSON.parse(response);
                if (response.status == 200) {
                    for (var product of response.data) {
                        var newProduct = `<div class="shop-product">

                                           <div class="shop-product-photo">
                                                <a href="/Product?productId=${product.Id}">
                                                    <img src="/img/Products/${product.ProductPhotos[0].Photo.Path}" alt="" srcset="">
                                                </a>
                                            </div>                                            
                                           <div class="shop-product-content">
                                                <div class="price">
                                                    ${product.SellingPrice} $
                                                </div>                                         
                                            
                                                <div class="product-name">
                                                       ${GetName(product.Name, product.Id)}                                                                                                
                                                </div>
                                            </div>                                             
                                            ${IsNew(product.AddedDate)} 
                                            ${DiscountWithMoney(product.DiscountWithMoney)}
                                            ${DiscountWithPercent(product.DiscountWithPercent)}
                                    </div>`;
                        $(".shop-products").append(newProduct);
                    }
                    $(".productFound").text(response.productCount)
                }
            },
        })
    }


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


});