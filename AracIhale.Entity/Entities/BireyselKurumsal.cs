namespace Aracİhale.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BireyselKurumsal")]
    public partial class BireyselKurumsal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BireyselKurumsal()
        {
            Araclars = new HashSet<Araclar>();
            IhaleListesis = new HashSet<IhaleListesi>();
        }

        public int BireyselKurumsalID { get; set; }

        [StringLength(50)]
        public string Durum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Araclar> Araclars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IhaleListesi> IhaleListesis { get; set; }
    }
}
