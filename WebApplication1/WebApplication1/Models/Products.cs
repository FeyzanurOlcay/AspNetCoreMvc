using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
	public class Products
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Ürün adı zorunludur.")]
		public string Name { get; set; }
		[Range(1,10000,ErrorMessage ="Fiyat 1 ve 10000 aralığında olmalıdır.")]
		public decimal Price { get; set; }
	}
}
