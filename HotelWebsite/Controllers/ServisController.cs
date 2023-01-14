using HotelWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebsite.Controllers
{
    public class ServisController : Controller
    {
        HotelEntities3 db = new HotelEntities3();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Servislers.ToList());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Servisler ekle)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    db.Servislers.Add(ekle);
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
                return View(db.Servislers.Where(x => x.servisNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Servisler Duzenle)
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
                return View(db.Servislers.Where(x => x.servisNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Sil(int id, Servisler Sil)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    Sil = db.Servislers.Where(x => x.servisNo == id).FirstOrDefault();
                    db.Servislers.Remove(Sil);
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