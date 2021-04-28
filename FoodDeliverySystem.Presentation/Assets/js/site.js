
var countTweet = 1;
sessionStorage.setItem("location", "Hà Nội")

$('#Btn-More-Deal').on("click", function () {
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: 'Restaurants/GetListDealRestaurant',
            contentType: "application/json; charset=utf-8",
            data: { restaurantCount: countTweet },
            dataType: "json",
            success: function (data) {
                if (data.length > 0) {
                    countTweet = countTweet + 1;
                    let rs = JSON.parse(data)
                    for (let item of rs) {
                        //console.log(item.Restaurant.restaurant_name)
                        let ht = '<div class="item-restaurant">' +
                            '<a target="_blank" class="item-content" href="/Restaurants/RestaurantDetail/' + item.Restaurant.restaurant_id + '">' +
                            '<div class="img-restaurant">' +
                            '<img src="/Assets/images/' + item.Restaurant.restaurant_image + '" />' +
                            '</div>' +
                            '<div class="info-restaurant">' +
                            '<div class="info-basic-res">' +
                            '<h4 class="name-res" title="' + item.Restaurant.restaurant_name + '">' + item.Restaurant.restaurant_name + '</h4>' +
                            '<div class="address-res" title="' + item.Restaurant.restaurant_address + '">' + item.Restaurant.restaurant_name + '</div>' +
                            '</div>' +
                            '<p class="content-promotion">' +
                            '<img class="mr-1" width="17" height="17" src="/Assets/images/tags.svg"/>' +
                            item.Discounts[0].discount_content +
                            '</p>' +
                            '</div>' +
                            '</a>' +
                            '</div>'
                        $('#deal-list-restaurant').append(ht);
                        //console.log(item.Discount[0].discount_content);
                        ////for (let d of item.Discount) {
                        ////    console.log(d.discount_content);
                        ////}
                    }
                }
                else {
                    alert('No More Records to Load')
                }
            },
            error: function () {
                alert("Error");
            }
        });
    });
});

var page = 1
var load = function (location, page) {
    $.ajax({
        type: "GET",
        url: 'Restaurants/GetListRestaurantInLocation',
        contentType: "application/json; charset=utf-8",
        data: {
            location: location,
            page: page
        },
        dataType: "json",
        success: function (result) {
            if (result.data.length > 0) {
                let rs = JSON.parse(result.data)
                for (let item of rs) {
                    let ht = '<div class="item-restaurant">' +
                        '<a class="item-content" href="/Restaurants/RestaurantDetail/' + item.Restaurant.restaurant_id + '">' +
                        '<div class="row no-gutters">' +
                        '<div class="col-auto">' +
                        '<div class="img-restaurant">' +
                        '<img src="/Assets/images/' + item.Restaurant.restaurant_image + '" />' +
                        '</div>' +
                        '</div>' +
                        '<div class="col">' +
                        '<div class="info-restaurant">' +
                        '<div class="name-res">' +
                        '<img width="16" height="16" src="/Assets/images/shield.svg" />' +
                        item.Restaurant.restaurant_name +
                        '</div>' +
                        '<div class="row">' +
                        '<div class="col">' +
                        '<div class="address-res mb-1">' +
                        item.Restaurant.restaurant_address +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '<div class="item-res-info">' +
                        '<img width="16" height="16" src="/Assets/images/label-price.svg" />' +
                        'Tối thiểu 20k' +
                        '<img width="16" height="16" src="/Assets/images/number-one.svg" />' +
                        'Tốt nhất' +
                        '</div>' +
                        '<p class="content-promotion pt-1 pl-0 pb-0">' +
                        '<img class="mr-1" width="17" height="17" src="/Assets/images/tags.svg" />' +
                        item.Discounts[0].discount_content +
                        '</p>' +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '</a>' +
                        '</div>'
                    $('#near-list-restaurant').append(ht);
                }
            }
            else {
                alert('No More Records to Load')
            }
        },
        error: function () {
            alert("Error");
        }
    });
}

var search = function (location, something, page) {
    $.ajax({
        type: "GET",
        url: 'Restaurants/GetListRestaurantBySomething',
        contentType: "application/json; charset=utf-8",
        data: {
            location: location,
            something: something,
            page: page
        },
        dataType: "json",
        success: function (result) {
            let rs = JSON.parse(result.data)
            let ht = '<div class="now-idea-searching">' +
                '<div class="now-list-restaurant-row">'
            for (let item of rs) {
                ht +=
                    '<div class="item-restaurant">' +
                    '<a class="item-content" href="/Restaurants/RestaurantDetail/' + item.restaurant_id + '">' +
                    '<div class="img-restaurant">' +
                    '<img src="/Assets/images/' + item.restaurant_image + '" alt="' + item.restaurant_name + '" title="' + item.restaurant_name + '">' +
                    '</div>' +
                    '<div class="info-restaurant">' +
                    '<div class="name-res">' + item.restaurant_name + '</div>' +
                    '<div class="address-res">' + item.restaurant_address + '</div>' +
                    '</div>' +
                    '</a>' +
                    '</div>'
            }
            ht += '</div>' +
                '</div>'
            $('#frmSearch').append(ht);
        },
        error: function () {
            alert("Error");
        }
    });
}

$('#txtSearchHome').change(() => {
    if (!$('#txtSearchHome').val()) {
        $('.now-idea-searching').remove()
    } else {
        $('.now-idea-searching').remove()
        search($('#selectedLocation option:selected').text(), $('#txtSearchHome').val(), 1)
    }
})

$('#Btn-More-Location').on("click", function () {
    if ($('#selectedLocationByDistrict option:selected').text() == "Chọn quận/ huyện") {
        $(document).ready(function () {
            load($('#selectedLocation option:selected').text(), page++)
        });
    } else {
        let loca = $('#selectedLocationByDistrict option:selected').text() + ", " + $('#selectedLocation option:selected').text()
        $(document).ready(function () {
            load(loca, page++)
        });
    }

});

$('#selectedLocation').change(() => {
    sessionStorage.setItem("location", $('#selectedLocation option:selected').text())
    $('#near-list-restaurant').empty()
    page = 1
    load($('#selectedLocation option:selected').text(), page++)
})

$('#selectedLocationByDistrict').change(() => {
    $('#near-list-restaurant').empty()
    page = 1
    load($('#selectedLocationByDistrict option:selected').text(), page++)
})

//document.querySelector('#find-me').addEventListener('click', showMap);
//$("#osm-map").on('load', function () {
//    console.log("????????????????");
//    const element = $('#osm-map').get(0)
//    element.style = 'height:300px;';

//    if (!navigator.geolocation) {
//        alert("zolo")
//    } else {
//        alert("???")
//        navigator.geolocation.getCurrentPosition((position) => {
//            const latitude = position.coords.latitude;
//            const longitude = position.coords.longitude;
//            const map = L.map(element)
//            L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
//                attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
//            }).addTo(map)
//            const target = L.latLng(latitude, longitude)
//            map.setView(target, 14)
//            L.marker(target).addTo(map)
//        }, () => {
//            alert("cc")
//        })
//    }
//})

//lat: 10.754251475450005,
//    lon: 106.6226725711504,

$(document).ready(() => {
    function getLocation() {
        if (!navigator.geolocation) {
            alert("zolo")
        } else {
            navigator.geolocation.getCurrentPosition((position) => {
                const latitude = position.coords.latitude;
                const longitude = position.coords.longitude;
                $.ajax({
                    type: "GET",
                    url: "https://nominatim.openstreetmap.org/reverse",
                    contentType: "application/json; charset=utf-8",
                    data: {
                        format: 'json',
                        lat: latitude,
                        lon: longitude,
                        addressdetails: 18
                    },
                    dataType: "json",
                    success: (data) => {
                        $('#selectedLocation').val(data.address.city)
                        $('#Btn-More-Location').trigger("click")
                    },
                    error: (e) => {
                        $('#selectedLocation').val("Hanoi")
                    }
                })

            }, () => {
                $('#selectedLocation').val("Hanoi")
            })
        }
    }
    getLocation()
})

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#avatar_user').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]); // convert to base64 string
    }
}

$("#validatedCustomFile").change(function () {
    readURL(this);
});





