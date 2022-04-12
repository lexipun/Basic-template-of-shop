using Microsoft.AspNetCore.Mvc;
using ShopBussinesLogic.Models;
using ShopBussinesLogic.ProductOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeShop.Controllers
{
    public class HomeController : Controller
    {
            BasicCRUD operations = new BasicCRUD();
        public IActionResult Index()
        {
            List<Product> products = operations.GetAllProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            operations.Create(product);



            return Redirect("Index");
        }
    }
}
