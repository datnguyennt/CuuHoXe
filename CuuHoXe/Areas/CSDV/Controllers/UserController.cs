using CuuHoXe.Areas.CSDV.Common;
using CuuHoXe.Areas.CSDV.Models;
using CuuHoXe.Extensions;
using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CuuHoXe.Areas.CSDV.Controllers
{
	public class UserController : Controller
	{
		private CuuHoXeDbContext db = null;
		public UserController()
		{
			db = new CuuHoXeDbContext();
		}

		public ActionResult Register()
		{
			return View();
		}

		//POST: Register
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(LoginModels model)
		{
			try
			{
				var email = db.TaiKhoans.FirstOrDefault(s => s.Email == model.Email);
				var tentk = db.TaiKhoans.FirstOrDefault(s => s.TenTK == model.TenTK);
				var sdt = db.TaiKhoans.FirstOrDefault(s => s.SoDienThoai == model.SoDienThoai);
				if (email == null && tentk == null && sdt == null)
				{
					TaiKhoan tk = new TaiKhoan
					{
						TenTK = model.TenTK,
						HoTen = model.HoTen,
						MatKhau = model.MatKhau,
						Email = model.Email,
						SoDienThoai = model.SoDienThoai,
						PhanQuyen = Common.CSDV_GROUP,
						NgaySinh = model.NgaySinh
					};
					db.TaiKhoans.Add(tk);
					db.SaveChanges();
					this.AddNotification("Đăng kí tài khoản thành công. Vui lòng đăng nhập", NotificationType.SUCCESS);
					return RedirectToAction("Login");
				}
				else if (tentk != null)
				{
					this.AddNotification("Tên đăng nhập đã tồn tại", NotificationType.ERROR);
					return View();
				}
				else if (email != null)
				{
					this.AddNotification("Email đã tồn tại", NotificationType.ERROR);
					return View();
				}
				else if (sdt != null)
				{
					this.AddNotification("Số điện thoại đã được đăng kí", NotificationType.ERROR);
					return View();
				}
			}
			catch (Exception)
			{
				return View();
				throw;
			}
			
			return View();
		}

		//Đăng nhập
		public int LoginCSDV(string TenTK, string MatKhau)
		{
			var result = db.TaiKhoans.SingleOrDefault(x => x.TenTK == TenTK);
			if (result == null) //Nếu không tồn tại username thì return 0
			{
				return 0;
			}
			else
			{
				if (result.PhanQuyen == Common.CSDV_GROUP) //Nếu là tài khoản CSDV
				{
					if (result.MatKhau == MatKhau)
					{
						return 1; //Trả về 1 nếu tên đăng nhập và mật khẩu đều đúng
					}
					else
					{
						return -2; //Trả về -2 nếu đúng tên đăng nhập nhưng sai mật khẩu
					}
				}
			}
			return -3; // Không phải là tài khoản CSDV
		}
		public TaiKhoan getUserByEmail(string email)
		{
			return db.TaiKhoans.SingleOrDefault(x => x.Email.Contains(email));
		}

		public TaiKhoan getUserByTK(string tenTK)
		{
			return db.TaiKhoans.SingleOrDefault(x => x.TenTK.Contains(tenTK));
		}

		public CoSoDichVu checkTenTK(string tenTK)
		{
			return db.CoSoDichVus.SingleOrDefault(x => x.TenTK.Contains(tenTK));
		}

		public ActionResult Login()
		{
			var session = Session[Constants.USER_SEESION]; //Tạo biến session kiểm tra xem có tồn tại hay không
			if (session != null)
			{
				return RedirectToAction("Index", "home");
				//Trả về trang chủ index nếu đã tồn tại session (đã đăng nhập thành công rồi nhưng lại trỏ url về lại trang login ấy)
			}
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginModels model)
		{
			try
			{
				var result = LoginCSDV(model.TenTK, model.MatKhau); //Tạo biến result để kiểm tra đăng nhập
				if (result == 1) //Nếu tên đăng nhập và mật khẩu đúng
				{
					//tạo biến user để lấy thông tin cần thiết, sau đó truyền vào session
					var user = getUserByTK(model.TenTK);

					var userSession = new UserLogin
					{
						TenTK = user.TenTK,
						HoTen = user.HoTen
					};
					var checkTK = checkTenTK(model.TenTK);
					if (checkTK == null) //Tài khoản chưa đăng kí làm điểm cung cấp dịch vụ
					{
						Session["Status"] = false;
					}
					else //Tài khoản đã đăng kí làm điểm cung cấp dịch vụ
					{
						Session["Status"] = true;
					}
					string hoTen = user.HoTen;
					Session.Add(Constants.USER_SEESION, userSession); //Session này để kiểm tra khi vào trang chủ index home
					Session["FullName"] = hoTen.ToString(); //Session này dùng cho lời chào ở trang index home
					Session["TenTK"] = user.TenTK.ToString(); //Session này dùng cho đăng kí làm điểm cung cấp dịch vụ
					return RedirectToAction("Index", "Home"); //Sau đó quay về trang index home
				}
				else if (result == 0) //Nếu tài khoản không tồn tại
				{
					this.AddNotification("Tài khoản không tồn tại", NotificationType.ERROR);
				}
				else if (result == -2)
				{
					this.AddNotification("Sai mật khẩu", NotificationType.ERROR);
				}
				else
				{
					this.AddNotification("Sai tên đăng nhập", NotificationType.ERROR);
				}
			}
			catch (Exception)
			{
				return View();
				throw;
			}
			return View("Login"); //Nếu modelstate == false thì ở yên tại chỗ
		}


		//Logout
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Login", "User");
		}
	}
}