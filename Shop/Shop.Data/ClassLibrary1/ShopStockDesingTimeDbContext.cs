
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ShopStockDesingTimeDbContext : IDesignTimeDbContextFactory<ShopStockDbContext>
{
    public ShopStockDbContext CreateDbContext(string[] args)
    {

        DbContextOptionsBuilder<ShopStockDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-15FAUDE\\SQLEXPRESS;Database=ShopApiStockDb;Trusted_Connection=True;", b => b.MigrationsAssembly("Stock.Data"));
        return new(dbContextOptionsBuilder.Options);

    }
}

