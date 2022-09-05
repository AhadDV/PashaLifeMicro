
using System.Linq.Expressions;

public interface IReadRepository<T> : IRepository<T> where T : class
{
    public Task<T> GetAsync(bool isTacking, Expression<Func<T, bool>> expression);
    public Task<T> GetAsync(bool isTacking, Expression<Func<T, bool>> expression,params string[] includes);

    public IQueryable<T> GetAll(bool isTacking);
    public IQueryable<T> GetAll(bool isTacking, Expression<Func<T, bool>> expression);
    public IQueryable<T> GetAll(bool isTacking, Expression<Func<T, bool>> expression, params string[] includes);
    public IQueryable<T> GetAll(bool isTacking, params string[] includes);

    
}
