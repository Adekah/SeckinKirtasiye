



function readURL5(input) {

    if (input.files && input.files[0]) {

        var reader = new FileReader();

        reader.onload = function (e) {

            $('#id_sliderimage').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
    else {
        $('#id_sliderimage').attr('src', '/img/Admin/no-photo.png');
    }
}

//Buton
$("#id_sliderbuton").change(function () {
    readURL5(this);
});
$(document).on("change", "#id_sliderbuton", function () {
    readURL5(this)
})


$(document).on("click", "#asd", function () {
    alert("asdasdsads");
})

$(document).on("click", "#slider_create_trigger", function () {

    $('#id_sliderbuton').click();
})




