using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Models.DBContext;
using FoodDeliverySystem.Presentation.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace FoodDeliverySystem.Presentation.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly FoodDeliveryContext db = new FoodDeliveryContext();
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDiscountDetailRepository _discountDetailRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IFoodRepository _foodRepository;


        public RestaurantsController(IRestaurantRepository restaurantRepository,
            IDiscountDetailRepository discountDetailRepository,
            IDiscountRepository discountRepository,
            IMenuRepository menuRepository,
            IFoodRepository foodRepository)
        {
            _restaurantRepository = restaurantRepository;
            _discountDetailRepository = discountDetailRepository;
            _discountRepository = discountRepository;
            _menuRepository = menuRepository;
            _foodRepository = foodRepository;
        }

        public ActionResult RestaurantDetail(short id)
        {
            var restaurant = _restaurantRepository.GetById(id);
            var restaurantDetailViewModel = new RestaurantDetailViewModel()
            {
                Restaurant = restaurant,
                Discounts = _discountRepository.GetDiscountsByUser((short)restaurant.restaurant_user_id),
            };
            return View(restaurantDetailViewModel);
        }

        // GET: Restaurants
        public ActionResult ListDealRestaurant()
        {
            var distinctDiscountDetails = _discountDetailRepository.getDistincts();
            IEnumerable<Restaurant> listRestaurants = _restaurantRepository.GetAll().Where(item => distinctDiscountDetails.Any(x => x.discount_detail_user_id.Equals(item.restaurant_user_id)));
            var list = new List<RestaurantDetailViewModel>();
            foreach (var item in listRestaurants)
            {
                var restaurantDetailViewModel = new RestaurantDetailViewModel()
                {
                    Restaurant = item,
                    Discounts = _discountRepository.GetDiscountsByUser((short)item.restaurant_user_id),
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
                        Discounts = _discountRepository.GetDiscountsByUser((short)item.restaurant_user_id),
                    };
                    list.Add(restaurantDetailViewModel);
                }
                var count = list.Count();
                var countData = count - (9 * restaurantCount);
                var list2 = list.Where(x => x.Restaurant.restaurant_id <= countData && x.Restaurant.restaurant_id >= 1).OrderByDescending(x => x.Restaurant.restaurant_id).Take(9);
                return Json(JsonFormatter.Format(list2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    success = false,
                    ex = e.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ListNearRestaurant()
        {
            var listRestaurants = _restaurantRepository.GetAll().Where(p => p.restaurant_address.Contains("Bắc Từ Liêm"));
            var list = new List<RestaurantDetailViewModel>();
            foreach (var item in listRestaurants)
            {
                var restaurantDetailViewModel = new RestaurantDetailViewModel()
                {
                    Restaurant = item,
                    Discounts = _discountRepository.GetDiscountsByUser((short)item.restaurant_user_id),
                };
                list.Add(restaurantDetailViewModel);
            }
            var list2 = list.Take(6);
            return PartialView(list2);
        }

        int pageSize = 6;
        [HttpGet]
        public JsonResult GetListRestaurantInLocation(string location, int? page)
        {
            try
            {
                
                var listRestaurants = _restaurantRepository.GetAll().Where(p => p.restaurant_address.Contains(location));
                var list = new List<RestaurantDetailViewModel>();
                foreach (var item in listRestaurants)
                {
                    var restaurantDetailViewModel = new RestaurantDetailViewModel()
                    {
                        Restaurant = item,
                        Discounts = _discountRepository.GetDiscountsByUser((short)item.restaurant_user_id),
                    };
                    list.Add(restaurantDetailViewModel);
                }
                if (page > 0)
                {
                    page = page;
                }
                else
                {
                    page = 1;
                }
                int start = (int)(page - 1) * pageSize;
                ViewBag.pageCurrent = page;
                int totalPage = list.Count();
                float totalNumsize = (totalPage / (float)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);
                ViewBag.numSize = numSize;
                var list2 = list.OrderByDescending(x => x.Restaurant.restaurant_id).Skip(start).Take(pageSize);
                return Json(new
                {
                    data = JsonFormatter.Format(list2),
                    pageCurrent = page,
                    numSize = numSize
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                {
                    return Json(new
                    {
                        success = false,
                        ex = e.Message
                    }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public JsonResult GetListRestaurantBySomething(string location, string something, int? page)
        {
            try
            {
                var listRestaurants = _restaurantRepository.GetAll().Where(p => p.restaurant_address.Contains(location));
                var list = listRestaurants.Where(p => (p.restaurant_address.Contains(something) || p.restaurant_name.Contains(something)));
                if (page > 0)
                {
                    page = page;
                }
                else
                {
                    page = 1;
                }
                int start = (int)(page - 1) * pageSize;
                ViewBag.pageCurrent = page;
                int totalPage = list.Count();
                float totalNumsize = (totalPage / (float)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);
                ViewBag.numSize = numSize;
                var list2 = list.OrderByDescending(x => x.restaurant_id).Skip(start).Take(pageSize);
                return Json(new
                {
                    data = JsonFormatter.Format(list2),
                    pageCurrent = page,
                    numSize = numSize
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                {
                    return Json(new
                    {
                        success = false,
                        ex = e.Message
                    }, JsonRequestBehavior.AllowGet);
                }
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
