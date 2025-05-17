using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace swagger.Controllers.V2
{
	[ApiController]
	[ApiVersion("2.0")]
	[Route("api/v{version:apiversion}/products")]
	public class ProductsController : Controller
	{
		private static List<Products> products = new List<Products>()
		{
			new Products{Id=1,Name="Tablet"},
			new Products{Id=2,Name="Telefon"},
			new Products{Id=3,Name="Laptop"}
		};
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(products);
		}
		[HttpGet("Id")]
		public IActionResult GetById(int id)
		{
			var product = products.Find(x => x.Id == id);
			if (product == null)
			{
				return NotFound("Ürün bulunamadı");
			}
			return Ok(product);
		}
		[HttpPost]
		public IActionResult Add(Products product)
		{
			product.Id = products.Count + 1;
			products.Add(product);
			return Ok(products);
		}
	}

	public class Products
	{
		public int Id { get; set; }
		public string Name { get; set; }

	}
}
