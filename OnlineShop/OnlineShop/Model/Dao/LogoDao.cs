using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class LogoDao
  {
    OnlineShopDbContext db = null;
    public LogoDao()
    {
      db = new OnlineShopDbContext();
    }
    public IEnumerable<Logo> GetAllLogo()
    {
      return db.Logos.OrderBy(x => x.CreatedDate).ToList();
    }
    public long Insert(Logo entity)
    {
      if (db.Logos.SingleOrDefault(x => x.Image == entity.Image) == null)
      {
        db.Logos.Add(entity);
        db.SaveChanges();
        return entity.ID;
      }
      else return 0;
    }
    public Logo GetLogoFromID(long id)
    {
      return db.Logos.SingleOrDefault(x => x.ID == id);
    }
    public bool Delete(long id)
    {
      if (db.Logos.SingleOrDefault(x => x.ID == id) != null)
      {
        var data = db.Logos.Find(id);
        db.Logos.Remove(data);
        db.SaveChanges();
        return true;
      }
      else return false;
    }
    public bool Update(Logo entity)
    {
      try
      {
        var logo = db.Logos.Find(entity.ID);
        if (!String.IsNullOrEmpty(entity.Image))
        {
          logo.Image = entity.Image;
        }
        if (!String.IsNullOrEmpty(entity.Name))
        {
          logo.Name = entity.Name;
        }
        if (!String.IsNullOrEmpty(entity.CreatedBy))
        {
          logo.CreatedBy = entity.CreatedBy;
        }
        if (entity.Status != null)
        {
          logo.Status = entity.Status;
        }
        logo.ModifyBy = entity.ModifyBy;
        logo.ModifyDate = DateTime.Now;
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
      if (db.Logos.SingleOrDefault(x => x.ID == id) != null)
      {
        var data = db.Logos.Find(id);
        data.Status = !data.Status;
        try
        {
          db.SaveChanges();
          return (bool)data.Status;
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
      else return false;
    }
    public Logo GetFirstEnableLogo()
    {
      return db.Logos.Where(x=>x.Status == true).OrderBy(x => x.CreatedDate).ToList().FirstOrDefault();
    }
  }
}
