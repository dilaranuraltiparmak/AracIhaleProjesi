namespace Aracİhale.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giri")]
    public partial class Giri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giri()
        {
            Araclars = new HashSet<Araclar>();
        }

        [Key]
        public int GirisID { get; set; }

        public int KullaniciID { get; set; }

        public int? RolID { get; set; }

        [Required]
        [StringLength(20)]
        public string KullaniciAdi { get; set; }

        public DateTime GirisZamani { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Araclar> Araclars { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
