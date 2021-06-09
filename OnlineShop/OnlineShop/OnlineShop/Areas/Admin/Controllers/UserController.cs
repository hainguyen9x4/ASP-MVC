using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using OnlineShop.Common;
using PagedList;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page =1, int page_zise =10)
        {
            var dao = new UserDao();
            var list = dao.GetListUser(page, page_zise);
            return View(list);
        }
        public ActionResult Edit(int id)
        {
          var user = new UserDao().GetUserFromID(id);
          return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
      public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var pass = Encryptor.MD5Hash(user.Password);
                user.Password = pass;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index","User");
                }else if(id == 0)
                {
                ModelState.AddModelError("", "User is exist!");
                 }
                else
                {
                    ModelState.AddModelError("", "Add new user failed!");
                }
            }
            return View();
        }
    [HttpPost]
    public ActionResult Edit(User user)
    {
      if (ModelState.IsValid)
      {
        var dao = new UserDao();
        var user_session = Session.SessionID;
        var currentUser = (UserLogin)Session[CommonConstant.USER_SESSION];
        user.ModifyBy = currentUser.UserName;
        var pass = Encryptor.MD5Hash(user.Password);
        user.Password = pass;
        bool ret = dao.Update(user);
        if (ret)
        {
          return RedirectToAction("Index", "User");
        }
        else
        {
          ModelState.AddModelError("", "Update user failed!");
        }
      }
      return View();
    }
    public ActionResult Delete(int id)
    {
      var dao = new UserDao();
      bool ret = dao.Delete(id);
      if (ret)
      {
        return RedirectToAction("Index", "User");
      }
      else
      {
        ModelState.AddModelError("", "Delete user failed!");
      }
      return View();
    }
  }
}