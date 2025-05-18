using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace MovieApp.Web.Models
{
    public class Movie
    {
        public int MovieId {  get; set; }
        [DisplayName("Başlık")]
        [Required(ErrorMessage ="Film başlığı eklemelisiniz.")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Film başlığı 5-10 karakter arasında olmalıdır.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Film açıklaması ekleyiniz.")]
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Players { get; set; }
        public string ImageUrl {  get; set; }
        [Required]
		public int? GenreId { get; set; }
	}
}
