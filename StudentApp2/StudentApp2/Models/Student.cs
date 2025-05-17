using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;
namespace StudentApp2.Models
{
	public class Student
	{
		public int Id { get; set; }
		[Required]
		public string FullName {  get; set; }
		[Required]
		public string StudentNumber { get; set; }
		[DataType(DataType.Date)]
		public DateTime BirthDate { get; set; }
	}
}
