
using Microsoft.EntityFrameworkCore;

public class WriteRepository<T> : IWriteRepository<T> where T : class
{
    private readonly ShopStockDbContext _context;

    public WriteRepository(ShopStockDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task AddAsync(T entity)=> await Table.AddAsync(entity);
  

    public int Commit() => _context.SaveChanges();


    public Task<int> CommitAsync() => _context.SaveChangesAsync();

    public void Update(T entity)=>Table.Update(entity);
 
}

