using AracIhaleCore.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracIhaleDAL.VM;

namespace AracIhaleDAL.DAL
{
    public class BireyselAracDAL
    {
        Model1 db =new Model1();
        public List<Araclar> GetFiltreliAraclar(BireyselAracVM model)
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

            if (!string.IsNullOrEmpty(model.Statusu))
            {
                int statuId = Convert.ToInt32(model.Statusu);
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