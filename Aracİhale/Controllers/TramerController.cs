using AracIhaleCore.Entities;
using AracIhaleDAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class TramerController : Controller
    {
        // GET: Tramer
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult TramerBilgileri()
        {
            var ararac = TempData["ararac"] as AracOzellikVM;


            return View(ararac);
          
        }

        [Authorize]
        [HttpPost]
        public ActionResult TramerBilgileri(AracOzellikVM ararac)
        {
            TempData["ararac"]=ararac;
            //IlanEkleDAL ilanEkleDAL=new IlanEkleDAL();
            // ilanEkleDAL.IlanEkle(ilan);ü

            return RedirectToAction("AracDetayBilgisi", "Arac");
          
        }

    }
}