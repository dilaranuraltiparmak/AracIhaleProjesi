namespace AracIhaleCore.Entities
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
            IhaleTeklifs = new HashSet<IhaleTeklif>();
            OdemeBilgisis = new HashSet<OdemeBilgisi>();
            OnaylananTeklifs = new HashSet<OnaylananTeklif>();
        }

        [Key]
        public int IhaleID { get; set; }

        [StringLength(50)]
        public string IhaleAdi { get; set; }

        public int? BireyselKurumsalID { get; set; }

        [StringLength(50)]
        public string KurumsalSirketAdi { get; set; }

        public int? IhaleStatuID { get; set; }

        [StringLength(50)]
        public string IhaleBaslangicTarihi { get; set; }

        [StringLength(50)]
        public string IhaleBaslangicSaati { get; set; }

        [StringLength(50)]
        public string IhaleBitisTarihi { get; set; }

        [StringLength(50)]
        public string IhaleBitisSaati { get; set; }

        public int? AracID { get; set; }

        [StringLength(50)]
        public string MinimumAlimFiyati { get; set; }

        [StringLength(50)]
        public string IhaleBaslangicFiyati { get; set; }

        public int? AracOzellikID { get; set; }

        [StringLength(50)]
        public string MarkaAdi { get; set; }

        [StringLength(50)]
        public string ModelAdi { get; set; }

        public virtual Araclar Araclar { get; set; }

        public virtual BireyselKurumsal BireyselKurumsal { get; set; }

        public virtual IhaleStatu IhaleStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IhaleTeklif> IhaleTeklifs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OdemeBilgisi> OdemeBilgisis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OnaylananTeklif> OnaylananTeklifs { get; set; }
    }
}
