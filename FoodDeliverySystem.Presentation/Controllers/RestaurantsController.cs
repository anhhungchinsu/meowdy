using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FoodDeliverySystem.Presentation.ViewModels;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace FoodDeliverySystem.Presentation.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly FoodDeliveryContext db = new FoodDeliveryContext();
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDiscountDetailRepository _discountDetailRepository;
        private readonly IDiscountRepository _discountRepository;


        public RestaurantsController(IRestaurantRepository restaurantRepository, 
            IDiscountDetailRepository discountDetailRepository,
            IDiscountRepository discountRepository)
        {
            _restaurantRepository = restaurantRepository;
            _discountDetailRepository = discountDetailRepository;
            _discountRepository = discountRepository;
        }

        // GET: Restaurants
        public ActionResult ListDealRestaurant()
        {
            var distinctDiscountDetails = _discountDetailRepository.getDistincts();
            IEnumerable<Restaurant> listRestaurants = _restaurantRepository.GetAll().Where(item => distinctDiscountDetails.Any(x => x.discount_detail_user_id.Equals(item.restaurant_user_id)));
            var list = new List<RestaurantDetailViewModel>();
            foreach(var item in listRestaurants)
            {
                var restaurantDetailViewModel = new RestaurantDetailViewModel()
                {
                    Restaurant = item,
                    Discount = _discountRepository.GetDiscountsByUser((short)item.restaurant_user_id),
                };
                list.Add(restaurantDetailViewModel);
            }
            var list2 = list.Take(9);
            return PartialView(list2);
        }

        [HttpGet]
        public JsonResult GetListDealRestaurant(int? restaurantCount)
        {
            try
            {
                var distinctDiscountDetails = _discountDetailRepository.getDistincts();
                IEnumerable<Restaurant> listRestaurants = _restaurantRepository.GetAll().Where(item => distinctDiscountDetails.Any(x => x.discount_detail_user_id.Equals(item.restaurant_user_id)));
                var list = new List<RestaurantDetailViewModel>();
                foreach (var item in listRestaurants)
                {
                    var restaurantDetailViewModel = new RestaurantDetailViewModel()
                    {
                        Restaurant = item,
                        Discount = _discountRepository.GetDiscountsByUser((short)item.restaurant_user_id),
                    };
                    list.Add(restaurantDetailViewModel);
                }
                var count = list.Count();
                var countData = count - (9 * restaurantCount);
                var list2 = list.Where(x => x.Restaurant.restaurant_id <= countData && x.Restaurant.restaurant_id >= 1).OrderByDescending(x => x.Restaurant.restaurant_id).Take(9);

                string rs = JsonConvert.SerializeObject(list2, Formatting.None);
                string data = Regex.Replace(rs, @"\\r\\n", "");
                string finaldata = Regex.Replace(data, @"\\""", "");
                return Json(finaldata, JsonRequestBehavior.AllowGet);
            } 
            catch (Exception e)
            {
                return Json(new { 
                    success = false,
                    ex = e.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
