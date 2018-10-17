$(function () {
    $('#AlertBox').removeClass("hide");
    $('#AlertBox').delay(2000).slideUp();
})
function _filldataCat(id) {

    $.ajax({
        url: '/Admin/CategoryAdmin/SendDetail',
        data: { "id": id },
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (data) {
            $.each(data, function (key, value) {
            
                if (key == "CreateDate") {
                    var date = new Date(parseInt(value.replace('/Date(', '')));
                   // var d= date.getDate()+ '/' + (date.getMonth() + 1) + '/' + date.getFullYear();
                    

                    var day = ("0" + date.getDate()).slice(-2);
                    var month = ("0" + (date.getMonth() + 1)).slice(-2);

                    var today = date.getFullYear() + "-" + (month) + "-" + (day);
                    console.log(today);
                    $('#CreateDate').attr("value", "2016-05-19");
                   
                }else if(key == "Status")
                {
                    $('option[value='+value+'] ').prop("selected", true);
                }
                else
                {
                     $('[name=' + key + ']').val(value);
                }
               


            });
        }
    });
}
function _deleteCat(id) {

    var b = confirm("Bạn có chắc chắn muốn xóa!");
    if (b) {
        $.ajax({
            url: '/Admin/CategoryAdmin/Delete',
            data: { 'id': id },
            success: function (data) {
                $("#" + id).remove();
                console.log(data);
            }
        });
    }
}
function _pagela(_bien) {

    $.ajax({
        url: '/Admin/CategoryAdmin/_paging',
        type: "GET",
        data: { "_currentPage": _bien },
        success: function (data) {

            $("#_pagingla").html(data)
        }
    });
}
$('#btnSubmit1').click(function () {

    var loi = 0;
    if ($('#Name1').val() == "") {
        $('#LoiName1').text("Họ tên không được để trống.")
        loi++;
    }
    else {
        $('#LoiName1').text('')
    }
    if (loi != 0) {
        return false;
    }
    else {
        return true;
    }

});





