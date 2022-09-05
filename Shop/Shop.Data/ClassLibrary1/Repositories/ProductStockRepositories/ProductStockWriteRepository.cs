
public class ProductStockWriteRepository : WriteRepository<ProductStock>, IProductStockWriteRepository
{
    public ProductStockWriteRepository(ShopStockDbContext context):base(context)
    {

    }
}

