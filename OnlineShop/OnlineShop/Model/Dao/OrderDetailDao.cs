using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class OrderDetailDao
  {
    OnlineShopDbContext db = null;
    public OrderDetailDao()
    {
      db = new OnlineShopDbContext();
    }
    public bool Insert(OrderDetail entity)
    {
      try
      {
        db.OrderDetails.Add(entity);
        db.SaveChanges();
        return true;
      }
      catch(Exception ex)
      {
        return false;
      }
    }
  }
}
