
using Microsoft.EntityFrameworkCore;

public class WriteRepository<T> : IWriteRepository<T> where T : class
{
    private readonly ShopDbContext _context;

    public WriteRepository(ShopDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task AddAsync(T entity)=> await Table.AddAsync(entity);

    public int Commit() => _context.SaveChanges();


    public Task<int> CommitAsunc() => _context.SaveChangesAsync();
   

    public void Delete(T entity) => Table.Remove(entity);
    public void Update(T entity)=>Table.Update(entity);
    
}

