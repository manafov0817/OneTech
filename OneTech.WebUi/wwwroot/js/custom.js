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

    $(document).on("mouseenter", ".cart-item", function () {

        var cartQuantity = $(this).find(".cartQuantity");
        var productId = $(this).find(".productInCartId");
        var totalPrice = $(this).find(".totalPrice");
        var removeCartItem = $(this).find(".removeCartItem");
        var price = $(this).find(".itemPrice");
        var item = $(this);
        cartQuantity.on("mouseup", function () {
            totalPrice.text(`$ ${price.val() * cartQuantity.val()}`);
            ChangeProductQuantity(productId.val(), cartQuantity.val());
            SetTotal();
        })


        removeCartItem.on("click", function () {
            item.remove();
            RemoveFromCart(productId.val());
        })
    });

    $("#ex2").slider({});

    $(".page-size").click(function (event) {
        event.preventDefault();
        var colorIds = new Array();
        var brandIds = new Array();
        $(".colorFilter").each(function () {
            if ($(this).is(":checked")) {
                colorIds.push($(this).attr("id").slice(1));
            }
        })
        $(".page-size").removeClass("active");
        $(this).addClass("active");

        $(".brandFilter").each(function () {
            if ($(this).is(":checked")) {
                brandIds.push($(this).attr("id").slice(1))
            }
        })

        FillProducts($(this), colorIds, brandIds)



        event.preventDefault();
    })

    $("#quantity").mouseup(function () {
        var price = $("#sellingPrice").val();
        $("#mainProductPrice").text(`$ ${price * $(this).val()}`);
    });

    $("#filter").click(function (event) {

        var colorIds = new Array();
        var brandIds = new Array();
        var minPrice = $("#ex2").val().split(",")[0];
        var maxPrice = $("#ex2").val().split(",")[1];

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

        $(".brandFilter").each(function () {
            if ($(this).is(":checked")) {
                brandIds.push($(this).attr("id").slice(1))
            }
        })

        FillProducts($(".pagination:first-child .page-link"), colorIds, brandIds, minPrice, maxPrice)

        event.preventDefault();
    })

    $("#addProductToCart").click(function (event) {
        event.preventDefault();
        var productId = $("#productIdValue").val();
        var productCount = $("#quantity").val();
        AddToCart(productId, productCount);
        event.preventDefault();
    })
    $(document).on("click", ".fob_add_to_card_button",function (event) {
        event.preventDefault();
        var productId = $(this).attr("id");
        var productCount = 1;
        AddToCart(productId, productCount);
    })
    $(document).on("click", ".add-to-cart-from-shop", function (event) {
        event.preventDefault();
        var productId = $(this).attr("id");
        var productCount = 1;
        AddToCart(productId, productCount);
    })

    function GenerateAddToCart(productId) {
        if ($("#authenticated").val() == "true") {
            return ` <a href="" id="${productId}" class="add-to-cart-from-shop">
                              ADD TO CART
                      </a>`
        }
        else {
            return ``;
        }
    }

    function SetTotal() {
        var cartItems = document.getElementsByClassName("cart-item");
        var totalForAll = 0;
        for (var cartItem of cartItems) {
            var cartItemPrice = $(cartItem).find(".cartQuantity").val();
            var cartItemQuantity = $(cartItem).find(".itemPrice").val()
            totalForAll += cartItemPrice * cartItemQuantity
        }
        $(".products-total-price").text(`$ ${totalForAll}`);
    }

    function GetName(name, id) {
        if (name.length > 25) {
            var myName = name.slice(0, 25) + "...";
            return `<a href="/Product?productId=${id}">${myName}</a>`
        }
        else {
            return `<a href="/Product?productId=${id}">${name} ...</a>`
        }
    }

    function IsNew(addedDate) {
        var addedDateNumbers = addedDate.split("T")[0].split("-");

        var finalNumber = addedDateNumbers[0] * addedDateNumbers[1] + parseInt(addedDateNumbers[2]);

        var date = new Date();
        var nowDate = date.getDate();
        var nowMonth = date.getMonth();
        var nowYear = date.getFullYear();
        var nowDay = (nowMonth + 1) * nowYear + nowDate;

        if (nowYear == parseInt(addedDateNumbers[2])) {
            if (nowDay - finalNumber < 7) {
                return `<div class="shop-product-new">
                       New
                   </div>`
            }
            else { return ` ` }
        }
        else { return ` ` }
    }

    function Discount(money, percent, price) {
        if (money > 0) {
            return `<div class="shop-product-discount">
                   -${money}$
                    </div>
                     <div class="shop-product-content">
                        <div class="price discounted-shop-price">
                            $${price - money} <span>$${price}</span>
                        </div> `

        }
        else if (percent > 0) {
            return `<div class="shop-product-discount">
                       -${percent}%
                         </div>
                           <div class="shop-product-content discounted-shop-price">
                            <div class="price">
                               $${price - (price * percent / 100)} <span>$${price}</span>
                            </div> `
        }
        else {
            return ` <div class="shop-product-content">
                        <div class="price">
                            $${price} 
                        </div> `
        }
    }



    function FillProducts(clickedPageNumber, colorIds, brandIds, minPrice, maxPrice) {

        var link;

        if (clickedPageNumber.attr("href") === undefined || clickedPageNumber.attr("href") == undefined) {
            link = `href="/Shop?pageSize=${2}&amp;pageNumber=${1}"`;
        }
        else {
            link = clickedPageNumber.attr("href");
        }

        var categoryId = $(".categoryId").attr("id");
        var productName = $(".productName").attr("id");

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
            data: { pageSize, pageNumber, categoryId, colorIds, brandIds, productName, minPrice, maxPrice },
            datatype: 'json',
            type: "post",
            success: function (response) {
                response = JSON.parse(response);
                if (response.status == 200) {
                    if (response.data.length > 0) {
                        for (var product of response.data) {
                            var newProduct = `<div class="shop-product">

                                                   <div class="shop-product-photo">
                                                        <a href="/Product?productId=${product.Id}">
                                                            <img src="/img/Products/${product.ProductPhotos[0].Photo.Path}" alt="" srcset="">
                                                        </a>
                                                    </div>                                            
                                                   
                                                    ${Discount(product.DiscountWithMoney, product.DiscountWithPercent, product.SellingPrice)}

                                            
                                                        <div class="product-name">
                                                               ${GetName(product.Name, product.Id)}                                                                                                
                                                        </div>
                                                    </div>                                             
                                                    ${IsNew(product.AddedDate)} 
                                                   
                                                    ${GenerateAddToCart(product.Id)}
                                              </div>`;
                            $(".shop-products").append(newProduct);
                        }
                    }


                    $(".productFound").text(response.productCount)
                    var productFound = response.productCount;
                    var pageSize = $(".active.page-size").text();
                    var pageCount = Math.ceil(productFound / pageSize);
                    $(".page-item").remove();
                    for (var i = 1; i < pageCount + 1; i++) {
                        if (i == pageNumber || (pageNumber == 0 && i == 1)) {
                            var element = ` <li class="page-item active">
                                                  <a class="page-link" href="/Shop?pageSize=${pageSize}&amp;pageNumber=${i}">${i}</a>
                                            </li>
                                          `
                            $(".pagination").append(element);
                        }
                        else {
                            var element = ` <li class="page-item ">
                                            <a class="page-link" href="/Shop?pageSize=${pageSize}&amp;pageNumber=${i}">${i}</a>
                                        </li>
                                           `
                            $(".pagination").append(element);
                        }
                    }
                }
            },
        })


    }

    function RemoveFromCart(productId) {
        SetTotal();
        $.ajax({
            url: "/Cart/RemoveFromCart/",
            data: { productId },
            datatype: 'json',
            type: "post",

        })
    }

    function AddToCart(productId, productCount) {
        $(".nav2_buy_cart").remove();
        $.ajax({
            url: "/Cart/AddToCartAjax/",
            data: { productId, productCount },
            datatype: 'json',
            type: "post",
            success: function (response) {
                if (response.status == 200) {

                    var newElement = `<div class=" nav2_buy_cart row col-5 ml-auto">
                                        <div class="cart ml-auto ">
                                            <i class="fas fa-shopping-cart ">
                                                <span class="shop_count">${response.productTypeCount}</span>
                                            </i>
                                        </div>
                                        <div>
                                            <a class="a_for_hover" href="/Cart">Cart</a>
                                            <p>$${response.allProductsInCartPrice}</p>
                                        </div>
                                     </div>`;
                    $(".nav2_buy_container").append(newElement);
                }
            },
        })
    }

    function ChangeProductQuantity(productId, productCount) {
        $.ajax({
            url: "/Cart/ChangeProductCountAjax/",
            data: { productId, productCount },
            datatype: 'json',
            type: "post",
        })
    }
});


