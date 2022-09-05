
public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(ShopDbContext context) : base(context)
    {

    }
}

