using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class ProductController : Controller
	{
		public static List<Products> products = new List<Products>();

		public IActionResult Index()
		{
			return View(products);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Products product)
		{
			if(!ModelState.IsValid)
			{
				return View(products);
			}
			product.Id = products.Count + 1;
			products.Add(product);
			return RedirectToAction("Index");
		}
	}
}
