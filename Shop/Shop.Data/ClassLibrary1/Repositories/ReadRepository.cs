
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class ReadRepository<T> : IReadRepository<T> where T : class
{
    private readonly ShopStockDbContext _context;

    public ReadRepository(ShopStockDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();


    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking)
    {
        var query = Table.AsQueryable();

        if (!isTracking)
            query = query.AsNoTrackingWithIdentityResolution();

        return await query.FirstOrDefaultAsync(expression); ;
    }
}

