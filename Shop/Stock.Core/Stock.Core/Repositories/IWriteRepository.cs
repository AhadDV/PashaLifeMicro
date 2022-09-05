
public interface IWriteRepository<T> : IRepository<T> where T : class
{
    public Task AddAsync(T entity);
    public void Update(T entity);

    public Task<int> CommitAsync();
    public int Commit();
  
    
}

