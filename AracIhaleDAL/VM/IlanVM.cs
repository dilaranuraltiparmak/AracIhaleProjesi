using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracIhaleDAL.VM
{
    public class IlanVM
    {
        public int IlanID { get; set; }

        public int AracID { get; set; }
        public string IlanBilgisi { get; set; }
        public string IlanAciklamasi { get; set; }
    }
}