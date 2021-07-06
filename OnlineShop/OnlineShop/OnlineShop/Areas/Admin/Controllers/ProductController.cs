﻿using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
  public class ProductController : BaseController
  {
    // GET: Admin/Product
    public ActionResult Index(int page = 1, int page_zise = 10)
    {
      var dao = new ProductDao();
      var list = dao.GetAllProduct(page, page_zise);
      return View(list);
    }
    [HttpGet]
    public ActionResult Create()
    {
      SetviewBag();
      return View();
    }
    public void SetviewBag(long? selectedID = null)
    {
      var dao = new ProductCategoryDao();
      ViewBag.CategoryID = new SelectList(dao.GetAllCategory(), "ID", "Name", selectedID);
    }
    [HttpPost]
    public ActionResult Create(Product data)
    {
      if (ModelState.IsValid)
      {
        var dao = new ProductDao();
        data.CreatedDate = DateTime.Now;
        data.CreatedBy = ((UserLogin)Session[CommonConstant.USER_SESSION]).UserName;
        long id = dao.Insert(data);
        if (id > 0)
        {
          SetAlert("Add product success!", AlertType.SUCCESS);
          return RedirectToAction("Index", "Product");
        }
        else if (id == 0)
        {
          SetAlert("Add product fail!", AlertType.ERROR);
          ModelState.AddModelError("", "Product is exist!");
        }
        else
        {
          SetAlert("Add product fail!", AlertType.ERROR);
          ModelState.AddModelError("", "Add new product failed!");
        }
      }
      SetviewBag(data.CategoryID);
      return View();
    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {
      var dao = new ProductDao();
      bool ret = dao.Delete(id);
      if (ret)
      {
        return RedirectToAction("Index", "Product");
      }
      else
      {
        ModelState.AddModelError("", "Delete product failed!");
      }
      return View();
    }
  }
}