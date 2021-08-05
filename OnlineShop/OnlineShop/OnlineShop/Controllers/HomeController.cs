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
    public ActionResult Category(long cateId)
    {
      var dao = new ProductDao();
      var list = dao.GetAllCategoryProduct(cateId);
      ViewBag.CategoryName = new ProductCategoryDao().GetFromID(cateId).Name;
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