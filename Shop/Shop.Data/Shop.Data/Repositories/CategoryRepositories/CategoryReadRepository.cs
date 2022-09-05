public class CategoryReadRepository:ReadRepository<Category>,ICategoryReadRepository
{
    public CategoryReadRepository(ShopDbContext context):base(context)
    {

    }
}

