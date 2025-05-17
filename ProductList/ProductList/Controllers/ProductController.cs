using Microsoft.AspNetCore.Mvc;
using ProductList.Models;

namespace ProductList.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{ // Örnek ürün listesi oluşturma (Model katmanında veri işleme)
			List<Product> products = new List<Product>()
		    {
				new Product{ Id = 1, Name = "Laptop", Price = 15000 },
				new Product{ Id = 2, Name = "Tablet", Price = 7000 },
				new Product{ Id = 3, Name = "Akıllı Telefon", Price = 5000 }
		    };

			// Controller metodları ve View etkileşimi: Veriyi View'a gönderiyoruz

			return View(products);
		}
	}
}
