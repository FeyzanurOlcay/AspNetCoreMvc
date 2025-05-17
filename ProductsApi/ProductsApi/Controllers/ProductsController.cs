using Microsoft.AspNetCore.Mvc;
using System;

namespace ProductsApi.Controllers
{
	[Route("api/[controller]")] // URL: api/products
	[ApiController]
	public class ProductsController : Controller
	{
		private static List<string> products = new List<string> { "Laptop", "Telefon", "Tablet" };
		// GET: api/products
		[HttpGet]
		public IActionResult GetProducts()
		{
			return Ok(products); // JSON formatında ürünleri döndür
		}
		// POST: api/products
		[HttpPost]
		public IActionResult AddProduct([FromBody] string product)
		{
			products.Add(product);
			return Ok($"Ürün eklendi: {product}");
		}
		// DELETE: api/products/{index}
		[HttpDelete("{index}")]
		public IActionResult DeleteProduct(int index)
		{
			if (index < 0 || index >= products.Count)
				return NotFound("Ürün bulunamadı!");
			var deletedProduct = products[index];
			products.RemoveAt(index);
			return Ok($"Silinen Ürün: {deletedProduct}");
		}
	}
}
