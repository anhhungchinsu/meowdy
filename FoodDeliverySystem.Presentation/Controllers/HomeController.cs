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
    public class HomeController : Controller
    {
        private readonly FoodDeliveryContext db = new FoodDeliveryContext();
        private readonly IUserRepository _userRepository;


        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var listUser = _userRepository.GetAll();
            var checkLogin = listUser.Where(x => x.user_email == user.user_email && x.user_password == user.user_password).FirstOrDefault();
            if(checkLogin != null)
            {
                Session["userName"] = checkLogin.user_name.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong dmm";
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}