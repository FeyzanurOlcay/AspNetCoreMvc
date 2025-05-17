using System.ComponentModel.DataAnnotations;

namespace UrunProje.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ürün adı zorunludur")]
        public string Name { get; set; }

        [Range(1,10000,ErrorMessage ="Fiyat 1 ile 10.000 arasında olmalıdır")]

        public decimal Price { get; set; }
    }
}
