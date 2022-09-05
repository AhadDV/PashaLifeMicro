
public class ProductStockService : IProductStockService
{
    private readonly IUnitOfwork _unitOfwork;

    public ProductStockService(IUnitOfwork unitOfwork)
    {
        _unitOfwork = unitOfwork;
    }


    public async Task AddAsync(ProductStockPostDto productStockPost)
    {
        ProductStock productStock = await _unitOfwork.ProductStockReadRepository.GetAsync(x => x.ProductId == productStockPost.ProductId, true);

        if (productStock == null)
        {
         await IdIsValid(productStockPost.ProductId);
            ProductStock newProductStock = new ProductStock
            {
                ProductId = productStockPost.ProductId,
                StockCount = productStockPost.ProductCout
            };
            await _unitOfwork.ProductStockWriteRepository.AddAsync(newProductStock);
        }
        else
        {
            if (productStock.StockCount == 0)
                throw new OutOfStack("Out Of Stack");

                productStock.StockCount = productStockPost.ProductCout;
        }
        await _unitOfwork.ProductStockWriteRepository.CommitAsync();

    }

    public async Task<ProductStockGetDto> GetAsync(int id)
    {
        ProductStock productStock = await _unitOfwork.ProductStockReadRepository.GetAsync(x => x.ProductId == id, false);


        if (productStock == null)
            throw new InvalidProductId("Out Of Stack");


        if (productStock.StockCount == 0)
            throw new OutOfStack("Out Of Stack");

        ProductStockGetDto productSTockGetDto = new ProductStockGetDto
        {
            ProductCount = productStock.StockCount,
            ProductId = productStock.ProductId,
        };
        return productSTockGetDto;
    }

    public async Task IdIsValid(int id)
    {
        using HttpClient client = new HttpClient();
      var result= await client.GetAsync($"https://localhost:7265/api/Products/{id}");

        if (result.StatusCode != System.Net.HttpStatusCode.OK)
            throw new InvalidProductId("Ivalid produc id");
    }

    public async Task RemoveAsync(int id)
    {
        ProductStock productStock = await _unitOfwork.ProductStockReadRepository.GetAsync(x => x.ProductId == id, false);

        if (productStock == null)
            throw new InvalidProductId("Invalid product id");

        if (productStock.StockCount == 0)
            throw new OutOfStack("Out Of Stack");

        productStock.StockCount = 0;
        _unitOfwork.ProductStockWriteRepository.Update(productStock);
        await _unitOfwork.ProductStockWriteRepository.CommitAsync();
          
    }
}

