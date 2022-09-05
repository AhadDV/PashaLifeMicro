
using System.Linq.Expressions;

public interface IReadRepository<T> : IRepository<T> where T : class
{
    public  Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking);
}
