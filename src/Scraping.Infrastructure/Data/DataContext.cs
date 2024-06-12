using Microsoft.EntityFrameworkCore;
using Scraping.Domain.Entities;

namespace Scraping.Infrastructure.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<Component> Components { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodItem>().HasKey(f => f.Code); 
    }
}
