namespace AracIhaleCore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Araclars = new HashSet<Araclar>();
            Giris = new HashSet<Giri>();
            IhaleTeklifs = new HashSet<IhaleTeklif>();
            OdemeBilgisis = new HashSet<OdemeBilgisi>();
            OnaylananTeklifs = new HashSet<OnaylananTeklif>();
        }

        public int KullaniciID { get; set; }

        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        public int? AktifPasifID { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }

        public int? RolID { get; set; }

        public int? BireyselKurumsalID { get; set; }

        [StringLength(50)]
        public string KurumsalIl { get; set; }

        [StringLength(50)]
        public string KurumsalIlce { get; set; }

        [StringLength(50)]
        public string KurumsalAdres { get; set; }

        [StringLength(50)]
        public string FirmaAdi { get; set; }

        public int? FirmaBilgisiID { get; set; }

        public virtual AktifPasif AktifPasif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Araclar> Araclars { get; set; }

        public virtual BireyselKurumsal BireyselKurumsal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giri> Giris { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IhaleTeklif> IhaleTeklifs { get; set; }

        public virtual Rol Rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OdemeBilgisi> OdemeBilgisis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OnaylananTeklif> OnaylananTeklifs { get; set; }
    }
}
