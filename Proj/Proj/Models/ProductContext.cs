using Microsoft.EntityFrameworkCore;

namespace Proj.Models
{
    public class ProductContext:DbContext
    {
            public ProductContext(DbContextOptions<ProductContext> options) : base(options)
            {

            }

            //public DbSet<Product> ProductList { get; set; } = null!;
        public DbSet<SuperVillain> SuperVillain { get; set; }
    }
}
