using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
  public class ProductCategoryController : BaseController
  {
    // GET: Admin/ProductCategory
    public ActionResult Index(int pagedList = 1, int pagesize = 10)
    {
      var dao = new ProductCategoryDao();
      var list = dao.GetAllCategory(pagedList, pagesize);
      return View(list);
    }
    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(ProductCategory data)
    {
      if (ModelState.IsValid)
      {
        var dao = new ProductCategoryDao();
        data.CreatedBy = ((UserLogin)Session[CommonConstant.USER_SESSION]).UserName;
        data.CreatedDate = DateTime.Now;
        long id = dao.Insert(data);
        if (id > 0)
        {
          SetAlert("Add user success!", AlertType.SUCCESS);
          return RedirectToAction("Index", "ProductCategory");
        }
        else if (id == 0)
        {
          SetAlert("Add user fail!", AlertType.ERROR);
          ModelState.AddModelError("", "ProductCategory is exist!");
        }
        else
        {
          SetAlert("Add user fail!", AlertType.ERROR);
          ModelState.AddModelError("", "Add new user failed!");
        }
      }
      return View();
    }
    public ActionResult Delete(long id)
    {
      var dao = new ProductCategoryDao();
      bool ret = dao.Delete(id);
      if (ret)
      {
        return RedirectToAction("Index", "ProductCategory");
      }
      else
      {
        ModelState.AddModelError("", "Delete ProductCategory failed!");
      }
      return View();
    }
  }
}