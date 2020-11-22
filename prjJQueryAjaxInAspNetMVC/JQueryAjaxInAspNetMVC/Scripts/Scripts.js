$(function () {
    $('#loaderbody').addClass('hide');

    $(document).bind('ajaxStart', function () {
        $('#loaderbody').removeClass('hide');
    }).bind('ajaxStop', function () {
        $('#loaderbody').addClass('hide');
    });
});


function ShowImagePreview(imagesUploader, previewImage) {
    if (imagesUploader.files && imagesUploader.files[0]) {
        let reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imagesUploader.files[0]);
    }
}

function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        let ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),   /*表單取值，若沒有則無法送出表單的值*/
            success: function (res) {
                if (res.success) {
                    $('#firstTab').html(res.html);
                    refreshAddNewTab($(form).attr('data_resetUrl'), true);
                    $.notify(res.message, "success");
                    if (typeof activateJQueryTable !== 'undefined' && $.isFunction(activateJQueryTable))
                        activateJQueryTable();
                } else {
                    //err msg
                    $.notify(res.message, "error");
                }
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);
    }
    return false;
}

function refreshAddNewTab(resetUrl, showViewTab) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (res) {
            $('#secondTab').html(res);
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showViewTab)
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
        }
    })
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#secondTab').html(res);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
                $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    })
}

function Delete(url) {
    if (confirm('確定要刪除嗎?') == true) {

        $.ajax({
            type: 'POST',
            url: url,
            success: function (res) {
                if (res.success) {
                    $('#firstTab').html(res.html);
                    $.notify(res.message, "warn");
                    if (typeof activateJQueryTable !== 'undefined' && $.isFunction(activateJQueryTable))
                        activateJQueryTable();
                }
                else {
                    $.notify(res.message, "error");
                }
            }
        })
    }
}