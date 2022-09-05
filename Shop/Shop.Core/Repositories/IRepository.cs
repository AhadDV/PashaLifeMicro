

using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : class
    {
    public  DbSet<T> Table { get;}
}

