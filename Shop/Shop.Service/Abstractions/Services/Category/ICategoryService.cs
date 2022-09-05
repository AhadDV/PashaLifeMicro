namespace Shop.Service.Abstractions.Services.Category
{
    public interface ICategoryService
    {
        public Task AddAsync(CategoryPostDto postDto);
        public Task UpdateAsync(int id,CategoryPostDto postDto);
        public Task DeleteAsync(int id);
        public Task<CategoryGetDto> GetByIdAsync(int id);
        public  Task<List<CategoryGetDto>> GetAll();
    }
}