using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
  public class LogoController : BaseController
  {
    // GET: Admin/Logo
    public ActionResult Index()
    {
      var logos = new LogoDao().GetAllLogo(); ;
      return View(logos);
    }
    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Logo data)
    {
      if (ModelState.IsValid)
      {
        var dao = new LogoDao();
        data.CreatedDate = DateTime.Now;
        data.CreatedBy = ((UserLogin)Session[CommonConstant.USER_SESSION]).UserName;
        long id = dao.Insert(data);
        if (id > 0)
        {
          SetAlert("Add slide success!", AlertType.SUCCESS);
          return RedirectToAction("Index", "Logo");
        }
        else if (id == 0)
        {
          SetAlert("Add slide fail!", AlertType.ERROR);
          ModelState.AddModelError("", "Slide is exist!");
        }
        else
        {
          SetAlert("Add slide fail!", AlertType.ERROR);
          ModelState.AddModelError("", "Add new slide failed!");
        }
      }
      return View();
    }
    public JsonResult ChangeStatus(long id)
    {
      var dao = new LogoDao();
      var ret = false;
      var sta = false;
      try
      {
        sta = dao.ChangeStatus(id);
        ret = true;
      }
      catch
      {
        ret = false;
      }
      return Json(new
      {
        status = sta,
        result = ret
      });
    }
  }
}