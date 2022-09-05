
public interface IUnitOfwork
{
    IProductStockReadRepository ProductStockReadRepository { get; }
    IProductStockWriteRepository ProductStockWriteRepository { get; }
}
