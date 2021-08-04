using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
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
      SetviewBag();
      return View(list);
    }
    public ActionResult Edit(long id)
    {
      var user = new ProductDao().GetProductFromID(id);
      SetviewBag(user.CategoryID);
      return View(user);
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
    public string UploadImage(HttpPostedFileBase file)
    {
      file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
      return "/Content/images/" + file.FileName;
    }
    [HttpPost]
    public ActionResult Edit(Product data)
    {
      if (ModelState.IsValid)
      {
        var dao = new ProductDao();
        var user_session = Session.SessionID;
        var currentUser = (UserLogin)Session[CommonConstant.USER_SESSION];
        data.ModifyBy = currentUser.UserName;
        bool ret = dao.Update(data);
        if (ret)
        {
          return RedirectToAction("Index", "Product");
        }
        else
        {
          ModelState.AddModelError("", "Update Product failed!");
        }
      }
      return View();
    }
    public string AddNewPro(Model.EF.Product pro)
    {
      string message = "Add product fail!";
      var dao = new ProductDao();
      pro.CreatedDate = DateTime.Now;
      pro.CreatedBy = ((UserLogin)Session[CommonConstant.USER_SESSION]).UserName;
      long id = dao.Insert(pro);
      if (id > 0)
      {
        message = "Add product success!";
      }
      return message;
    }
  }
}