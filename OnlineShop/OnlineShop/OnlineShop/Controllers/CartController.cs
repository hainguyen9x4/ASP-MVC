using Model.Dao;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{

  public class CartController : Controller
  {
    private const string cart = "CartSession";
    // GET: Cart
    public ActionResult Index()
    {
      var list = (List<CartItem>)Session[cart];
      return View(list);
    }
    public ActionResult AddToCart(long productID, int quantity)
    {
      var p = new ProductDao().GetProductFromID(productID);
      if(Session[cart] != null)
      {
        var list = (List<CartItem>)Session[cart];
        if(list.Exists(x=>x.Product.ID == productID)){
          foreach(var item in list)
          {
            if(item.Product.ID == productID)
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
        Session[cart] = list;
      }
      else
      {
        var listItem = new List<CartItem>();
        listItem.Add(new CartItem(p, quantity));
        Session[cart] = listItem;
      }
      return RedirectToAction("Index");
    }
  }
}