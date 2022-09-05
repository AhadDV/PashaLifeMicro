
public class ProductStockReadRepository : ReadRepository<ProductStock>, IProductStockReadRepository
{
    public ProductStockReadRepository(ShopStockDbContext context) : base(context)
    {

    }


}

