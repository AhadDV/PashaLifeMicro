
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class ReadRepository<T> : IReadRepository<T> where T : class
{
    private readonly ShopDbContext _context;

    public ReadRepository(ShopDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool isTacking)
    {
        var query = Table.AsQueryable();

        if (!isTacking)
            query = query.AsNoTrackingWithIdentityResolution();
        return query;
    }


    public IQueryable<T> GetAll(bool isTacking, Expression<Func<T, bool>> expression)
    {
        var query = GetAll(isTacking);

        return query.Where(expression);
    }

    public IQueryable<T> GetAll(bool isTacking, Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = GetAll(isTacking, expression);

        if (includes.Length > 0)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }

    public IQueryable<T> GetAll(bool isTacking, params string[] includes)
    {
        var query = GetAll(isTacking);
        if (includes.Length > 0)
        {

            foreach (string include in includes)
            {
                query = query.Include(include);

            }
        }
        return query;
    }



    public async Task<T> GetAsync(bool isTacking, Expression<Func<T, bool>> expression)
    {
        var query = Table.AsQueryable();

        if (!isTacking)
            query = query.AsNoTrackingWithIdentityResolution();

        return await query.FirstOrDefaultAsync(expression);
    }


    public async Task<T> GetAsync(bool isTacking, Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = Table.AsQueryable();

        if (!isTacking)
            query = query.AsNoTrackingWithIdentityResolution();

        foreach (string include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(expression);
    }


}

