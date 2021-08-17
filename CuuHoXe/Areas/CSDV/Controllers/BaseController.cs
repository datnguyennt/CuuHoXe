using CuuHoXe.Areas.CSDV.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CuuHoXe.Areas.CSDV.Controllers
{
	public class BaseController : Controller
	{
		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var session = Session[Constants.USER_SEESION]; //Lấy session từ trang login
			if (session == null)
			{
				filterContext.Result = new RedirectToRouteResult(new
					RouteValueDictionary(new { controller = "User", action = "Login", Areas = "CSDV" }));
			}
			base.OnActionExecuted(filterContext);
		}
	}
}