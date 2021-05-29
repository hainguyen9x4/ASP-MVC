using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var session = (UserLogin)Session[CommonConstant.USER_SESSION];
      if(session == null)
      {
        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary( new { controller = "Login", action = "Index", Area = "Admin" }));
      }
      base.OnActionExecuting(filterContext);
    }
    }
}