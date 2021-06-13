using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class ContentDao
  {
    OnlineShopDbContext db = null;
    public ContentDao()
    {
      db = new OnlineShopDbContext();
    }
    public IEnumerable<Content> GetAllCatergory()
    {
      return db.Contents.ToList();
    }
    public Content GetFromID(long id)
    {
      return db.Contents.Where(x => x.ID == id).SingleOrDefault();
    }
  }
}
