
var countTweet = 1;

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
                            '<a target="_blank" class="item-content" href="#">' +
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
                            item.Discount[0].discount_content +
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
$('#Btn-More-Location').on("click", function () {
    $(document).ready(function () {
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
                                '<a class="item-content" href="#">' +
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
                                item.Discount[0].discount_content +
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
        load("Cầu Giấy", page++)
    });
});

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

function showMap() {
    const element = $('#osm-map').get(0)
    element.style = 'height:300px;';

    if (!navigator.geolocation) {
        alert("zolo")
    } else {
        navigator.geolocation.getCurrentPosition((position) => {
            const latitude = position.coords.latitude;
            const longitude = position.coords.longitude;
            const map = L.map(element)
            L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            }).addTo(map)
            const target = L.latLng(latitude, longitude)
            map.setView(target, 14)
            L.marker(target).addTo(map)
        }, () => {
            alert("cc")
        })
    }
}

function getLocation() {
    if (!navigator.geolocation) {
        alert("zolo")
    } else {
        navigator.geolocation.getCurrentPosition((position) => {
            const latitude = position.coords.latitude;
            const longitude = position.coords.longitude;
            $.ajax({
                type: "GET",
                url: "https://nominatim.openstreetmap.org/reverse?format=json&lat=21.042736899999998&lon=105.74998389999999&addressdetails=18",
                contentType: "application/json; charset=utf-8",
                data: {
                    format: 'json',
                    lat: latitude,
                    lon: longitude
                },
                dataType: "json",
                success: (data) => {
                    console.log(data.address.suburb)
                },
                error: (e) => {
                    alert(e)
                }
            })

        }, () => {
            alert("cc")
        })
    }
}
