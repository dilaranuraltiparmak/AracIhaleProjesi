namespace AracIhaleCore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giri")]
    public partial class Giri
    {
        [Key]
        public int GirisID { get; set; }

        public int KullaniciID { get; set; }

        public int? RolID { get; set; }

        [Required]
        [StringLength(20)]
        public string KullaniciAdi { get; set; }

        public DateTime GirisZamani { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
