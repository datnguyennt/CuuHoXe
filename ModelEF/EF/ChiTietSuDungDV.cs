namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSuDungDV")]
    public partial class ChiTietSuDungDV
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSDDV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaDV { get; set; }

        public decimal GiaDV { get; set; }

        public virtual SuDungDichVu SuDungDichVu { get; set; }

        public virtual DichVu DichVu { get; set; }
    }
}
