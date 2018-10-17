$(document).ready(function () {

    $(".nn-add-to-cart").click(function () {
        var id = $(this).parents("div").attr("data-id");
        $.ajax({
            url: "/Cart/Add/" + id,
            dataType: "json",
            success: function (response) {
                $("#cart-cnt").html(response.Count);
                $("#cart-amt").html(response.Amount);
            }
        });

    });
});