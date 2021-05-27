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
      if (ModelState.IsValid)
      {
        var dao = new UserDao();
        var res = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
        if (res == CommonConstant.kSuccess)
        {
          var user = dao.GetID(model.Username);
          var userSession = new UserLogin();
          userSession.UserName = user.Username;
          userSession.Id = user.ID;
          Session.Add(CommonConstant.USER_SESSION, userSession);
          return RedirectToAction("Index", "Home");
        }else if(res == CommonConstant.kUserLocked)
        {
          ModelState.AddModelError("", "Username is locked!");
        }else if(res == CommonConstant.kNoExist)
        {
          ModelState.AddModelError("", "No exist user!");
        }
        else if(res == CommonConstant.kWrongPassword)
        {
          ModelState.AddModelError("", "Wrong password!");
        }
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