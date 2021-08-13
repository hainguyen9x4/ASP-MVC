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
                var Id = $('input.quantity[data-id=' + btn + ']').data('id');
                //alert("Id=  :" + Id);
                //console.log(btn);
                $.ajax({
                    url: "Cart/ChangeQuantity",
                    dataType: "json",
                    type: "POST",
                    data: { id: Id },
                    success: function (response) {
                        if (response.result) {
                            $('.amount[data-id=' + btn + ']').html(response.number);
                            var q = parseInt($('input.quantity[data-id=' + btn + ']').val());
                            $('.quantity[data-id=' + btn + ']').prop("value", q + 1);
                            ///Update total amount
                            $('#totalAmount').html(response.totalAmount);

                        } else {
                            alert("Cannot add more product!");
                            //disable the add button
                        }
                    }
                })
            })
            // --
            $('#btnSub-' + i).click(function () {
                var btn = $(this).data('id');
                var Id = $('input.quantity[data-id=' + btn + ']').data('id');
                var q = parseInt($('input.quantity[data-id=' + btn + ']').val());
                $.ajax({
                    url: "Cart/ChangeSubQuantity",
                    dataType: "json",
                    type: "POST",
                    data: { id: Id },
                    success: function (response) {
                        if (response.result) {
                            if (response.number == 0) {
                                window.location.href = "/Cart";
                            }
                            $('.amount[data-id=' + btn + ']').html(response.number);
                            $('.quantity[data-id=' + btn + ']').prop("value", q - 1);
                            ///Update total amount
                            $('#totalAmount').html(response.totalAmount);
                        } else {
                            alert("Cannot add more product!");
                            //disable the sub button
                        }
                    }
                })
            })
        }
    }
}
cart.init();