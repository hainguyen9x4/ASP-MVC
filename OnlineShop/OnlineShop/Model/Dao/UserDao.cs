using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      if (db.Users.Single(x => x.Username == entity.Username) == null)
      {
        db.Users.Add(entity);
        db.SaveChanges();
        return entity.ID;
      }
      else return 0;
    }
    public User GetID(string userName)
    {
      return db.Users.SingleOrDefault(x => x.Username == userName);
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
    public void Logout()
    {

    }
  }
}
