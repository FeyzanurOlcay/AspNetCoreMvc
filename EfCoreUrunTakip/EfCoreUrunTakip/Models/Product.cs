using System.ComponentModel.DataAnnotations;

namespace EfCoreUrunTakip.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[Range(1, 10000)]
		public decimal Price { get; set; }
	}
}
