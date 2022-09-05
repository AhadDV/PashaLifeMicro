
public interface IProductStockService
{
    public  Task AddAsync (ProductStockPostDto productStockPost);
    public Task RemoveAsync(int id);
    public Task<ProductStockGetDto> GetAsync(int id);

    public Task IdIsValid(int id);

  
}

