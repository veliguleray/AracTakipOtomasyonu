using AracTakip.Models.veritabanı;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlTypes;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class HomeController : Controller
    {
        dbAracTakipEntities db=new dbAracTakipEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kayit(kisi_bilgileri P)
        {
            db.kisi_bilgileri.Add(P);
            db.SaveChanges();
            return RedirectToAction("otoparkcikis");
        }



        public ActionResult otoparkcikis()
        {
            var liste = db.kisi_bilgileri.ToList();
            return View(liste);
        }


        public ActionResult SIL(int id)
        {
            db.kisi_bilgileri.Remove(db.kisi_bilgileri.Find(id));
            db.SaveChanges();
            return RedirectToAction("otoparkcikis");

        }

        public ActionResult KisiGetir(int id)
        {
            var kisi = db.kisi_bilgileri.Find(id);
            return View("KisiGetir", kisi);
        }
        public ActionResult KisiyiGuncelle(kisi_bilgileri P1)
        {
            var kisi = db.kisi_bilgileri.Find(P1.kisi_id);
            kisi.tc_kimlik = P1.tc_kimlik;
            kisi.ad = P1.ad;
            kisi.soyad = P1.soyad;
            kisi.cep_telefonu = P1.cep_telefonu;
            kisi.adres = P1.adres;
            db.SaveChanges();
            return RedirectToAction("otoparkcikis");
        }



    }
}