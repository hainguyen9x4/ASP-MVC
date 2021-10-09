using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XuanThuLab_NetCore.Services;

namespace XuanThuLab_NetCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(x => x.Id == id).FirstOrDefault();
            if(product == null)
            {

                TempData["Notify"] = "Khong tim thay san pham!";
                return View();
                //return NotFound();
            }
            //return View(product);
            ViewData["product"] = product;
            return View();
        }
    }
}
