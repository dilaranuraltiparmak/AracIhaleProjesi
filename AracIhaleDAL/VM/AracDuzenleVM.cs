using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracIhaleDAL.VM
{
    public class AracDuzenleVM
    {
        public int AracID { get; set; }
        public int AracMarkaID { get; set; }
        public int AracModelID { get; set; }
        public int BireyselKurumsalID { get; set; }
        public int StatuID { get; set; }


        public List<SelectListItem> AracMarkaList { get; set; }
        public List<SelectListItem> AracModelList { get; set; }
        //public SelectList AracModelList { get; set; }
        public List<SelectListItem> BireyselKurumsalList { get; set; }
        public List<SelectListItem> StatuList { get; set; }
    
    }
}