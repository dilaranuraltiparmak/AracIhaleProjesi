using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracIhaleDAL.VM
{
    public class IhaleFiyatVM
    {
        public int AracID { get; set; }

        public string MinimumalisFiyati { get; set; }
        public string IhaleBaslangicFiyati { get; set; }
    }
}