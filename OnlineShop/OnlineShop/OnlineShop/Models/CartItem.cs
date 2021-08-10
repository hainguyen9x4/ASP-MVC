using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
  [Serializable]
  public class CartItem
  {
    public CartItem(Product product, int quantity)
    {
      this.Product = product;
      this.Quantity = quantity;
    }
    public Product Product { get; set; }
    public int Quantity { get; set; }
  }
}