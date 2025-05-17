using EfCoreUrunTakip.Data;
using Microsoft.AspNetCore.Mvc;
using EfCoreUrunTakip.Models;


namespace EfCoreUrunTakip.Controllers
{
	public class ProductController : Controller
	{
		private readonly AppDbContext _context;

		public ProductController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var products = _context.Products.ToList();
			return View(products);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Product product)
		{
			if (!ModelState.IsValid)
				return View(product);

			_context.Products.Add(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var product = _context.Products.Find(id);
			_context.Products.Remove(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
