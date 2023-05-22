using AracIhaleCore.Entities;
using AracIhaleDAL.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AracIhaleDAL.DAL
{
    public class AracListelemeDAL
    {
        Model1 db = new Model1();

        public List<Araclar> GetFiltreliAraclar(AracListeleVM model)
        {
            var araclar = db.Araclars.AsQueryable();

            if (!string.IsNullOrEmpty(model.AracMarka))
            {
                int aracMarkaId = Convert.ToInt32(model.AracMarka);
                araclar = araclar.Where(a => a.AracOzellik.AracMarkaID == aracMarkaId);
            }

            if (!string.IsNullOrEmpty(model.AracModel))
            {
                int aracModelId = Convert.ToInt32(model.AracModel);
                araclar = araclar.Where(a => a.AracOzellik.AracModelID == aracModelId);
            }

            if (!string.IsNullOrEmpty(model.BireyselKurumsal))
            {
                int bireyselKurumsalId = Convert.ToInt32(model.BireyselKurumsal);
                araclar = araclar.Where(a => a.BireyselKurumsalID == bireyselKurumsalId);
            }

            if (!string.IsNullOrEmpty(model.Statu))
            {
                int statuId = Convert.ToInt32(model.Statu);
                araclar = araclar.Where(a => a.StatuID == statuId);
            }

            return araclar.ToList();
        }
        public SelectList GetSelectList<T>(IEnumerable<T> items, string valueFieldName, string textFieldName)
        {
            return new SelectList(items, valueFieldName, textFieldName);
        }
    }




}


