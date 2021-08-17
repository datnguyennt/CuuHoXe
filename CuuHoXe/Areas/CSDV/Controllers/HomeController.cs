using CuuHoXe.Areas.CSDV.Models;
using CuuHoXe.Extensions;
using ModelEF.EF;
using ModelEF.ModelProvince;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuuHoXe.Areas.CSDV.Controllers
{
	public class HomeController : BaseController
	{
		private CuuHoXeDbContext db = null;
		public HomeController()
		{
			db = new CuuHoXeDbContext();
		}


		// GET: CSDV/Home
		public ActionResult Index()
		{
			var tentk = Session["TenTK"].ToString();
			var csdvu = db.CoSoDichVus.FirstOrDefault(x => x.TenTK == tentk);
			if (csdvu == null)
			{
				Session["TrangThaiDK"] = "";
			}
			else
			{
				Session["TrangThaiDK"] = csdvu.TrangThaiDK;
			}

			return View();
		}

		[HttpGet]
		public ActionResult DangKiDichVu(string TenTK)
		{
			var result = db.TaiKhoans.FirstOrDefault(s => s.TenTK == TenTK);
			//var tentk = db.TaiKhoans.FirstOrDefault(s => s.TenTK == model.TenTK);
			//var sdt = db.TaiKhoans.FirstOrDefault(s => s.SoDienThoai == model.SoDienThoai);
			ViewData["HoTen"] = result.HoTen;
			ViewData["Email"] = result.Email;
			ViewData["SDT"] = result.SoDienThoai;
			ViewData["TenTK"] = result.TenTK;
			return View();
		}

		[HttpPost]
		public ActionResult DangKiDichVu(CSDVViewModel model, HttpPostedFileBase imageSave, string TenTK)
		{

			string filename = Path.GetFileName(imageSave.FileName);
			string _filename = DateTime.Now.ToString("ddMMyyyy") + filename;
			string extension = Path.GetExtension(imageSave.FileName);
			string path = Path.Combine(Server.MapPath("~/Assets/images"), _filename);
			model.HinhAnh = "/Assets/images/" + _filename;

			var idNCC = db.CoSoDichVus.Select(x => x.MaNCC.Trim().Replace("NCC", ""));
			int dem = 0;
			foreach (var item in idNCC)
			{
				if (dem < Int32.Parse(item))
				{
					dem = int.Parse(item);
				}
			}
			int maxNCC = dem;

			TenTK = Request.Form["TenTK"];
			model.MaNCC = string.Concat("NCC", maxNCC + 1);
			//Lưu vào table Cơ sở dịch vụ
			CoSoDichVu csdv = new CoSoDichVu
			{
				MaNCC = model.MaNCC,
				TenNCC = model.TenNCC,
				DiaChi = model.DiaChi,
				NgayDangKi = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm")),
				TrangThaiDK = "0",
				TenTK = TenTK
			};

			var idGP = db.GiayPhepCSDVs.Select(x => x.MaAnh.Trim().Replace("GP", ""));
			int demAnh = 0;
			foreach (var item in idGP)
			{
				if (demAnh < Int32.Parse(item))
				{
					demAnh = int.Parse(item);
				}
			}
			int maxAnh = demAnh;

			//Lưu vào table hình ảnh giấy phép
			GiayPhepCSDV gp = new GiayPhepCSDV
			{
				MaAnh = string.Concat("GP", maxAnh + 1),
				HinhAnh = model.HinhAnh,
				MaNCC = model.MaNCC
			};

			db.CoSoDichVus.Add(csdv);
			db.GiayPhepCSDVs.Add(gp);
			imageSave.SaveAs(path);
			db.SaveChanges();
			Session["Status"] = true; //Ẩn cái đăng kí đi
			this.AddNotification("Đăng kí làm điểm cung cấp dịch vụ thành công. Vui lòng đợi bên chúng tôi duyệt hồ sơ của bạn", NotificationType.SUCCESS);
			return RedirectToAction("Index", "Home");
		}
	}
}