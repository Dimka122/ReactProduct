using Microsoft.EntityFrameworkCore;

namespace Project1.Models
{
    public class ProductContext:DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            new ConfigurationBuilder().AddUserSecrets<ProductContext>()
                .Build()
                .Providers
                .First()
                .TryGet("ProductConnection", out var connStr);
            optionsBuilder.UseSqlServer(connStr);
        }
    }


    public DbSet<Product> ProductList { get; set; } = null!;
    }
}
