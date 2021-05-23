using Models.Framework;
using System;
using System.Collections.Generic;
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
  }
}
