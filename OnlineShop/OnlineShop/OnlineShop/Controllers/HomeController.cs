using Model.Dao;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      var dao = new ProductDao();
      ViewBag.NewProduct = dao.GetNewProductHome(9);
      SetViewBagTopHotProduct(4);
      return View();
    }
    private void SetViewBagTopHotProduct(int top)
    {
      var dao = new ProductDao();
      ViewBag.HotProduct = dao.GetHotProduct(top);
    }
    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
    [ChildActionOnly]
    public ActionResult MainMenu()
    {
      var model = new MenuDao().GetAllMenuActive(1);
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult TopMenu()
    {
      var model = new MenuDao().GetAllMenuActive(2);
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult ProductCategory()
    {
      var model = new ProductCategoryDao().GetAllCategoryActive();
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult Slider()
    {
      var model = new SlideDao().GetAllSlideEnable(3);
      return PartialView(model);
    }
    [ChildActionOnly]
    public ActionResult Footer()
    {
      var model = new FooterDao().GetAllSlide();
      return PartialView(model);
    }
    public ActionResult Category(long cateId, int page = 1, int pageSize = 4)
    {
      var dao = new ProductDao();
      int totalRecode = 0;
      var list = dao.GetAllCategoryProduct(cateId, ref totalRecode, page, pageSize);
      ViewBag.CategoryName = new ProductCategoryDao().GetFromID(cateId).Name;
      ViewBag.MaxPage = 5;
      ViewBag.TotalPage = totalRecode / 4 + (totalRecode % 4 == 0 ? 0 : 1);
      ViewBag.Page = page;
      ViewBag.First = 1;
      ViewBag.Prev = page - 1;
      ViewBag.Last = ViewBag.TotalPage;
      ViewBag.Next = page + 1;
      return View(list);
    }
    public ActionResult ProductDetail(long Id)
    {
      var dao = new ProductDao();
      var product = dao.GetProductFromID(Id);
      ViewBag.ListRelated = dao.GetAllRelatedProduct(product);
      return View(product);
    }
    [ChildActionOnly]
    public ActionResult Logo()
    {
      var model = new LogoDao().GetFirstEnableLogo();
      return PartialView(model);
    }
  }
}