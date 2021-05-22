using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Areas.Admin.Code;
using WebApplication2.Areas.Admin.Data;

namespace WebApplication2.Areas.Admin.Controllers
{
  public class LoginController : Controller
  {
    // GET: Admin/Login
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(LoginModel model)
    {
      //var ret = new AccountModel().Login(model.Username, model.Password);
      if (/*ret*/Membership.ValidateUser(model.Username,model.Password) && ModelState.IsValid)
      {
        //SessionHelper.SetSession(new UserSession() { Username = model.Username });
        FormsAuthentication.SetAuthCookie(model.Username,model.Remember);
        return RedirectToAction("Index", "Admin");
      }
      else
      {
        ModelState.AddModelError("", "Login failed!");
      }
      return View(model);
    }
    public ActionResult Logout()
    {
      FormsAuthentication.SignOut();
      return RedirectToAction("Index", "Login");
    }
  }
}