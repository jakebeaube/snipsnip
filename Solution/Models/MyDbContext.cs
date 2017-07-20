using Microsoft.EntityFrameworkCore;

namespace CoffeeApp.Models
{
  public class MyDbContext : DbContext
  {
    public DbSet<Coffee> Coffees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("DataSource=Coffees.db");
    }
  }
}