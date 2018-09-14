
///////////////////////////SLİDER///////////////////////////SLİDER///////////////////////////SLİDER///////////////////////////SLİDER///////////////////////////SLİDER


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

$(document).on("change", "#input_slider", function () {
    readURL5(this)
})
$(document).on("click", "#slider_create_trigger", function () {

    $('#input_slider').click();
})

$(document).on("click", "#_deleteSlide", function () {

    $('#_deleteSlide').attr('sID', $(this).attr('value'));
    var message = $('#DeletewithJS').attr('message');


    $("#modal-info_Delete").modal({ show: true });

    $(".modal-body").empty();

    $(".modal-body").append("<i class='fa fa-warning'></i>" + message + " Kaydını Silmek İstediğinize Eminmisiniz ? </span>");

    event.preventDefault();

    return false;
})

$(document).on("click", "#btnContinue", function () {

    //View den Hidden la message gönderiyoruz o mesaja göre neyi silme yaptıracağına yönlendiriyoruz.
    //sID ve pID satırların ıd leri aynı fakat value leri farklı olduğundan ilk satırın valuesini almaması için farklı bir değere atıyoruz id leri 


    var message = $('#DeletewithJS').attr('message');
    var ID_Slide = $('#_deleteSlide').attr('sID');

    event.preventDefault();
    if (message == "Slayt") {
        $.ajax({
            type: "post",
            url: "/Admin/Slide_Delete",
            datatype: "json",
            data: { "slide_id": ID_Slide },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR + "-" + textStatus + "-" + errorThrown);
            },
            success: function (data) {
                window.location = "/Admin/Slider";

            }

        });
    }

})

///////////////////////////BRANDS///////////////////////////BRANDS///////////////////////////BRANDS///////////////////////////BRANDS///////////////////////////BRANDS


$(document).on("click", "#input_Brands_trigger", function () {
    $('#input_Brands').click();
})


function readBrand(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#Brand_image').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);

    }
    else {
        $('#Brand_image').attr('src', '/img/Admin/small-noimages.png');
    }
}
$(document).on("change", "#input_Brands", function () {
    readBrand(this)
})



$(document).on("click", "#_deleteBrand", function () {

    $('#_deleteBrand').attr('bID', $(this).attr('value'));
    var message = $('#DeletewithJS_Brand').attr('message');


    $("#modal-info_Delete").modal({ show: true });

    $(".modal-body").empty();

    $(".modal-body").append("<i class='fa fa-warning'></i>" + message + " Kaydını Silmek İstediğinize Eminmisiniz ? </span>");

    event.preventDefault();

    return false;
})

$(document).on("click", "#btnContinue", function () {

    //View den Hidden la message gönderiyoruz o mesaja göre neyi silme yaptıracağına yönlendiriyoruz.
    //sID ve pID satırların ıd leri aynı fakat value leri farklı olduğundan ilk satırın valuesini almaması için farklı bir değere atıyoruz id leri 


    var message = $('#DeletewithJS_Brand').attr('message');
    var ID_Brand = $('#_deleteBrand').attr('bID');

    event.preventDefault();
    if (message == "Marka") {
        $.ajax({
            type: "post",
            url: "/Admin/Slide_Brand",
            datatype: "json",
            data: { "brand_id": ID_Brand },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR + "-" + textStatus + "-" + errorThrown);
            },
            success: function (data) {
                window.location = "/Admin/Brands";

            }

        });
    }

})


////////////////////////////Aboutus_Services/////////////////////////////////////Aboutus_Services/////////////////////////////////////////Aboutus_Services

$(document).on("click", "#input_aboutus_button", function () {

    //var AboutusText = $("input_aboutus").innerHTML;

    var AboutusText = document.getElementById("input_aboutus").value;
    //alert(AboutusText);
    event.preventDefault();
    $.ajax({
        type: "post",
        url: "/Admin/Aboutus",
        datatype: "json",
        data: { "aboutustext": AboutusText },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR + "-" + textStatus + "-" + errorThrown);
        },
        success: function (data) {
            window.location = "/Admin/Aboutus_Services";

        }

    });
})


$(document).on("click", "#input_services_trigger", function () {
    $('#input_services').click();
})
