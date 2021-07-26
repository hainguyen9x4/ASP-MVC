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
  public class SlideController : BaseController
  {
    // GET: Admin/Slide
    public ActionResult Index(int page = 1, int page_zise = 10)
    {
      var dao = new SlideDao();
      var slide = dao.GetAllSlide(page, page_zise);
      return View(slide);
    }
    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Slide data)
    {
      if (ModelState.IsValid)
      {
        var dao = new SlideDao();
        data.CreatedDate = DateTime.Now;
        data.CreatedBy = ((UserLogin)Session[CommonConstant.USER_SESSION]).UserName;
        long id = dao.Insert(data);
        if (id > 0)
        {
          SetAlert("Add slide success!", AlertType.SUCCESS);
          return RedirectToAction("Index", "Slide");
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
    public string UploadImage(HttpPostedFileBase file)
    {
      file.SaveAs(Server.MapPath("~/Content/images/slide" + file.FileName));
      return "/Content/images/slide" + file.FileName;
    }
    [HttpGet]
    public ActionResult Edit(int id)
    {
      var data = new SlideDao().GetSlideFromID(id);
      return View(data);
    }
    [HttpPost]
    public ActionResult Edit(Slide data)
    {
      if (ModelState.IsValid)
      {
        var dao = new SlideDao();
        var user_session = Session.SessionID;
        var currentUser = (UserLogin)Session[CommonConstant.USER_SESSION];
        data.ModifyBy = currentUser.UserName;
        bool ret = dao.Update(data);
        if (ret)
        {
          return RedirectToAction("Index", "Slide");
        }
        else
        {
          ModelState.AddModelError("", "Update slide failed!");
        }
      }
      return View();
    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {
      var dao = new SlideDao();
      bool ret = dao.Delete(id);
      if (ret)
      {
        return RedirectToAction("Index", "Slide");
      }
      else
      {
        ModelState.AddModelError("", "Delete slide failed!");
      }
      return View();
    }
    public JsonResult ChangeStatus(long id)
    {
      var dao = new SlideDao();
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