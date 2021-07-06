using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class ProductCategoryDao
  {
    OnlineShopDbContext db = null;
    public ProductCategoryDao()
    {
      db = new OnlineShopDbContext();
    }
    public List<ProductCategory> GetAllCategoryActive()
    {
      return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
    }
    public IEnumerable<ProductCategory> GetAllCategory(int page, int pagesize)
    {
      return db.ProductCategories.OrderBy(x => x.DisplayOrder).ToPagedList(page, pagesize);
    }
    public long Insert(ProductCategory data)
    {
      if (db.ProductCategories.SingleOrDefault(x => x.Name == data.Name) == null)
      {
        db.ProductCategories.Add(data);
        db.SaveChanges();
        return data.ID;
      }
      else return 0;
    }
    public bool Delete(long id)
    {
      if (db.ProductCategories.SingleOrDefault(x => x.ID == id) != null)
      {
        var data = db.ProductCategories.Find(id);
        db.ProductCategories.Remove(data);
        db.SaveChanges();
        return true;
      }
      else return false;
    }
  }
}
