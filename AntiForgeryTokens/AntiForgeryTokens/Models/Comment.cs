using System.ComponentModel.DataAnnotations;

namespace AntiForgeryTokens.Models
{
	public class Comment
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Yorum boş olamaz")]
		public string Message { get; set; }
	}
}
