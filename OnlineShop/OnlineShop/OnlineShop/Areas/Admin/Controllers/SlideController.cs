using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
  public class SlideController : Controller
  {
    // GET: Admin/Slide
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create([Bind(Include = "DisplayOrder,Description,Status")]Slide slide, HttpPostedFileBase  Image)
    {
      if (ModelState.IsValid)
      {
        var dao = new SlideDao();
        
      }
      return View();
    }
  }
}