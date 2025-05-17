using System.ComponentModel.DataAnnotations;

namespace M.BindingValidation.Models
{
	public class Products
	{
		[Required(ErrorMessage = "Ürün adı zorunludur.")]
		[MinLength(3, ErrorMessage = "Ürün adı en az 3 karakter olmalıdır.")]
		public string Name { get; set; }
		[Range(1, 10000, ErrorMessage = "Fiyat 1 ile 10.000 arasında olmalıdır.")]
		public decimal Price { get; set; }
	}
}
