using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System.Web.Mvc;
namespace OnlineShop.Areas.Admin.Controllers
{
  public class UserController : BaseController
  {
    // GET: Admin/User
    public ActionResult Index(string searchString, int page = 1, int page_zise = 10)
    {
      var dao = new UserDao();
      var list = dao.GetListUser(searchString, page, page_zise);
      ViewBag.searchString = searchString;
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
          SetAlert("Add user success!", AlertType.SUCCESS);
          return RedirectToAction("Index", "User");
        }
        else if (id == 0)
        {
          SetAlert("Add user fail!", AlertType.ERROR);
          ModelState.AddModelError("", "User is exist!");
        }
        else
        {
          SetAlert("Add user fail!", AlertType.ERROR);
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
    [HttpDelete]
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
    [HttpPost]
    public JsonResult ChangeStatus(long id)
    {
      var dao = new UserDao();
      var currentUser = (UserLogin)Session[CommonConstant.USER_SESSION];
      var sta = false;
      var ret = false;
      if (currentUser.Id != id)
      {
        sta = dao.ChangeStatus(id);
        ret = true;
      }
      return Json(new
      {
        status = sta,
        result = ret
      });
    }
  }
}