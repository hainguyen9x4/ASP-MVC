using Model.Dao;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common;

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
            q = (int)(item.Quantity* item.Product.Price);
          }
        }
      }
      return Json(new
      {
        number = q.ToString("N0"),
        result = ret
      });
    }
  }
}