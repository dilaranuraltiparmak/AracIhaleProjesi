namespace AracIhaleCore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Araclar")]
    public partial class Araclar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Araclar()
        {
            AracAliciBilgis = new HashSet<AracAliciBilgi>();
            AracParcaBilgis = new HashSet<AracParcaBilgi>();
            AracTarihces = new HashSet<AracTarihce>();
            IhaleListesis = new HashSet<IhaleListesi>();
            IlanBilgis = new HashSet<IlanBilgi>();
            TramerTutaris = new HashSet<TramerTutari>();
        }

        [Key]
        public int AracID { get; set; }

        public int? BireyselKurumsalID { get; set; }

        [StringLength(50)]
        public string KurumsalSirketAdi { get; set; }

        public int? StatuID { get; set; }

        [StringLength(50)]
        public string AracFiyati { get; set; }

        [StringLength(50)]
        public string KMBilgisi { get; set; }

        [StringLength(50)]
        public string Donanim { get; set; }

        public int? AracGorselID { get; set; }

        public int? AracOzellikID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Tarih { get; set; }

        public int? KullaniciID { get; set; }

        [StringLength(50)]
        public string AracaPlaka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AracAliciBilgi> AracAliciBilgis { get; set; }

        public virtual AracGorsel AracGorsel { get; set; }

        public virtual AracOzellik AracOzellik { get; set; }

        public virtual BireyselKurumsal BireyselKurumsal { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Statu Statu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AracParcaBilgi> AracParcaBilgis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AracTarihce> AracTarihces { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IhaleListesi> IhaleListesis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IlanBilgi> IlanBilgis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TramerTutari> TramerTutaris { get; set; }
    }
}
