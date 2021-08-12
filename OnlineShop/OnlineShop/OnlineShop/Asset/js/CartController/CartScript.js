var cart = {
    init: function () {
        cart.UpdateCart();
    },
    UpdateCart: function () {
        var list = $('.quantity');
        var i = 0;
        for (var l in list) {
            i++;
            $('#btnAdd-' + i).click(function () {
                var btn = $(this).data('id');
                var Id = $('input.quantity[data-id=' + btn +']').data('id');
                //alert("Id=  :" + Id);
                console.log(btn);
                $.ajax({
                    url: "Cart/ChangeQuantity",
                    dataType: "json",
                    type: "POST",
                    data: { id: Id },
                    success: function (response) {
                        if (response.result) {
                            $('.amount[data-id=' + btn + ']').html(response.number);
                            var q = parseInt($('input.quantity[data-id=' + btn + ']').val());
                            $('.quantity[data-id=' + btn + ']').prop("value",q+1);
                        } else {
                            alert("Cannot add more product!");
                            //disable theadd button
                        }
                    }
                })
            })
        }
        //$('.btnIncrease').click(function () {
        //    var Id = $('.btnIncrease').data('id');
        //    var str = Id.toString();
        //    var q = $('.quantity[data-id=' + str + ']');
        //    $.ajax({
        //        url: "Cart/ChangeQuantity",
        //        dataType: "json",
        //        type: "POST",
        //        data: { id: Id },
        //        success: function (response) {
        //            if (response.result) {
        //                $('.amount[data-id=' + str + ']').html(response.number);
        //                $('.quantity[data-id=' + str + ']').val(q+1);
        //            } else {
        //                alert("Cannot add more product!");
        //                //disable theadd button
        //            }
        //        }
        //    })
        //})
    }
}
cart.init();