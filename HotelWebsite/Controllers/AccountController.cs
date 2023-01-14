using HotelWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelWebsite.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (HotelEntities3 db = new HotelEntities3())
            {
                var result = db.UserMasters.Where(x => x.Username == user.Username && x.Password == user.Password);
                if (result.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["msg"] = "hatalı";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}