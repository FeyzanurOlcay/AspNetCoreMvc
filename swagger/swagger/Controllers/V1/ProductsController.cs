using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace swagger.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
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
