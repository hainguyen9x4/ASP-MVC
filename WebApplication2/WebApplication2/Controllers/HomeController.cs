using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      //ViewBag.WelcomHahA = "This is the first Text of aplication!";
      var msg = new MessageModel();
      msg.welcome = "This message by model!";
      return View(msg);
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
    public ActionResult MyFunc(string name)
    {
      ViewBag.Message = "Hello "+ name;
      return View();
    }
  }
}