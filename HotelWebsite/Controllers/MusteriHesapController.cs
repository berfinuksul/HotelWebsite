using HotelWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebsite.Controllers
{
    public class MusteriHesapController : Controller
    {
        HotelEntities3 db = new HotelEntities3();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.MusteriHesabis.ToList());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(MusteriHesabi ekle)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    db.MusteriHesabis.Add(ekle);
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
                return View(db.MusteriHesabis.Where(x => x.islemNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Duzenle(int id, MusteriHesabi Duzenle)
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
                return View(db.MusteriHesabis.Where(x => x.islemNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Sil(int id, MusteriHesabi Sil)
        {
            try
            {
                using (HotelEntities3 db = new HotelEntities3())
                {
                    Sil = db.MusteriHesabis.Where(x => x.islemNo == id).FirstOrDefault();
                    db.MusteriHesabis.Remove(Sil);
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