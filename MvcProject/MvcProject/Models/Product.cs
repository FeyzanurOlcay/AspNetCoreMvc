using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Ürün adı zorunludur!")]
		public string Name { get; set; }
		[Range(1,10000,ErrorMessage ="Fiyat 1 ve 10.000 aralığında olmalıdır")]
		public decimal Price { get; set; }
	}
}
