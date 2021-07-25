using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class SlideDao
  {
    OnlineShopDbContext db = null;
    public SlideDao()
    {
      db = new OnlineShopDbContext();
    }
    public IEnumerable<Slide> GetAllSlide(int page, int page_size)
    {
      return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToPagedList(page, page_size);
    }
    public long Insert(Slide entity)
    {
      if (db.Slides.SingleOrDefault(x => x.Image == entity.Image) == null)
      {
        db.Slides.Add(entity);
        db.SaveChanges();
        return entity.ID;
      }
      else return 0;
    }
    public bool Delete(long id)
    {
      if (db.Slides.SingleOrDefault(x => x.ID == id) != null)
      {
        var data = db.Slides.Find(id);
        db.Slides.Remove(data);
        db.SaveChanges();
        return true;
      }
      else return false;
    }
  }
}
