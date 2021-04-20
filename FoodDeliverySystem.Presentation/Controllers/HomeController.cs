using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliverySystem.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly FoodDeliveryContext db = new FoodDeliveryContext();
        private readonly IDiscountDetailRepository _discountDetailRepository;
        private readonly IDiscountRepository _discountRepository;

        public HomeController(IDiscountDetailRepository discountDetailRepository,
            IDiscountRepository discountRepository)
        {
            _discountDetailRepository = discountDetailRepository;
            _discountRepository = discountRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var listDiscount = _discountRepository.GetAll();
            return View(listDiscount);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}