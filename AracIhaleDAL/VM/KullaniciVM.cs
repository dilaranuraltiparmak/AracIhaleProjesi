using AracIhaleCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhaleDAL.VM
{
    public class KullaniciVM
    {
        public int KullaniciID { get; set; }
        public int BireyselkurumsalID { get; set; }
        public int AktifPasifID { get; set; }
        public int RolID { get; set; }

        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public string BireyselKurumsalDurum { get; set; }

        public List<Kullanici>Kullanicilar { get; set; }
    }
}
