using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class ProductDao
  {
    OnlineShopDbContext db = null;
    public ProductDao()
    {
      db = new OnlineShopDbContext();
    }
    public IEnumerable<Product> GetAllProduct(int page, int pagesize)
    {
      return db.Products.OrderBy(x=>x.ID).ToPagedList(page, pagesize);
    }
    public long Insert(Product data)
    {
      if (db.Products.SingleOrDefault(x => x.Name == data.Name) == null)
      {
        db.Products.Add(data);
        db.SaveChanges();
        return data.ID;
      }
      else return 0;
    }
    public bool Delete(long id)
    {
      if (db.Products.SingleOrDefault(x => x.ID == id) != null)
      {
        var data = db.Products.Find(id);
        db.Products.Remove(data);
        db.SaveChanges();
        return true;
      }
      else return false;
    }
  }
}
