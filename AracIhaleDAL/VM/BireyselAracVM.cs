using AracIhaleCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracIhaleDAL.VM
{
    public class BireyselAracVM
    {
        public string AracMarka { get; set; }

        public string AracModel { get; set; }
        public string Statusu { get; set; }

        public List<Araclar>AraclarListesi { get; set; }
        public SelectList MarkaList { get; set; }
        public SelectList ModelList { get; set; }
        public SelectList StatuList { get; set; }
    }
}