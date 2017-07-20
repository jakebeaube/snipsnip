using Microsoft.EntityFrameworkCore;

namespace snipsnip.Models
{
  public class MyDbContext : DbContext
  {
    public DbSet<Code> snipsnip { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("DataSource=snipsnip.db");
    }
  }