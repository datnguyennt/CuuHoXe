namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            CoSoDichVus = new HashSet<CoSoDichVu>();
            SuDungDichVus = new HashSet<SuDungDichVu>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage = "Không được bỏ trống {0}")]
        public string TenTK { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống {0}")]
        [Display(Name ="Mật khẩu")]
        [StringLength(20, ErrorMessage = "Mật khẩu phải dài từ 6 đến 20 ký tự", MinimumLength = 6)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(1)]
        public string PhanQuyen { get; set; }

        [StringLength(50)]
        [Display(Name ="Họ và tên")]
        [Required(ErrorMessage = "Không được bỏ trống {0}")]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="Ngày sinh")]
        [Required(ErrorMessage = "Không được bỏ trống {0}")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống {0}")]
        [StringLength(12)]
        [Display(Name ="Số điện thoại")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Không được bỏ trống {0}")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoSoDichVu> CoSoDichVus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; }
    }
}
