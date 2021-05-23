using Models;
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
  }
}