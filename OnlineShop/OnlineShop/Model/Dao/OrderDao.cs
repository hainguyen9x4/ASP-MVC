using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class OrderDao
  {
    OnlineShopDbContext db = null;
    public OrderDao()
    {
      db = new OnlineShopDbContext();
    }
    public long Insert(Order entity)
    {
        db.Orders.Add(entity);
        db.SaveChanges();
        return entity.ID;
    }
  }
}
