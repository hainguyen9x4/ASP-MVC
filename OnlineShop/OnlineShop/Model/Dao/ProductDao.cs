using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
      return db.Products.OrderBy(x => x.ID).ToPagedList(page, pagesize);
    }
    public IEnumerable<ProductViewModel> GetAllProduct2(int page, int pagesize)
    {
      var model = from a in db.Products
                  join b in db.ProductCategories
                  on a.CategoryID equals b.ID
                  
                  select new ProductViewModel()
                  {
                    ID = a.ID,
                    Name = a.Name,
                    Code = a.Code,
                    Description = a.Description,
                    Avatar = a.Avatar,
                    MoreImage = a.MoreImage,
                    Price = a.Price,
                    PromationPrice = a.PromationPrice,
                    IncludeVAT = a.IncludeVAT,
                    Quanlity = a.Quanlity,
                    CategoryName = b.Name,
                    Detail = a.Detail,
                    Warranty = a.Warranty,
                    MetaDescription = a.MetaDescription,
                    CreatedDate = a.CreatedDate,
                    CreatedBy = a.CreatedBy,
                    ModifyDate = a.ModifyDate,
                    ModifyBy = a.ModifyBy,
                    MetaKeyword = a.MetaKeyword,
                    TopHot = a.TopHot,
                    ViewCount = a.ViewCount,
                  };
      return model.OrderByDescending(x=>x.CreatedDate).ToPagedList(page, pagesize);
    }
    public IEnumerable<ProductViewModel> GetAllProduct3(int page, int pagesize)
    {
      var clientIdParameter = new SqlParameter("@CategoryID", 4);
      var model = db.Database.SqlQuery<ProductViewModel>("GetAllProductByCategory @CategoryID", new SqlParameter("CategoryID", 4));
      return model.OrderByDescending(x => x.CreatedDate).ToList().ToPagedList(page,pagesize);
    }
    public IEnumerable<Product> GetAllProduct()
    {
      return db.Products.OrderBy(x => x.ID).ToList();
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
    public Product GetProductFromID(long id)
    {
      return db.Products.Find(id);
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
    public bool Update(Product entity)
    {
      try
      {
        var user = db.Products.Find(entity.ID);
        if (!String.IsNullOrEmpty(entity.Name))
        {
          user.Name = entity.Name;
        }
        if (!String.IsNullOrEmpty(entity.Code))
        {
          user.Code = entity.Code;
        }
        user.Description = entity.Description;
        user.Avatar = entity.Avatar;
        if (entity.Price != null)
        {
          user.Price = entity.Price;
        }
        if (entity.PromationPrice != null)
        {
          user.PromationPrice = entity.PromationPrice;
        }
        if (entity.Quanlity >= 0)
        {
          user.Quanlity = entity.Quanlity;
        }
        if (entity.TopHot != null)
        {
          user.TopHot = entity.TopHot;
        }
        if (!String.IsNullOrEmpty(entity.MetaKeyword))
        {
          user.MetaKeyword = entity.MetaKeyword;
        }
        if (!String.IsNullOrEmpty(entity.MetaDescription))
        {
          user.MetaDescription = entity.MetaDescription;
        }
        user.CategoryID = entity.CategoryID;
        user.ModifyBy = entity.ModifyBy;
        user.ModifyDate = DateTime.Now;
        db.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        //Write log
        return false;
      }
    }
    public List<Product> GetNewProductHome(int top, ref int totalPage, int page = 1, int pageSize = 4)
    {
      var model =  db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
      totalPage = model.Count() / pageSize + (model.Count() % pageSize > 0 ? 1 : 0);
      return model.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }
    public List<Product> GetHotProduct(int top)
    {
      return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).Take(top).ToList();
    }
    public List<Product> GetAllCategoryProduct(long id)
    {
      return db.Products.Where(x => x.CategoryID == id).ToList();
    }
    public List<Product> GetAllRelatedProduct(Product p)
    {
      return db.Products.Where(x => x.CategoryID == p.CategoryID && x.ID != p.ID).Take(4).ToList();
    }
  }
}
