
public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(ShopDbContext context) : base(context)
    {
    }
}
