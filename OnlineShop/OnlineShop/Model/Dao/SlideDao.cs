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
      return db.Slides.OrderBy(x => x.DisplayOrder).ToPagedList(page, page_size);
    }
    public List<Slide> GetAllSlideEnable(int top)
    {
      return db.Slides.Where(x => x.Status == true).OrderBy(x=>x.ID).Take(top).ToList();
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
    public Slide GetSlideFromID(long id)
    {
      return db.Slides.SingleOrDefault(x => x.ID == id);
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
    public bool Update(Slide entity)
    {
      try
      {
        var slide = db.Slides.Find(entity.ID);
        if (!String.IsNullOrEmpty(entity.Image))
        {
          slide.Image = entity.Image;
        }
        if (entity.DisplayOrder!=null)
        {
          slide.DisplayOrder = entity.DisplayOrder;
        }
        if (!String.IsNullOrEmpty(entity.Description))
        {
          slide.Description = entity.Description;
        }
        if (entity.Status != null)
        {
          slide.Status = entity.Status;
        }
        slide.ModifyBy = entity.ModifyBy;
        slide.ModifyDate = DateTime.Now;
        db.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        //Write log
        return false;
      }
    }
    public bool ChangeStatus(long id)
    {
      if (db.Slides.SingleOrDefault(x => x.ID == id) != null)
      {
        var data = db.Slides.Find(id);
        data.Status = !data.Status;
        try
        {
          db.SaveChanges();
          return (bool)data.Status;
        } catch (Exception ex)
        {
          throw ex;
        }
      }
      else return false;
    }
  }
}
