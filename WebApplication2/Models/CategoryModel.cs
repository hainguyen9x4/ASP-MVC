using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class CategoryModel
  {
    private OnlineDbContext context = null;
    public CategoryModel()
    {
      context = new OnlineDbContext();
    }
    public List<Category> GetAllCategory()
    {
      var list = context.Database.SqlQuery<Category>("GetAllCategory").ToList();
      return list;
    }
    public int AddACategory(string name, int? order, bool? status)
    {
      int ret;
      var parameter = new SqlParameter[]
      {
        new SqlParameter("@Name",name),
        new SqlParameter("@Order",order),
        new SqlParameter("@Status",status)
      };
      ret = context.Database.ExecuteSqlCommand("AddACategory @Name,@Order,@Status", parameter);
      return ret;
    }
  }
}
