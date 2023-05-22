using AracIhaleDAL.DAL;
using AracIhaleCore.Entities;
using AracIhaleDAL.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class AracController : Controller
    {
      
      
        public ActionResult Index()
        {
            return View();
        }
        Model1 model1 = new Model1();
        AracListelemeDAL aracListelemeDAL = new AracListelemeDAL();

        [Authorize]
        public ActionResult AracListeleme()
        {
            var araclar = model1.Araclars.Include(a => a.AracOzellik)
                                          .Include(a => a.BireyselKurumsal)
                                          .Include(a => a.Statu)
                                          .ToList();

            var viewModel = new AracListeleVM
            {
                AraclarList = araclar,
                StatuList = aracListelemeDAL.GetSelectList(model1.Status.ToList(), "StatuID", "StatuAdi"),
                KullaniciList=aracListelemeDAL.GetSelectList(model1.Kullanicis.ToList(), "KullaniciID", "KullaniciAdi"),
                AracMarkaList = aracListelemeDAL.GetSelectList(model1.AracMarkas.ToList(), "AracMarkaID", "MarkaAdi"),
                AracModelList = aracListelemeDAL.GetSelectList(model1.AracModels.ToList(), "AracModelID", "ModelAdi"),
                BireyselKurumsalList = aracListelemeDAL.GetSelectList(model1.BireyselKurumsals.ToList(), "BireyselKurumsalID", "Durum")
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult FiltreliAracListele(AracListeleVM model)
        {
            var filtreliAraclar = aracListelemeDAL.GetFiltreliAraclar(model);
            model.AraclarList = filtreliAraclar;

            // SelectList özelliklerini tekrar doldurun
            model.AracMarkaList = aracListelemeDAL.GetSelectList(model1.AracMarkas.ToList(), "AracMarkaID", "MarkaAdi");
       
            model.AracModelList = aracListelemeDAL.GetSelectList(model1.AracModels.ToList(), "AracModelID", "ModelAdi");
            model.BireyselKurumsalList = aracListelemeDAL.GetSelectList(model1.BireyselKurumsals.ToList(), "BireyselKurumsalID", "Durum");
            model.StatuList = aracListelemeDAL.GetSelectList(model1.Status.ToList(), "StatuID", "StatuAdi");

            return View("AracListeleme", model);
        }



        [Authorize]
    

        public ActionResult AracSil(int? id)
        {
            var arac = model1.Araclars.FirstOrDefault(a => a.AracID == id);

            if (arac != null)
            {
                var aracOzellik = model1.AracOzelliks.FirstOrDefault(o => o.AracOzellikID == arac.AracOzellikID);
                if (aracOzellik != null)
                {
                    model1.AracOzelliks.Remove(aracOzellik);
                    model1.SaveChanges();
                }

                var ilanBilgileri = model1.IlanBilgis.Where(i => i.AracID == arac.AracID).ToList(); 
                foreach (var ilanBilgi in ilanBilgileri)
                {
                    model1.IlanBilgis.Remove(ilanBilgi);
                }
                model1.SaveChanges();

               
            }
			model1.Araclars.Remove(arac);
			model1.SaveChanges();
			return RedirectToAction("AracListeleme");
        }



        [Authorize]
        public ActionResult AracDuzenle(AracDuzenleVM model)
        {
            AracSecDAL aracSecDAL = new AracSecDAL();
            model.AracMarkaList=aracSecDAL.MarkaSec();
            model.AracModelList=aracSecDAL.ModelSec();
            model.BireyselKurumsalList=aracSecDAL.BkSec();
            model.StatuList=aracSecDAL.StatuSec();

            var yeniozellik = new AracOzellik
            {

                AracMarkaID = model.AracMarkaID,
                AracModelID = model.AracModelID,
            };

            var yenioz = new Araclar
            {

                BireyselKurumsalID = model.BireyselKurumsalID,
                StatuID = model.StatuID,

            };
            model1.Araclars.Add(yenioz);
            model1.AracOzelliks.Add(yeniozellik);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AracGuncelle(AracDuzenleVM model)
        {
            if (ModelState.IsValid)
            {

                var arac = model1.Araclars.Find(model.AracID);

                if (arac != null)
                {
                    arac.BireyselKurumsalID = model.BireyselKurumsalID;
                    arac.AracOzellik.AracMarkaID = model.AracMarkaID;
                    arac.AracOzellik.AracModelID = model.AracModelID;
                    arac.StatuID = model.StatuID;

                    model1.Entry(arac).State = EntityState.Modified;
                    model1.SaveChanges();
                }

                return RedirectToAction("AracListeleme");
            }

            return View(model);
        }


        [Authorize]
        public ActionResult AracDetayBilgisi()

        {

            var araarac = TempData["ararac"] as AracOzellikVM;
 
          
            AracSecDAL aracSecDAL = new AracSecDAL();
            ViewBag.BireyselKurumsalList = aracSecDAL.BkSec();
            ViewBag.StatuList = aracSecDAL.StatuSec();
            ViewBag.AracMarkaList = aracSecDAL.MarkaSec();
            ViewBag.AracModelList=aracSecDAL.ModelSec();
            ViewBag.GovdeTipiList = aracSecDAL.GovdeSec();
            ViewBag.YilList = aracSecDAL.YilSec();
            ViewBag.YakitTipiList = aracSecDAL.YakitSec();
            ViewBag.RenkList = aracSecDAL.RenkSec();
            ViewBag.VitesTipilist = aracSecDAL.VitesSec();
            ViewBag.KmList = aracSecDAL.KmBilgisi();
            ViewBag.KurumsalList = aracSecDAL.KurumsalSirketAdi();
            ViewBag.GorselList = aracSecDAL.GorselSec();
            ViewBag.DonanimList = aracSecDAL.Donanim();
            ViewBag.FiyatList = aracSecDAL.Fiyat();
            ViewBag.KullaniciList = aracSecDAL.KullaniciSec();

            ViewBag.VersiyonList = aracSecDAL.Versiyon();


            if (araarac == null)
            {

                AracOzellikVM aracOzellikVM = new AracOzellikVM();
                return View(aracOzellikVM);
            }
            return View(araarac);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AracDetayBilgisi(AracOzellikVM ozellikVM,string name)
        {

            if (name=="İlanBilgisi")
            {
                TempData["ararac"]=ozellikVM;
                return RedirectToAction("İlanBilgileri","AdminPanel");
            }
            else if (name=="TramerBilgisi")
            {
                TempData["ararac"]=ozellikVM;
                return RedirectToAction("TramerBilgileri", "Tramer");
            }

            AracEkleDAL aracEkleDAL = new AracEkleDAL();
            aracEkleDAL.AracEkle(ozellikVM);
        

            return RedirectToAction("AracListeleme");
        }
    }
}