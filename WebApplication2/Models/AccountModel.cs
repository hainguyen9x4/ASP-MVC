using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class AccountModel
  {
    private OnlineDbContext context = null;
    public AccountModel()
    {
      context = new OnlineDbContext();
    }
    public bool Login(string username, string password)
    {
      object[] sqlparameter = 
      {
        new SqlParameter("@UserName",username),
        new SqlParameter("@Password",password)
      };
      var ret = context.Database.SqlQuery<bool>("Account_Login @UserName,@Password", sqlparameter).SingleOrDefault();
      return ret;
    }
  }
}
