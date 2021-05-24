using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.Admin.Controllers
{
  public class CategoryController : Controller
  {
    // GET: Admin/Category
    public ActionResult Index()
    {
      var iplCategory = new CategoryModel();
      var model = iplCategory.GetAllCategory();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Category categor)
    {
      try {
        if (ModelState.IsValid)
        {
          //Insert by sql
          var categoryModel = new CategoryModel();
          int res = categoryModel.AddACategory(categor.Name, categor.Order, categor.Status);
          if(res > 0)
          {
            return RedirectToAction("Index");
          }
          else
          {
            ModelState.AddModelError("","Add failed!");
          }
          
        }
        return View(categor);
      } catch(Exception ex)
      {
        return View();
      }
    }
  }
}