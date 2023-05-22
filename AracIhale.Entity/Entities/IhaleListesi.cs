namespace Aracİhale.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IhaleListesi")]
    public partial class IhaleListesi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IhaleListesi()
        {
            IhaleAracs = new HashSet<IhaleArac>();
            OdemeBilgisis = new HashSet<OdemeBilgisi>();
        }

        [Key]
        public int IhaleID { get; set; }

        [StringLength(50)]
        public string IhaleAdi { get; set; }

        public int? BireyselKurumsalID { get; set; }

        [StringLength(50)]
        public string KurumsalSirketAdi { get; set; }

        public int? IhaleStatuID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? IhaleBaslangicTarihi { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? IhaleBaslangicSaati { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? IhaleBitisTarihi { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? IhaleBitisSaati { get; set; }

        public virtual BireyselKurumsal BireyselKurumsal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IhaleArac> IhaleAracs { get; set; }

        public virtual IhaleStatu IhaleStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OdemeBilgisi> OdemeBilgisis { get; set; }
    }
}
