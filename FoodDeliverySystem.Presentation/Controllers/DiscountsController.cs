using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;
using FoodDeliverySystem.Presentation.ViewModels;
using Newtonsoft.Json;

namespace FoodDeliverySystem.Presentation.Controllers
{
    public class DiscountsController : Controller
    {
        private FoodDeliveryContext db = new FoodDeliveryContext();
        private readonly IDiscountDetailRepository _discountDetailRepository;
        private readonly IDiscountRepository _discountRepository;

        public DiscountsController(IDiscountDetailRepository discountDetailRepository,
            IDiscountRepository discountRepository)
        {
            _discountDetailRepository = discountDetailRepository;
            _discountRepository = discountRepository;
        }
        // GET: Discounts
        public ActionResult Index()
        {
            var listDiscount = _discountRepository.GetAll();
            var rs = new List<DiscountWithCountViewModel>();
            foreach (var item in listDiscount)
            {
                rs.Add(new DiscountWithCountViewModel
                {
                    Discount = item,
                    Discount_Details = _discountDetailRepository.findById(item.discount_id),
                    Count = _discountDetailRepository.findById(item.discount_id).Count()
                }); ;
            }
            return PartialView(rs);
        }

        [HttpGet]
        public JsonResult GetDiscount(string code)
        {
            try
            {
                var item = _discountRepository.FindAll(p => p.discount_code.Contains(code)).FirstOrDefault();
                string rs = JsonConvert.SerializeObject(item, Formatting.None);
                string data = Regex.Replace(rs, @"\\r\\n", "");
                string finaldata = Regex.Replace(data, @"\\""", "");
                return Json(finaldata, JsonRequestBehavior.AllowGet);
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
