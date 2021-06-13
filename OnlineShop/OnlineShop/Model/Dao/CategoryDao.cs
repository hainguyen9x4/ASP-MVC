using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class CategoryDao
  {
    OnlineShopDbContext db = null;
    public CategoryDao()
    {
      db = new OnlineShopDbContext();
    }
    public IEnumerable<Category> GetAllCatergory()
    {
      return db.Categories.ToList();
    }
    public Category GetFromID(long id)
    {
      return db.Categories.Where(x=>x.ID==id).SingleOrDefault();
    }
  }
}
