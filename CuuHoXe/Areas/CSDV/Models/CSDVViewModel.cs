using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CuuHoXe.Areas.CSDV.Models
{
	public class CSDVViewModel
	{
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

        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        [Key]
        [StringLength(10)]
        public string MaAnh { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

    }
}