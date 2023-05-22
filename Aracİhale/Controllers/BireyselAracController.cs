using AracIhaleDAL.DAL;
using AracIhaleCore.Entities;
using AracIhaleDAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class BireyselAracController : Controller
    {
        // GET: BireyselArac
        Model1 db=new Model1();
        BireyselAracDAL bireyselArac=new BireyselAracDAL();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult BireyselArac()
        {

            var bireyselarac = db.Araclars
                                   .ToList();
            var viewModel = new BireyselAracVM
            {
                AraclarListesi = bireyselarac,
                StatuList = bireyselArac.GetSelectList(db.Status.ToList(), "StatuID", "StatuAdi"),
                MarkaList= bireyselArac.GetSelectList(db.AracMarkas.ToList(), "AracMarkaID", "MarkaAdi"),
                ModelList = bireyselArac.GetSelectList(db.AracModels.ToList(), "AracModelID", "ModelAdi"),
           
            };
            return View(viewModel);
  
        }
        [Authorize]
        [HttpPost]
        public ActionResult BireyselAracGuncelle(BireyselAracListeleVM model)
        {
            if (ModelState.IsValid)
            {
                var aracOzellik = new AracOzellik
                {
                    AracMarkaID = model.AracMarkaID,
                    AracModelID = model.AracModelID,
                };

                var arac = db.Araclars.Find(model.AracID);

                if (arac != null)
                {
                
                    arac.StatuID = model.StatuID;
                    db.AracOzelliks.Add(aracOzellik);
                    db.SaveChanges();
                }

                return RedirectToAction("BireyselArac");
            }

            return View(model);
          
        }

  

        [HttpPost]
        public ActionResult FiltreliBireyselArac(BireyselAracVM model)
        {
            var filtreliAraclar = bireyselArac.GetFiltreliAraclar(model);
            model.AraclarListesi = filtreliAraclar;

            // SelectList özelliklerini tekrar doldurun
            model.MarkaList = bireyselArac.GetSelectList(db.AracMarkas.ToList(), "AracMarkaID", "MarkaAdi");
            model.ModelList = bireyselArac.GetSelectList(db.AracModels.ToList(), "AracModelID", "ModelAdi");
     
            model.StatuList = bireyselArac.GetSelectList(db.Status.ToList(), "StatuID", "StatuAdi");

            return View("BireyselArac", model);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BireyselAracSil(int? AracID)
        {
            if (ModelState.IsValid)
            {
                Araclar araclar = db.Araclars.Find(AracID);
                if (araclar == null)
                {
                    return HttpNotFound();
                }
                db.Araclars.Remove(araclar);
                db.SaveChanges();
                return RedirectToAction("BireyselArac");
            }
            return View();


        }

        [Authorize]
        public ActionResult BireyselAracDuzenle(AracDuzenleVM model)
        {
            AracSecDAL aracSecDAL = new AracSecDAL();
            model.AracMarkaList=aracSecDAL.MarkaSec();
            //model.AracModelList=aracSecDAL.ModelSec();
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
            db.Araclars.Add(yenioz);
            db.AracOzelliks.Add(yeniozellik);

            return View(model);
        }

      

    }
}