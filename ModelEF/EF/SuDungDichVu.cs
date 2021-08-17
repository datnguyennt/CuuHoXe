namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuDungDichVu")]
    public partial class SuDungDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuDungDichVu()
        {
            ChiTietSuDungDVs = new HashSet<ChiTietSuDungDV>();
        }

        [Key]
        [StringLength(10)]
        public string MaSDDV { get; set; }

        [Required]
        [StringLength(20)]
        public string TenTK { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ThoiGianDat { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ThoiGianHoanThanh { get; set; }

        [Required]
        [StringLength(1)]
        public string TrangThai { get; set; }

        [StringLength(10)]
        public string MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDungDV> ChiTietSuDungDVs { get; set; }

        public virtual CoSoDichVu CoSoDichVu { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
