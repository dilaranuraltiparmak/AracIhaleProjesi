

using System;

using System.Collections.Generic;

using System.Linq;
using System.Web;


using System.Web.Mvc;
using System.Reflection;

using AracIhaleCore.Entities;
using AracIhaleDAL.VM;

namespace AracIhaleDAL.DAL
{

    public class AracSecDAL

    {
        Model1 model1 = new Model1();
        public List<SelectListItem> StatuSec()
        {

            var status = model1.Status.Select(x => new SelectListItem { Text = x.StatuAdi, Value = x.StatuID.ToString() }).ToList();
            return status;
        }
        public List<SelectListItem> BkSec()
        {
            var bireyselkurumsal = model1.BireyselKurumsals.Select(x => new SelectListItem { Text = x.Durum, Value = x.BireyselKurumsalID.ToString() }).ToList();
            return bireyselkurumsal;

        }
        public List<SelectListItem> MarkaSec()
        {
            var aracmarkasi = model1.AracMarkas.Select(x => new SelectListItem { Text = x.MarkaAdi, Value = x.AracMarkaID.ToString() }).ToList();
            return aracmarkasi;

        }
        public List<SelectListItem> ModelSec()
        {
            var aracmodeli = model1.AracModels.Select(x => new SelectListItem { Text = x.ModelAdi, Value = x.AracModelID.ToString() }).ToList();
            return aracmodeli;
            //var result = (from c in model1.AracModels
            //              select new ModelVM
            //              {
            //                  AracModelID = c.AracModelID,
            //                  ModelAdi = c.ModelAdi
            //              }).ToList();




           
        }
        public List<SelectListItem> YilSec()
        {
            var yil = model1.Yils.Select(x => new SelectListItem { Text = x.Yil1, Value = x.YilID.ToString() }).ToList();
            return yil;

        }
        public List<SelectListItem> GovdeSec()
        {
            var govdetipi = model1.GovdeTipis.Select(x => new SelectListItem { Text = x.GovdeTipiAdi, Value = x.GovdeTipiID.ToString() }).ToList();
            return govdetipi;

        }
        public List<SelectListItem> YakitSec()
        {
            var yakittipi = model1.YakitTipis.Select(x => new SelectListItem { Text = x.YakitTipiAdi, Value = x.YakitTipiID.ToString() }).ToList();
            return yakittipi;

        }
        public List<SelectListItem> VitesSec()
        {
            var vitestipi = model1.VitesTipis.Select(x => new SelectListItem { Text = x.VitesTipiAdi, Value = x.VitesTipiID.ToString() }).ToList();
            return vitestipi;

        }
        public List<SelectListItem> RenkSec()
        {
            var renk = model1.Renks.Select(x => new SelectListItem { Text = x.RenkAdi, Value = x.RenkID.ToString() }).ToList();
            return renk;

        }
        public List<SelectListItem> KmBilgisi()
        {
            var KmBilgisi = model1.Araclars.Select(z => new SelectListItem { Text = z.KMBilgisi, Value = z.AracID.ToString() }).ToList();
            return KmBilgisi;

        }
        public List<SelectListItem> KurumsalSirketAdi()
        {
            var KurumsalSirketAdi = model1.Araclars.Select(z => new SelectListItem { Text = z.KurumsalSirketAdi, Value = z.AracID.ToString() }).ToList();
            return KurumsalSirketAdi;

        }
        public List<SelectListItem> GorselSec()
        {
            var gorsel = model1.AracGorsels.Select(x => new SelectListItem { Text = x.Gorsel, Value = x.AracGorselID.ToString() }).ToList();
            return gorsel;


        }
        public List<SelectListItem> Donanim()
        {
            var donanim = model1.Araclars.Select(x => new SelectListItem { Text = x.Donanim, Value = x.AracID.ToString() }).ToList();
            return donanim;

        }
        public List<SelectListItem> Fiyat()
        {
            var fiyat = model1.Araclars.Select(x => new SelectListItem { Text = x.AracFiyati, Value = x.AracID.ToString() }).ToList();
            return fiyat;

        }
        public List<SelectListItem> Versiyon()
        {
            var versiyon = model1.AracOzelliks.Select(x => new SelectListItem { Text = x.Versiyon, Value = x.AracOzellikID.ToString() }).ToList();
            return versiyon;

        }
        public List<SelectListItem> KullaniciSec()
        {
            var versiyon = model1.Kullanicis.Select(x => new SelectListItem { Text = x.KullaniciAdi ,Value = x.KullaniciID.ToString() }).ToList();
            return versiyon;


        }





    }
}


