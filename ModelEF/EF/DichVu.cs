namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            ChiTietSuDungDVs = new HashSet<ChiTietSuDungDV>();
            HinhAnhDVs = new HashSet<HinhAnhDV>();
        }

        [Key]
        [StringLength(10)]
        public string MaDV { get; set; }

        [Required]
        [StringLength(255)]
        public string TenDichVu { get; set; }

        public decimal GiaDV { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        [StringLength(1)]
        public string TrangThai { get; set; }

        [StringLength(10)]
        public string MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDungDV> ChiTietSuDungDVs { get; set; }

        public virtual CoSoDichVu CoSoDichVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnhDV> HinhAnhDVs { get; set; }
    }
}
