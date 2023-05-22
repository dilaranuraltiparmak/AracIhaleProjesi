using AracIhaleCore.Entities;
using AracIhaleDAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhaleDAL.DAL
{
    public class AracIhaleDAL
    {
        private Model1 db;

        public AracIhaleDAL()
        {
            db = new Model1();
        }

        public SelectList GetSelectList<T>(IEnumerable<T> items, string valueFieldName, string textFieldName)
        {
            return new SelectList(items, valueFieldName, textFieldName);
        }

        public IhaleVM GetIhaleViewModel()
        {
            return new IhaleVM
            {
                IhaleListesis = db.IhaleListesis.ToList(),
                AraclarListesi = db.Araclars.ToList(),
                AracOzellikListesi = db.AracOzelliks.ToList(),
                PlakaList = GetSelectList(db.Araclars.ToList(), "AracID", "AracaPlaka"),
                BireyselKurumsalList = GetSelectList(db.BireyselKurumsals.ToList(), "BireyselKurumsalID", "Durum"),
                IhaleStatuList = GetSelectList(db.IhaleStatus.ToList(), "IhaleStatuID", "IhaleStatuAdi"),
            };
        }

        public void SaveAracIhale(IhaleListesi liste)
        {
            using (var dbContext = new Model1())
            {
                dbContext.IhaleListesis.Add(liste);
                dbContext.SaveChanges();
            }
        }
    }
}
