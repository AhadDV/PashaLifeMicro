
public class UnitOfWork : IUnitOfWork
{
    private readonly ShopDbContext _context;

    public UnitOfWork(ShopDbContext context)
    {
        _context = context;
    }

    CategoryReadRepository _categoryReadRepository;
    CategoryWriteRepository _categoryWriteRepository;
    ProductReadRepository _productReadRepository;
    ProductWriteRepository _productWriteRepository;



    public ICategoryReadRepository CategoryReadRepository => _categoryReadRepository??new CategoryReadRepository(_context);

    public ICategoryWriteRepository CategoryWriteRepository => _categoryWriteRepository??new CategoryWriteRepository(_context);

    public IProductReadRepository ProductReadRepository => _productReadRepository??new ProductReadRepository(_context);

    public IProductWriteRepository ProductWriteRepository => _productWriteRepository??new ProductWriteRepository(_context);
}
