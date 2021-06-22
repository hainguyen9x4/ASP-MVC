using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class MenuDao
  {
    OnlineShopDbContext db = null;
    public MenuDao()
    {
      db = new OnlineShopDbContext();
    }
    public List<Menu> GetAllMenuActive(int MenuType)
    {
      return db.Menus.Where(x => x.Status == true && x.TypeID == MenuType).OrderBy(x => x.DisplayOrder).ToList();
    }
  }
}
