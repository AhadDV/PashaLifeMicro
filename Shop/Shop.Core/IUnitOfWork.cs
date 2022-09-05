
public interface IUnitOfWork
{
    ICategoryReadRepository CategoryReadRepository { get; }
    ICategoryWriteRepository CategoryWriteRepository { get; }
    IProductReadRepository ProductReadRepository { get; }
    IProductWriteRepository ProductWriteRepository { get; }
}
