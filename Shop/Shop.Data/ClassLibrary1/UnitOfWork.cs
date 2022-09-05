
public class UnitOfWork : IUnitOfwork
{
    private readonly ShopStockDbContext _context;

    public UnitOfWork(ShopStockDbContext context)
    {
        _context = context;
    }

    ProductStockReadRepository _productStockReadRepository;
    ProductStockWriteRepository _productStockWriteRepository;
     


    IProductStockReadRepository IUnitOfwork.ProductStockReadRepository => _productStockReadRepository??new ProductStockReadRepository(_context);

    IProductStockWriteRepository IUnitOfwork.ProductStockWriteRepository =>_productStockWriteRepository?? new ProductStockWriteRepository(_context);
}
