$('#btn-uploadImg').click(function () {
    $('#dlgbox').trigger('click');
})
$('#dlgbox').change(function () {
    console.log($('#dlgbox').val());
    //$('#Avatar').attr('value', $('#dlgbox').val());
    if (window.FormData !== undefined) {
        //lay du lieu tren upload file
        var fileUpload = $('#dlgbox').get(0);
        var file = fileUpload.files;

        console.log("file--------");
        console.log(file);
        var formdata = new FormData();
        formdata.append('file', file[0]);
        $.ajax({
            type: 'POST',
            url: '/Product/UploadImage',
            contentType: false,
            processData: false,
            data: formdata,
            success: function (urlImg) {
                $('#Avatar').attr('value', urlImg);
                $('#selected-img').attr('src', urlImg);
            },
            error: function (err) {

            }
        })
    }
})