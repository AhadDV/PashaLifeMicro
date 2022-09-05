
public interface IProductService
{
    public  Task AddAsync(ProductPostDto postDto);
    public Task UpdateAsync(int id,ProductPostDto postDto);
    public Task DeleteAsync(int id);
    public Task<ProductGetDto> GetByIdAsync(int id);
    public Task<ListDto<ProductGetDto>> GetAll();
  
}

