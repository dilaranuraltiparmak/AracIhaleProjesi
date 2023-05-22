using AracIhaleCore.Entities;

using AracIhaleDAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracIhaleDAL.DAL
{
    public class AracEkleDAL
    {

        public bool AracEkle(AracOzellikVM ozellikVM)
        {
            using (var db = new Model1())
            {
                var yeniozellik = new AracOzellik
                {
                    AracOzellikID = ozellikVM.AracOzellikID,
                    AracMarkaID = ozellikVM.AracMarkaID,
                    AracModelID = ozellikVM.AracModelID,
                    VitesTipiID = ozellikVM.VitesTipiID,
                    YakitTipiID = ozellikVM.YakitTipiID,
                    GovdeTipiID = ozellikVM.GovdeTipiID,
                    RenkID = ozellikVM.RenkID,
                    YilID = ozellikVM.YilID,
                    Versiyon = ozellikVM.Versiyon,



                };
                db.AracOzelliks.Add(yeniozellik);
                db.SaveChanges();

                var yenioz = new Araclar
                {
                    AracaPlaka=ozellikVM.AracaPlaka,
                    BireyselKurumsalID = ozellikVM.BireyselKurumsalID,
                    StatuID = ozellikVM.StatuID,
                    KurumsalSirketAdi = ozellikVM.KurumsalSirketAdi,
                    AracOzellikID = yeniozellik.AracOzellikID,
                    KMBilgisi = ozellikVM.KMBilgisi,
                    AracFiyati = ozellikVM.AracFiyati,
                    AracGorselID = ozellikVM.AracGorselID,
                    Donanim = ozellikVM.Donanim,
                    Tarih=DateTime.Now

                };

                db.Araclars.Add(yenioz);
                db.SaveChanges();


                var ek = new IlanBilgi
                {
                    AracID=yenioz.AracID,
              IlanBasligi=ozellikVM.IlanBilgisi,
              IlanAciklamasi=ozellikVM.IlanAciklama
                  
                };
             
           
                db.IlanBilgis.Add(ek);
             

                //buraya yeni bir tramer icin de ekleme yapılacak

                return db.SaveChanges() > 0;
            }
        }
    }
}