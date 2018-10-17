$('#btnSubmit').click(function () {

    var loi = 0;
    if ($('#UserName').val() == "") {
        $('#LoiUserName').text("Họ tên không được để trống.")
        loi++;
    }
    else {
        $('#LoiUserName').text('')
    }
    if ($('#Password').val() == "") {
        $('#LoiPassword').text("Mật khẩu không được để trống.")
        loi++;
    }
    else {
        $('#LoiPassword').text('')
    }

    if ($('#ConfirmPass').val() == "") {
        $('#LoiConfirmPass').text("Yêu cầu xác nhận mật khẩu.")
        loi++;
    }
    else {
        $('#LoiConfirmPass').text('')
    }
    if ($('#Name').val() == "") {
        $('#LoiName').text("Họ tên không được để trống.")
        loi++;
    }
    else {
        $('#LoiName').text('')
    }
    if ($('#Address').val() == "") {
        $('#LoiAddress').text("Địa chỉ không được để trống.")
        loi++;
    }
    else {
        $('#LoiAddress').text('')
    }
    if ($('#Email').val() == "") {
        $('#LoiEmail').text("Email không được để trống.")
        loi++;
    }
    else {
        $('#LoiEmail').text('')
    }
    if ($('#Phone').val() == "") {
        $('#LoiPhone').text("SĐT không được để trống.")
        loi++;
    }
    else {
        $('#LoiPhone').text('')
    }
    if (loi != 0) {
        return false;
    }
    else {
        return true;
    }

});
$(function () {
    $("#btnSubmit").click(function () {
        var password = $("#Password").val();
        var confirmPassword = $("#ConfirmPass").val();
        if (password != confirmPassword) {
            $('#LoiConfirmChuaDung').text("Xác nhận mật khẩu không đúng.")
            return false;
        }
        return true;
    });
});
