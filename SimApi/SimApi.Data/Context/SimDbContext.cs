using Microsoft.EntityFrameworkCore;
using SimApi.Data;

namespace SimApi.Data.Context;

public class SimDbContext : DbContext
{
    public SimDbContext(DbContextOptions<SimDbContext> options) : base(options)
    {

    }

    // dbset
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
