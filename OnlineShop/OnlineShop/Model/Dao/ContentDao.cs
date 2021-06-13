using Model.EF;
using PagedList;
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
    public IEnumerable<Content> GetAllContent(string searchString, int page, int page_size)
    {
      IQueryable<Content> model = db.Contents;
      if (!string.IsNullOrEmpty(searchString))
      {
        model = model.Where(x => x.Name.Contains(searchString) || x.Detail.Contains(searchString));
      }
      return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, page_size);
    }
    public Content GetFromID(long id)
    {
      return db.Contents.Where(x => x.ID == id).SingleOrDefault();
    }
    public long Insert(Content entity)
    {
      db.Contents.Add(entity);
      db.SaveChanges();
      return entity.ID;
    }
    public bool Update(Content entity)
    {
      try
      {
        var user = db.Contents.Find(entity.ID);
        if (!String.IsNullOrEmpty(entity.Name))
        {
          user.Name = entity.Name;
        }
        if (!String.IsNullOrEmpty(entity.Description))
        {
          user.Description = entity.Description;
        }
        if (!String.IsNullOrEmpty(entity.Detail))
        {
          user.Detail = entity.Detail;
        }
        if (!String.IsNullOrEmpty(entity.MetaDescription))
        {
          user.MetaDescription = entity.MetaDescription;
        }
        if (!String.IsNullOrEmpty(entity.MetaKeyword))
        {
          user.MetaKeyword = entity.MetaKeyword;
        }
        if (!String.IsNullOrEmpty(entity.Tag))
        {
          user.Tag = entity.Tag;
        }
        if (entity.Warranty != null)
        {
          user.Warranty = entity.Warranty;
        }
        if (entity.Status != null)
        {
          user.Status = entity.Status;
        }
        if (entity.CategoryID != null)
        {
          user.CategoryID = entity.CategoryID;
        }
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
    public bool Delete(long id)
    {
      try
      {
        var con = db.Contents.Find(id);
        db.Contents.Remove(con);
        db.SaveChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
