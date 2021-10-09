using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XuanThuLab_NetCore.Models;

namespace XuanThuLab_NetCore.Services
{
    public class ProductService : List<ProductModel>
    {

        public ProductService()
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() { Id = 1,Name ="Xiaomi", Price = 500 },
                new ProductModel() { Id = 2, Name = "Nokia", Price = 150 },
                new ProductModel() { Id = 3, Name = "Iphone", Price = 100 },
            });
        }
    }
}
