using HotelWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebsite.Controllers
{
    public class OdaController : Controller
    {
        HotelEntities3 db = new HotelEntities3();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Odalars.ToList());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Odalar ekle)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    db.Odalars.Add(ekle);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            using (HotelEntities3 db = new HotelEntities3())
            {
                return View(db.Odalars.Where(x => x.odaNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Odalar Duzenle)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    db.Entry(Duzenle).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            using (HotelEntities3 db = new HotelEntities3())
            {
                return View(db.Odalars.Where(x => x.odaNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Sil(int id, Odalar Sil)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    Sil = db.Odalars.Where(x => x.odaNo == id).FirstOrDefault();
                    db.Odalars.Remove(Sil);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}