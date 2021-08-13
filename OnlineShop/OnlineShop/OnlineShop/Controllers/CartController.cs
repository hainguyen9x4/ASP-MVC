using Model.Dao;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common;
using Model.EF;

namespace OnlineShop.Controllers
{

  public class CartController : Controller
  {
    // GET: Cart
    public ActionResult Index()
    {
      var list = (List<CartItem>)Session[CommonConstant.CART];
      return View(list);
    }
    public ActionResult AddToCart(long productID, int quantity)
    {
      var p = new ProductDao().GetProductFromID(productID);
      if (Session[CommonConstant.CART] != null)
      {
        var list = (List<CartItem>)Session[CommonConstant.CART];
        if (list.Exists(x => x.Product.ID == productID))
        {
          foreach (var item in list)
          {
            if (item.Product.ID == productID)
            {
              item.Quantity += quantity;
              break;
            }
          }
        }
        else
        {
          list.Add(new CartItem(p, quantity));
        }
        Session[CommonConstant.CART] = list;
      }
      else
      {
        var listItem = new List<CartItem>();
        listItem.Add(new CartItem(p, quantity));
        Session[CommonConstant.CART] = listItem;
      }
      return RedirectToAction("Index");
    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {
      if (Session[CommonConstant.CART] != null)
      {
        var list = (List<CartItem>)Session[CommonConstant.CART];
        if (list.Exists(x => x.Product.ID == id))
        {
          foreach (var item in list)
          {
            if (item.Product.ID == id)
            {
              list.Remove(item);
              break;
            }
          }
          Session[CommonConstant.CART] = list;
          return RedirectToAction("Index");
        }
      }
      return View();
    }
    public JsonResult ChangeQuantity(int id)
    {
      bool ret = false;
      var total = 0;
      var list = (List<CartItem>)Session[CommonConstant.CART];
      var q = 0;
      if (list.Exists(x => x.Product.ID == id))
      {
        var p = new ProductDao().GetProductFromID(id);
        foreach (var item in list)
        {
          if (item.Product.ID == id && item.Quantity + 1 <= p.Quanlity)
          {
            ret = true;
            item.Quantity++;
            q = (int)(item.Quantity * item.Product.Price);
          }
        }
        foreach (var item in list)
        {
          total += (int)(item.Quantity * item.Product.Price);
        }
      }

      return Json(new
      {
        number = q.ToString("N0"),
        result = ret,
        totalAmount = total.ToString("N0")
      });
    }
    public JsonResult ChangeSubQuantity(int id)
    {
      bool ret = false;
      var list = (List<CartItem>)Session[CommonConstant.CART];
      var q = 0;
      var total = 0;
      if (list.Exists(x => x.Product.ID == id))
      {
        var p = new ProductDao().GetProductFromID(id);
        int i = -1;
        int j = -1;
        foreach (var item in list)
        {
          i++;
          if (item.Product.ID == id)
          {
            if (item.Quantity - 1 > 0)
            {
              ret = true;
              item.Quantity--;
              q = (int)(item.Quantity * item.Product.Price);
            }
            else
            {
              q = 0;
              j = i;
            }
          }
        }
        if (j > -1)
        {
          ret = true;
          list.RemoveAt(j);
        }
        foreach (var item in list)
        {
          total += (int)(item.Quantity * item.Product.Price);
        }
      }
      return Json(new
      {
        number = q.ToString("N0"),
        result = ret,
        totalAmount = total.ToString("N0")
      });
    }
    [HttpGet]
    public ActionResult Payment()
    {
      ViewBag.CartData = (List<CartItem>)Session[CommonConstant.CART];
      return View();
    }
    [HttpPost]
    public ActionResult Payment(Order data)
    {
      data.CreatedDate = DateTime.Now;
      data.CustomerID = 0;
      var dao = new OrderDao();
      var id = dao.Insert(data);
      var daoDetail = new OrderDetailDao();
      var list = (List<CartItem>)Session[CommonConstant.CART];
      try
      {
        foreach (var item in list)
        {
          var detail = new OrderDetail();
          detail.OrderID = id;
          detail.ProductID = item.Product.ID;
          detail.Price = item.Product.Price;
          detail.Quantity = item.Quantity;
          daoDetail.Insert(detail);
        }
      }
      catch
      {
        //ghi log
        return Redirect("ErrorPage");//sho thongtin loi
      }
      return Redirect("/success-payment");
    }
    public ActionResult SuccessPayment()
    {
      return View();
    }
  }
}