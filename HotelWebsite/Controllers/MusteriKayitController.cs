using HotelWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebsite.Controllers
{
    public class MusteriKayitController : Controller
    {
        HotelEntities3 db = new HotelEntities3();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.MusteriKayits.ToList());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(MusteriKayit ekle)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    db.MusteriKayits.Add(ekle);
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
                return View(db.MusteriKayits.Where(x => x.musteriNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Duzenle(int id, MusteriKayit Duzenle)
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
                return View(db.MusteriKayits.Where(x => x.musteriNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Sil(int id, MusteriKayit Sil)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    Sil = db.MusteriKayits.Where(x => x.musteriNo == id).FirstOrDefault();
                    db.MusteriKayits.Remove(Sil);
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