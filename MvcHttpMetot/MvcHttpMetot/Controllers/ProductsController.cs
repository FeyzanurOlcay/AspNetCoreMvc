using Microsoft.AspNetCore.Mvc;
using MvcHttpMetot.Models;
using System.Text.Json;

namespace MvcHttpMetot.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private static List<Product> products = new List<Product>
		{
		 new Product { Id = 1, Name = "Laptop", Price = 15000 },
		 new Product { Id = 2, Name = "Mouse", Price = 500 },
		 new Product { Id = 3, Name = "Klavye", Price = 800 }
		};

		// GET - Tüm Ürünleri Listeleme

		//PowerShell ile işlem
		//Invoke-RestMethod -Uri "https://localhost:.../api/products" -Method GET
		[HttpGet]
		public IActionResult GetProducts()
		{
			return Ok(products);
		}
		// GET - Belirli Bir Ürünü Getirme
		[HttpGet("{id}")]
		public IActionResult GetProductById(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if (product == null)
				return NotFound("Ürün bulunamadı!");
			return Ok(product);
		}

		// POST - Yeni Ürün Ekleme
		//PowerShell ile işlem
		//$body = @{name  = "Kulaklık",price = 349.99| ConvertTo-Json 
		//>>Invoke-RestMethod -Uri "https://localhost:.../api/products" -Method POST -Body $body -ContentType "application/json"
		[HttpPost]
		public IActionResult AddProduct([FromBody] Product product)
		{
			if (product == null || string.IsNullOrEmpty(product.Name) || product.Price <= 0)
				return BadRequest("Geçersiz ürün bilgisi!");
			product.Id = products.Max(p => p.Id) + 1;
			products.Add(product);
			return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
		}  

		//  PUT - Ürünü Güncelleme (Tam Güncelleme)
		//$body = @{ id    = 1name  = "Kablosuz Kulaklık"price = 499.99| ConvertTo-Json
		//>>Invoke-RestMethod -Uri "https://localhost:.../api/products/1" -Method PUT -Body $body -ContentType "application/json"
		[HttpPut("{id}")]
		public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if (product == null)
				return NotFound("Ürün bulunamadı!");
			product.Name = updatedProduct.Name;
			product.Price = updatedProduct.Price;
			return Ok(product);
		}

		// PATCH - Ürünün Belirli Alanlarını Güncelleme
		//$body = @{price = 279.99| ConvertTo-Json
		//>>Invoke-RestMethod -Uri "https://localhost:.../api/products/1" -Method PATCH -Body $body -ContentType "application/json"
		[HttpPatch("{id}")]
		public IActionResult PatchProduct(int id, [FromBody] JsonElement updates)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if (product == null)
				return NotFound("Ürün bulunamadı!");
			if (updates.TryGetProperty("name", out var name))
				product.Name = name.GetString();
			if (updates.TryGetProperty("price", out var price))
				product.Price = price.GetDecimal();
			return Ok(product);
		}

		//  DELETE - Ürünü Silme
		//Invoke-RestMethod -Uri "https://localhost:.../api/products/1" -Method DELETE

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if (product == null)
				return NotFound("Ürün bulunamadı!");
			products.Remove(product);
			return Ok($"Ürün silindi: {product.Name}");

		}
	}
}
