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
$(document).on('click', '.sizeEdit', function () {
    var id = $(this).attr('id');
    $('#createModule').load("/Home/EditSize/" + id);
    $('.createModule').show();
});
$(document).on('click', '.ingredientDelete', function () {
    var id = $(this).attr('id');
    $.ajax({
        url: "/Home/DeleteTemplate/" + id,
        type: "POST",
        success: function (response) {
            location.reload();
        },
        error: function (er) {
            alert(er.responseText);
        }

    });
});
$(document).on('click', '.sizeDelete', function () {
    var id = $(this).attr('id');
    $.ajax({
        url: "/Home/DeleteSize/"+id,
        type: "POST",
        success: function (response) {
            location.reload();
        },
        error: function (er) {
            alert(er.responseText);
        }

    });
});

function closePopup() {
    $('.createModule').hide();
}
function OnSuccess(data) {
  location.reload();
}
$(document).ready(function () {
    
});