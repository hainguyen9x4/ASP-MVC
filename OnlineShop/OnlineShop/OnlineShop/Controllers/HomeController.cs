﻿using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      var dao = new ProductDao();
      ViewBag.NewProduct = dao.GetNewProductHome(4);
      ViewBag.HotProduct = dao.GetHotProduct(4);
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
    [ChildActionOnly]
    public ActionResult MainMenu()
    {
      var model = new MenuDao().GetAllMenuActive(1);
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult TopMenu()
    {
      var model = new MenuDao().GetAllMenuActive(2);
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult ProductCategory()
    {
      var model = new ProductCategoryDao().GetAllCategoryActive();
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult Slider()
    {
      var model = new SlideDao().GetAllSlideEnable(3);
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult Footer()
    {
      var model = new FooterDao().GetAllSlide();
      return PartialView(model);
    }

  }
}