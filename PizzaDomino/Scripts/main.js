$(document).on('click', '.fileUploadAdditional', function () {
    var parent = $(this).parent();
    var data = new FormData();
    var files = $(this).parent().find(".uploadEditorImage").get(0).files;
    if (files.length > 0) {
        data.append("HttpPostedFileBase", files[0]);
        $(this).parent().find('.image').val('/images/lots/' + files[0].name)
    }
    //.val('/images/' + files[0].name);
    $.ajax({
        url: "/Home/UploadImage/",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            alert('Image was successfully uploaded');
        },
        error: function (er) {
            alert(er.responseText);
        }

    });
});

$(document).on('click', '.ingredientEdit', function () {
    var id = $(this).attr('id');
    $('#createModule').load("/Home/EditIngredient/" + id);
    $('.createModule').show();
});
function closePopup() {
    $('.createModule').hide();
}
function OnSuccess(data) {
    alert();
    //location.reload();
}
$(document).ready(function () {
    $('#sbmt-ingredient').click(function () {
        alert();
        $("#form0").submit(function (e) {
            var form = $('#form0');
            var url = form.attr('action');
            alert();
            $.ajax({
                type: "POST",
                url: url,
                data: form.serialize(), // serializes the form's elements.
                success: function (data) {
                    alert(data); // show response from the php script.
                }
            });

            e.preventDefault(); // avoid to execute the actual submit of the form.
        });
        $("#form0").submit();
    });
});