using Model.EF;
using Model.ViewModel;
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
    public IEnumerable<ProductCategory> GetAllCategory2(ref List<Result >countProduct, int page, int pagesize)
    {
      var model = from a in db.ProductCategories
                  join
                  b in db.Products
                  on a.ID equals b.CategoryID
                  group a by a.ID into g
                  select new Result()
                  {
                    ID = g.Key,
                    NumberProduct = g.ToList().Count()
                  };
      countProduct = model.ToList();
      return db.ProductCategories.OrderBy(x => x.DisplayOrder).ToPagedList(page, pagesize);
    }
    public IEnumerable<ProductCategoryViewModel> GetAllCategory3(int page, int pagesize)
    {
      return db.Database.SqlQuery<ProductCategoryViewModel>("ProductCategoryFull").OrderBy(x => x.DisplayOrder).ToPagedList(page, pagesize);
    }
    public class Result
    {
      public long ID;
      public int NumberProduct;
    }
    public IEnumerable<ProductCategory> GetAllCategory()
    {
      return db.ProductCategories.ToList();
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
    public ProductCategory GetFromID(long id)
    {
      return db.ProductCategories.Find(id);
    }
  }
}
