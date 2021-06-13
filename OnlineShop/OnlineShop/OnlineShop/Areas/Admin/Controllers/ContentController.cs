using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace OnlineShop.Areas.Admin.Controllers
{
  public class ContentController : BaseController
  {
    // GET: Admin/Content
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet]
    public ActionResult Create()
    {
      SetviewBag();
      return View();
    }
    [HttpPost]
    public ActionResult Create(Content content)
    {
      if (ModelState.IsValid)
      {
        //Tao thanh cong Content
      }
      SetviewBag(content.CategoryID);
      return View();
    }
    [HttpGet]
    public ActionResult Edit(long id)
    {
      var dao = new ContentDao();
      Content con = dao.GetFromID(id);
      SetviewBag(con.CategoryID);
      return View(con);
    }
    [HttpPost]
    public ActionResult Edit(Content content)
    {
      if (ModelState.IsValid)
      {
        //Tao thanh cong Content
      }
      SetviewBag();
      return View(content.CategoryID);
    }
    public void SetviewBag(long? selectedID = null)
    {
      var dao = new CategoryDao();
      ViewBag.CategoryID = new SelectList(dao.GetAllCatergory(), "ID", "Name", selectedID);
    }
  }
}