using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;
using FoodDeliverySystem.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliverySystem.Presentation.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserOrderRepository _userOrderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IFoodRepository _foodRepository;

        public CheckoutController(IOrderRepository orderRepository, IUserOrderRepository userOrderRepository, IOrderDetailRepository orderDetailRepository, IFoodRepository foodRepository)
        {
            _orderRepository = orderRepository;
            _userOrderRepository = userOrderRepository;
            _orderDetailRepository = orderDetailRepository;
            _foodRepository = foodRepository;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult checkout(Order Order, short? restaurantId, List<Order_detail> Order_details)
        {

            if (ModelState.IsValid)
            {
                Order.order_created_date = DateTime.Now;
                _orderRepository.Add(Order);

                var restaurantOrder = new User_order()
                {
                    user_id = (short)restaurantId,
                    user_order_created_date = DateTime.Now,
                    order_id = Order.order_id
                };
                _userOrderRepository.Add(restaurantOrder);
                var customerOrder = new User_order()
                {
                    user_id = (short)Convert.ToInt32(Session["userId"]),
                    user_order_created_date = DateTime.Now,
                    order_id = Order.order_id
                };
                _userOrderRepository.Add(customerOrder);

                foreach(var item in Order_details)
                {
                    item.Order_detail_order_id = Order.order_id;
                    _orderDetailRepository.Add(item);
                    var food = _foodRepository.GetById(item.Order_detail_food_id);
                    food.food_served += item.Order_detail_quantity;
                    food.food_quantity -= item.Order_detail_quantity;
                    _foodRepository.Update(food);
                }

                return RedirectToAction("Details", "Users", new { id = Session["userId"]});
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Something wrong wrong!');</script>");
        }
    }
}