using AracIhaleCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        Model1 model1 = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult KullaniciTanimlama()
        {
            var data = model1.Kullanicis.ToList();
            return View(data);
        }

        [Authorize]
        [HttpPost]
        //public ActionResult KullaniciEkle(Kullanici yeniKullanici)
        //{
        //    if (ModelState.IsValid)
        //    {
           

        //        model1.Kullanicis.Add(yeniKullanici);
        //        model1.SaveChanges();

        //    }
        //    return View("KullaniciTanimlama");
        //}

        public ActionResult KullaniciEkle(Kullanici yeniKullanici)
        {
            if (ModelState.IsValid)
            {
                model1.Kullanicis.Add(yeniKullanici);
                model1.SaveChanges();
                return RedirectToAction("KullaniciTanimlama");
            }
            return View("KullaniciTanimlama");
        }
        [HttpPost]
        [Authorize]
        public ActionResult KullaniciSil(int? KullaniciID)
        {
            if (KullaniciID.HasValue)
            {
                // Kullanici tablosundan silme işlemi
                var kullanici = model1.Kullanicis.Find(KullaniciID);
                if (kullanici != null)
                {
                    model1.Kullanicis.Remove(kullanici);
                    model1.SaveChanges();
                    var girisler = model1.Giris.Where(g => g.KullaniciID == KullaniciID);
                if (girisler != null && girisler.Any())
                {
                    model1.Giris.RemoveRange(girisler);
                    model1.SaveChanges();
                }
                }

                // Giri tablosundan silme işlemi
             
            }

            return RedirectToAction("KullaniciTanimlama");
        }

        [Authorize]
        public ActionResult KullaniciDuzenle(int? KullaniciID)
        {
            if (KullaniciID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kullanici kullanici = model1.Kullanicis.Find(KullaniciID);
            if (kullanici == null)
            {
                return HttpNotFound();
            }

            return View(kullanici);
        }

        [HttpPost]
        [Authorize]
        public ActionResult KullaniciGuncelle(Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                model1.Kullanicis.Attach(kullanici);
                model1.Entry(kullanici).State = EntityState.Modified;
                model1.SaveChanges();
                return RedirectToAction("KullaniciTanimlama");
            }
            return View(kullanici);
        }

    }
}