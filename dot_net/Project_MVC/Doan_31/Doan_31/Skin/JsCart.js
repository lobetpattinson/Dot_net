var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {

        $('#btnUpdate').click(function () {
            var lisProduct = $('.txtQuantity');
            var cartList = [];
            $.each(lisProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ProductID: $(item).data('id')
                    }

                })
            })


            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/gio-hang';;
                    }

                }
            })
        })
        $('.btn-delete').click(function () {

            $.ajax({
                url: 'Cart/DeleteById',
                dataType: 'json',
                data: { id: $(this).data('id') },
                type: 'POST',
                success: function (res) {
                    if (res.status==true)     
                    {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        })
        $('#btnDelete').click(function () {

            $.ajax({
                url: 'Cart/DeleteAll',
                dataType: 'json',
               
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        })
        $("#btnSuccess").click(function () {
            var listproduct = $(".txtQuantity");
            var cartList = [];
            $.each(listproduct, function (i,item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ProductID: $(item).data('id')
                    }

                })
            })
            $.ajax({
                url: '/Cart/CartSuccess',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        //window.location.href = "/gio-hang";
                        $(".table-responsive").html("<span class='alert alert-success' style='font-size: x-large;'>Thanh toán thành công</span>")
                    }
                    else
                    {
                        window.location.href = "/User/Login";
                    }
                    

                }
            })
        })
       
    }

}
cart.init();