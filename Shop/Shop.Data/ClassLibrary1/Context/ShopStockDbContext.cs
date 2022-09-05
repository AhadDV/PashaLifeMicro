
using Microsoft.EntityFrameworkCore;

public class ShopStockDbContext : DbContext
{
    public ShopStockDbContext(DbContextOptions<ShopStockDbContext> options) : base(options)
    {

    }
    public DbSet<ProductStock> ProductStock { get; set; }
}

