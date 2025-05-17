using Microsoft.AspNetCore.Mvc;
using UrunProje.Models;

namespace UrunProje.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name ="Laptop",Price = 5000},
            new Product { Id = 2, Name ="Tablet",Price = 1000},
            new Product { Id = 3, Name ="Telefon",Price = 8000}
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
            product.Id=products.Count+1;
            products.Add(product);
            return RedirectToAction("List");
        }
    }   
}
