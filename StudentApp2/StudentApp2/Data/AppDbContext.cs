using Microsoft.EntityFrameworkCore;
using StudentApp2.Models;

namespace StudentApp2.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }
		public DbSet<Student> Students { get; set; }
	}
}
