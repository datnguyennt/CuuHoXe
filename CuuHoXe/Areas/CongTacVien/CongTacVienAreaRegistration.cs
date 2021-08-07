using System.Web.Mvc;

namespace CuuHoXe.Areas.CongTacVien
{
    public class CongTacVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CongTacVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CongTacVien_default",
                "Congtacvien/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}