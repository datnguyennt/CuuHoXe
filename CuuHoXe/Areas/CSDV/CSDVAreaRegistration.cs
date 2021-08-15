using System.Web.Mvc;

namespace CuuHoXe.Areas.CSDV
{
    public class CSDVAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CSDV";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CSDV_default",
                "CSDV/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
               name: "CSDV area",
               url: "cosodichvu",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            context.MapRoute(
               name: "CSDV login",
               url: "dangnhap",
               defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
           );

            context.MapRoute(
              name: "CSDV register",
              url: "dangki",
              defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
          );

        }
    }
}