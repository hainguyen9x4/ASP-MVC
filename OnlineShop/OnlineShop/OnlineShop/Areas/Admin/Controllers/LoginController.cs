using Model.Dao;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
  public class LoginController : Controller
  {
    // GET: Admin/Login
    public ActionResult Index()
    {

      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(LoginModel model)
    {
      var dao = new UserDao();
      var res = dao.Login(model.Username, model.Password);
      if (res && ModelState.IsValid)
      {
        var user = dao.GetID(model.Username);
        var userSession = new UserLogin();
        userSession.UserName = user.Username;
        userSession.Id = user.ID;
        Session.Add(CommonConstant.USER_SESSION, userSession);
        return RedirectToAction("Index", "Home");
      }
      else
      {
        ModelState.AddModelError("", "Login failed!");
      }
      return View();
    }
    public ActionResult Logout()
    {
      Session.Clear();
      return RedirectToAction("Index", "Login");
    }
  }
}