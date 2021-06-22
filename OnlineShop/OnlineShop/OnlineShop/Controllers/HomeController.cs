using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
    [ChildActionOnly]
    public ActionResult MainMenu()
    {
      var model = new MenuDao().GetAllMenuActive(1);
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult TopMenu()
    {
      var model = new MenuDao().GetAllMenuActive(2);
      return PartialView(model);
    }
  }
}