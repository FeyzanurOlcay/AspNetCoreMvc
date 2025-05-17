using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;
using System.Collections.Generic;

namespace MvcProject.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
                new Product { Id = 1,Name="Laptop",Price=15000},
                new Product { Id = 2,Name="Telefon",Price=9000},
                new Product { Id = 3,Name="Tablet",Price=4000}
        };

        public IActionResult List()
        {
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            product.Id = products.Count+1;
            products.Add(product);
            return RedirectToAction("List");
        }


    }
}
