using AracIhaleCore.Entities;
using AracIhaleDAL.VM;
using AracIhaleDAL.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class IhaleListeleController : Controller
    {
        // GET: IhaleListele
        private Model1 db;
        private AracIhaleDAL.DAL.AracIhaleDAL ihaleDAL;

        public IhaleListeleController()
        {
            db = new Model1();
            ihaleDAL = new AracIhaleDAL.DAL.AracIhaleDAL();

        }
        public ActionResult Index()
        {
            return View();
        }

    

        [Authorize]
        public ActionResult IhaleListeleme()
        {
            // Tüm ihalenin listesi
            var ihaletList = db.IhaleListesis.ToList() ?? new List<IhaleListesi>();
            IhaleVM ihaleViewModel = new IhaleVM
            {
                IhaleListesis = ihaletList
            };

            // IhaleViewModel nesnesini görünüme geçir
            return View(ihaleViewModel);
        }

        [Authorize]
        public ActionResult YeniIhaleOlustur()
        {

            var ihaleViewModel = ihaleDAL.GetIhaleViewModel();
            return View(ihaleViewModel);
        }
	

		[Authorize]
        [HttpPost]
        public ActionResult YeniIhaleOlustur(IhaleVM model)
        {
            if (ModelState.IsValid)
            {
                // İhaleViewModel'den IhaleListesi nesnesine veri aktarımı
                IhaleListesi ihale = new IhaleListesi
                {
                    AracID = model.AracID,
                    IhaleAdi = model.IhaleAdi,
                    IhaleBaslangicFiyati = model.IhaleBaslangicFiyati,
                    MinimumAlimFiyati = model.MinimumAlimFiyati,
                    ModelAdi=model.ModelAdi,
                    MarkaAdi=model.MarkaAdi,    
                    BireyselKurumsalID = model.BireyselKurumsalID,
                    KurumsalSirketAdi = model.KurumsalSirketAdi,
                    IhaleStatuID = model.IhaleStatuID,
                    IhaleBaslangicTarihi = model.IhaleBaslangicTarihi,
                    IhaleBitisTarihi = model.IhaleBitisTarihi,
                    IhaleBaslangicSaati = model.IhaleBaslangicSaati,
                    IhaleBitisSaati = model.IhaleBitisSaati
                };

                // IhaleListesi'nin kaydedilmesi
            ihaleDAL.SaveAracIhale(ihale);

                return RedirectToAction("IhaleListeleme");
            }

            // Eğer ModelState geçersizse, hata mesajlarıyla birlikte aynı sayfayı tekrar göster
            return View(model);
        }


    }
}
