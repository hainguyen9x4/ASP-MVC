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
    public long   Insert(User entity)
    {
      db.Users.Add(entity);
      db.SaveChanges();
      return entity.ID;
    }
    public User GetID(string userName)
    {
      return db.Users.SingleOrDefault(x => x.Username == userName);
    }
    public bool Login(string username, string password)
    {
      var res = db.Users.Count(x => x.Username == username && x.Password == password);
      if (res > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public void Logout()
    {

    }
  }
}
