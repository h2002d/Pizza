$(document).on('click', '.fileUploadAdditional', function () {
    var parent = $(this).parent();
    var data = new FormData();
    var files = $(this).parent().find(".uploadEditorImage").get(0).files;
    if (files.length > 0) {
        data.append("HttpPostedFileBase", files[0]);
        $(this).parent().find('.image').val('/images/Goods/' + files[0].name)
    }
    //.val('/images/' + files[0].name);
    $.ajax({
        url: "/Home/UploadImage/",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
           // $(this).parent().find('.image').val('/images/lots/'+response);
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
  location.reload();
}
$(document).ready(function () {
    
});