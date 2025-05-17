using Microsoft.EntityFrameworkCore;
using EfCoreUrunTakip.Models;
namespace EfCoreUrunTakip.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Product> Products { get; set; }


	}
		
}
