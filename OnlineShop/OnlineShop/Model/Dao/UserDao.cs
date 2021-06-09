using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.Dao
{
  public class UserDao
  {
    OnlineShopDbContext db = null;
    public UserDao()
    {
      db = new OnlineShopDbContext();
    }
    public long Insert(User entity)
    {
      if (db.Users.SingleOrDefault(x => x.Username == entity.Username) == null)
      {
        db.Users.Add(entity);
        db.SaveChanges();
        return entity.ID;
      }
      else return 0;
    }
    public IEnumerable<User> GetListUser(int page, int page_size)
    {
      return db.Users.OrderBy(x=>x.CreatedDate).ToPagedList(page, page_size);
    }
    public User GetID(string userName)
    {
      return db.Users.SingleOrDefault(x => x.Username == userName);
    }
    public User GetUserFromID(int id)
    {
      return db.Users.Find(id);
    }
    public int Login(string username, string password)
    {
      var res = db.Users.SingleOrDefault(x => x.Username == username);
      if (res == null)
      {
        return 0;//no exist
      }
      else if(res.Status == false)
      {
        return -2;//block
      }
      else
      {
        if(res.Password == password)
        {
          return 1;//ok!
        }
        else
        {
          return -1;//wrong pass
        }
      }
    }
    public bool Update(User entity)
    {
      try
      {
        var user = db.Users.Find(entity.ID);
        if (!String.IsNullOrEmpty(entity.Name))
        {
          user.Name = entity.Name;
        }
        if (!String.IsNullOrEmpty(entity.Email))
        {
          user.Email = entity.Email;
        }        
        if (!String.IsNullOrEmpty(entity.Password))
        {
          user.Password = entity.Password;
        }
        if (!String.IsNullOrEmpty(entity.Address))
        {
          user.Address = entity.Address;
        }
        user.ModifyBy = entity.ModifyBy;
        user.ModifyDate = DateTime.Now;
        if (!String.IsNullOrEmpty(entity.Phone))
        {
          user.Phone = entity.Phone;
        }
        db.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        //Write log
        return false;
      }
    }
    public void Logout()
    {

    }
    public bool Delete(int userID)
    {
      try
      {
        var user = db.Users.Find(userID);
        db.Users.Remove(user);
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
