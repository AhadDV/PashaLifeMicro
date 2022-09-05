
public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(ShopDbContext context):base(context)
    {

    }
}

