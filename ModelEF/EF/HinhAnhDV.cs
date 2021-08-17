namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnhDV")]
    public partial class HinhAnhDV
    {
        [Key]
        [StringLength(10)]
        public string MaAnh { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [StringLength(10)]
        public string MaDV { get; set; }

        public virtual DichVu DichVu { get; set; }
    }
}
