using AracIhaleCore.Entities;
using AracIhaleDAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracIhaleDAL.DAL
{
    public class IlanEkleDAL
    {
        public bool IlanEkle(IlanVM model)
        {
            using (var db = new Model1())
            {
                var ilanlar = new IlanBilgi
                {
     
         IlanBasligi=model.IlanBilgisi,
         IlanAciklamasi=model.IlanAciklamasi,
         AracID=model.AracID,

                };

          


                db.IlanBilgis.Add(ilanlar);


                return db.SaveChanges() > 0;
            }
        }
    }
}