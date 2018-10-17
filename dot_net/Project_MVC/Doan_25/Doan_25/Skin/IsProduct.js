$(function () {
    $('#AlertBox').removeClass("hide");
    $('#AlertBox').delay(1000).slideUp();
})
function _pagela(_currentPage) {
    
    $.ajax({
        url: '/Admin/ProductAdmin/_paging',
        type: "GET",
        data: { "_currentPage": _currentPage },
        success: function (data) {
            $("#_pagingla").html(data)
            //console.log(data)
        }
    });
}
function _deleteProduct(id) {
   
    var b = confirm("Bạn có chắc chắn muốn xóa!");
    if (b) {
        $.ajax({
            url: '/Admin/ProductAdmin/Delete',
            data: { 'id': id },
            success: function (data) {
                $("#" + id).remove();
                console.log(data);
            }
        });
    }
}
function _filldata(id) {
   
    $.ajax({
        url: '/Admin/ProductAdmin/_SendDetail',
        data: { "id": id },
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (_data) {

            $.each(_data, function (key, value) {
                console.log(key +"_"+value)
                if (key == "Status")
                {
                    $("option[value="+value+"]").prop("selected",true)
                }
                else
                if (key !== 'ImagesMain') {

                    $('[name=' + key + ']').val(value);

                }
               

            });
        }
    });
}
function ThemMoiSP() {
    var dataToSend = {
        MetaTitle: $('input[name="MetaTitle"]').val(),
        NameProduct: $('input[name="NameProduct"]').val(),
        Price: ($('input[name="Price"]').val()),
        PriceNews: ($('input[name="PriceNews"]').val()),
        ManufacturesID: $('select[name="ManufacturesID"]').val(),
        CategoryID: $('select[name="CategoryID"]').val(),
        ImagesMain: $('input[name="NameProduct"]').val(),
        DienAp: $('input[name="DienAp"]').val(),
        LedChip: $('input[name="LedChip"]').val(),
        Quantity: $('input[name="Quantity"]').val(),
        QuangThong: $('input[name="QuangThong"]').val(),
        HeSoCRI: $('input[name="HeSoCRI"]').val(),
        NhietDoMau: $('input[name="NhietDoMau"]').val(),
        GocMo: $('input[name="GocMo"]').val(),
        DoKin: $('input[name="DoKin"]').val(),
        NhietDoLamViec: $('input[name="NhietDoLamViec"]').val(),
        HeSoCongSuat: $('input[name="HeSoCongSuat"]').val(),
        VatLieu: $('input[name="VatLieu"]').val(),
        Content: $('input[name="Content"]').val(),
        Wanrranty: ($('input[name="Warranty"]').val()),
        Status: $('select[name="Status"]').val(),
    };
    
    $.ajax({
        url: '/Admin/ProductAdmin/ThemMoi',
        
        type: "POST",
        async: false,
        dataType: "json",
        data: "{ p:" + JSON.stringify(dataToSend) + " }",
        //timeout: 30000,
        contentType: "application/json; charset=utf-8",
        success: function (_data) {
            alert("thanh cong")
        }
    })
}