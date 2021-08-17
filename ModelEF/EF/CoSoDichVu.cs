namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoSoDichVu")]
    public partial class CoSoDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CoSoDichVu()
        {
            DichVus = new HashSet<DichVu>();
            GiayPhepCSDVs = new HashSet<GiayPhepCSDV>();
            LePhis = new HashSet<LePhi>();
            SuDungDichVus = new HashSet<SuDungDichVu>();
        }

        [Key]
        [StringLength(10)]
        public string MaNCC { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNCC { get; set; }

        [Required]
        [StringLength(20)]
        public string TenTK { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(1)]
        public string TrangThaiDK { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayDangKi { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DichVu> DichVus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiayPhepCSDV> GiayPhepCSDVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LePhi> LePhis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; }
    }
}
