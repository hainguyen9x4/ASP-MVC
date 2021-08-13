using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "ProductCategory",
          url: "product/{metatitle}-{cateId}",
          defaults: new { controller = "Home", action = "Category", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" }
      );
      routes.MapRoute(
          name: "ProductDetail",
          url: "detail/{metatitle}-{Id}",
          defaults: new { controller = "Home", action = "ProductDetail", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" }
      );
      routes.MapRoute(
          name: "AddCart",
          url: "addproduct",
          defaults: new { controller = "Cart", action = "AddToCart", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" }
      );
      routes.MapRoute(
          name: "PaymetnSuccess",
          url: "success-payment",
          defaults: new { controller = "Cart", action = "SuccessPayment", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" }
      );
      routes.MapRoute(// luon luon phai de xuong cuoi cung, khi chay qua het maprout thi se chay default
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" }
      );
    }
  }
}
