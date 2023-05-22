using AracIhaleCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhaleDAL.VM
{
    public class IhaleTeklif
    {
        public int TeklifID { get; set; }

        public int? KullaniciID { get; set; }

        public int? IhaleID { get; set; }

        [StringLength(50)]
        public string TeklifFiyati { get; set; }

        public DateTime? TeklifTarihi { get; set; }

        public virtual IhaleListesi IhaleListesi { get; set; }

        public virtual Kullanici Kullanici { get; set; }

      
        public virtual ICollection<OnaylananTeklif> OnaylananTeklifs { get; set; }
    }
}
