
public interface IWriteRepository<T> : IRepository<T> where T : class
{
    public Task AddAsync(T entity);
    public void Update(T entity);
    public void Delete(T entity);

    public int Commit();
    public Task<int> CommitAsunc();
    
}

