
var countTweet = 1;

$('#Btn-More').on("click", function () {
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
                            '<div class="address-res" title="' + item.Restaurant.restaurant_address + '">' + item.Restaurant.restaurant_name+'</div>' +
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
