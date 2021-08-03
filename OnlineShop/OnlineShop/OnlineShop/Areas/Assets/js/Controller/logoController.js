var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btnx-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Logo/ChangeStatus",
                dataType: "json",
                type: "POST",
                data: { id: id },
                success: function (response) {
                    if (response.result) {
                        if (response.status == true) {
                            btn.text('True');
                        } else {
                            btn.text('False');
                        }
                    } else {
                        alert("Can not change the status now!");
                    }

                }
            });
        });
    }
}
user.init();