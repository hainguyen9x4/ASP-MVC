using OnlineShop.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Areas.Admin.Controllers
{
  public class BaseController : Controller
  {
    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var session = (UserLogin)Session[CommonConstant.USER_SESSION];
      if (session == null)
      {
        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
      }
      base.OnActionExecuting(filterContext);
    }
    protected void SetAlert(string mess, AlertType type)
    {
      TempData["AlertMessage"] = mess;
      if (type == AlertType.SUCCESS)
      {
        TempData["AlertType"] = "alert-success";
      }
      else if (type == AlertType.WARNING)
      {
        TempData["AlertType"] = "alert-warning";
      }
      else if (type == AlertType.ERROR)
      {
        TempData["AlertType"] = "alert-error";
      }
    }
    public enum AlertType
    {
      SUCCESS,
      WARNING,
      ERROR
    }
  }
}