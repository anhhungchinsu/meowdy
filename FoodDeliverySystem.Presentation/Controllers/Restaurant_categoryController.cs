using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FoodDeliverySystem.Presentation.Controllers
{
    public class Restaurant_categoryController : Controller
    {
        private readonly FoodDeliveryContext db = new FoodDeliveryContext();
        private readonly IRestaurantCategoryRepository _restaurantCategoryRepository;

        public Restaurant_categoryController(IRestaurantCategoryRepository restaurantCategoryRepository)
        {
            _restaurantCategoryRepository = restaurantCategoryRepository;
        }

        // GET: Restaurant_category
        public ActionResult ListCategory()
        {
            var restaurantCategorys = _restaurantCategoryRepository.GetAll();
            ViewBag.restaurantCategorys = new SelectList(restaurantCategorys);
            return PartialView(restaurantCategorys);
        }

        // GET: Restaurant_category/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant_category restaurant_category = db.Restaurant_category.Find(id);
            if (restaurant_category == null)
            {
                return HttpNotFound();
            }
            return View(restaurant_category);
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
