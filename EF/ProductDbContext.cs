using Microsoft.EntityFrameworkCore;

namespace ef;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }
    public DbSet<DbProduct> Products { get; set; }
    public DbSet<DbVat> Vat{ get; set; }    
}
