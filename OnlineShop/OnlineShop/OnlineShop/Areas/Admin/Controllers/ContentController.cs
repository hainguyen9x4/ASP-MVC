using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using OnlineShop.Common;

namespace OnlineShop.Areas.Admin.Controllers
{
  public class ContentController : BaseController
  {
    // GET: Admin/Content
    public ActionResult Index(string searchString, int page = 1, int page_size = 3)
    {
      var dao = new ContentDao();
      var list = dao.GetAllContent(searchString, page, page_size);
      ViewBag.searchString = searchString;
      return View(list);
    }
    [HttpGet]
    public ActionResult Create()
    {
      SetviewBag();
      return View();
    }
    [HttpPost]
    [ValidateInput(false)]
    public ActionResult Create(Content content)
    {
      if (ModelState.IsValid)
      {
        var dao = new ContentDao();
        content.CreatedDate = DateTime.Now;
        content.CreatedBy = ((UserLogin)Session[CommonConstant.USER_SESSION]).UserName;
        if(content.Status == null)
        {
          content.Status = false;
        }
        dao.Insert(content);
        return RedirectToAction("Index", "Content");
      }
      SetviewBag(content.CategoryID);
      return View();
    }
    [HttpGet]
    public ActionResult Edit(long id)
    {
      var dao = new ContentDao();
      var con = dao.GetFromID(id);
      SetviewBag(con.CategoryID);
      return View(con);
    }
    [HttpPost]
    [ValidateInput(false)]
    public ActionResult Edit(Content content)
    {
      if (ModelState.IsValid)
      {
        var dao = new ContentDao();
        var user_session = Session.SessionID;
        var currentUser = (UserLogin)Session[CommonConstant.USER_SESSION];
        content.ModifyBy = currentUser.UserName;
        content.ModifyDate = DateTime.Now;
        bool ret = dao.Update(content);
        if (ret)
        {
          return RedirectToAction("Index", "Content");
        }
        else
        {
          ModelState.AddModelError("", "Update user failed!");
        }
      }
      SetviewBag();
      return View(content.CategoryID);
    }
    public void SetviewBag(long? selectedID = null)
    {
      var dao = new CategoryDao();
      ViewBag.CategoryID = new SelectList(dao.GetAllCatergory(), "ID", "Name", selectedID);
    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {
      var dao = new ContentDao();
      bool ret = dao.Delete(id);
      if (ret)
      {
        return RedirectToAction("Index", "Content");
      }
      else
      {
        ModelState.AddModelError("", "Delete Content failed!");
      }
      return View();
    }
  }
}