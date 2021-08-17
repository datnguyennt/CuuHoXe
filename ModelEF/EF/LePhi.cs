namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LePhi")]
    public partial class LePhi
    {
        [Key]
        [StringLength(10)]
        public string MaLP { get; set; }

        [StringLength(10)]
        public string MaNCC { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ThoiGianNop { get; set; }

        [Required]
        [StringLength(1)]
        public string TrangThai { get; set; }

        public virtual CoSoDichVu CoSoDichVu { get; set; }
    }
}
