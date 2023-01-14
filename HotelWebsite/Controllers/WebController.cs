using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebsite.Controllers
{
    public class WebController : Controller
    {
        // GET: Web
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Rooms()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult AdminPanel()
        {
            return View();
        }
    }
}