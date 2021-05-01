using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;

namespace FoodDeliverySystem.Presentation.Controllers
{
    public class UsersController : Controller
    {
        private FoodDeliveryContext db = new FoodDeliveryContext();
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        [HttpGet]
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(Session["userEmail"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "user_id,user_name,user_email,user_sex,user_password,user_image,user_phone,user_address,user_role_id")] User user, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                user.user_role_id = 2;
                if (image == null)
                {
                    user.user_image = "user1.jpg";
                }
                else
                {
                    string image1 = image.FileName;
                    user.user_image = image1;
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Users");
            }
            return View(user);
        }

        // GET: Users/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.user_role_id = new SelectList(db.Roles, "role_id", "role_description");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_email,user_sex,user_password,user_image,user_phone,user_address,user_role_id")] User user, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                user.user_role_id = 2;
                if (image == null)
                {
                    user.user_image = "user1.jpg";
                }
                else
                {
                    string image1 = image.FileName;
                    user.user_image = image1;
                }
                db.Users.Add(user);
                db.SaveChanges();
                return Content("<script language='javascript' type='text/javascript'>alert('Bạn đã đăng ký thành công!'); window.location.href='https://localhost:44320/'</script>");
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            var listUser = _userRepository.GetAll();
            var checkLogin = listUser.Where(x => x.user_email == user.user_email && x.user_password == user.user_password).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["userId"] = checkLogin.user_id.ToString();
                Session["userName"] = checkLogin.user_name.ToString();
                Session["userImg"] = checkLogin.user_image.ToString();
                Session["userEmail"] = checkLogin.user_email.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Sai tên đăng nhập hoặc mật khẩu!";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("userName");
            Session.Remove("userImg");
            Session.Remove("userEmail");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GoDetail()
        {
            if(Session["userName"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var name = Session["userEmail"].ToString();
            var user = _userRepository.FindAll(x => x.user_email == name).FirstOrDefault();
            return RedirectToAction("Details", "Users", new { id = user.user_id});
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
