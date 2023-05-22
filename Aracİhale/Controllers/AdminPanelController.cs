
using AracIhaleDAL.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AracIhaleCore.Entities;
using System.Web.WebPages.Html;
using AracIhaleDAL.VM;

namespace Aracİhale.Controllers
{
    public class AdminPanelController : Controller
    {
       
        Model1 db=new Model1();

        [Authorize]
        [HttpGet]
        public ActionResult İlanBilgileri()
        {
            var ararac = TempData["ararac"] as AracOzellikVM;


            return View(ararac);
        }

        [Authorize]
        [HttpPost]
        public ActionResult İlanBilgileri(AracOzellikVM ararac)
        {
            TempData["ararac"]=ararac;
            //IlanEkleDAL ilanEkleDAL=new IlanEkleDAL();
            // ilanEkleDAL.IlanEkle(ilan);ü

            return RedirectToAction("AracDetayBilgisi", "Arac");
        }
        [Authorize]
        public ActionResult PaketTanimlama()
        {
            return View();
        }
      

    
   
        [Authorize]
        public ActionResult Footer()
        {
            return View();
        }
        [Authorize]
        public ActionResult Header()
        {
            return View();
        }
      
        [Authorize]

        public ActionResult KomisyonVeNoterUcretleri()
        {
            return View();
        }
   
    
       


  
    }
        
    }

