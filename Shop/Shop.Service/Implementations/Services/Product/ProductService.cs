
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(ProductPostDto postDto)
    {
        Category category = await _unitOfWork.CategoryReadRepository.GetAsync(false, x => x.id == postDto.CategoryId);
        if (category == null)
            throw new ItemNotFoundExeption("Category not found");

        Product product=_mapper.Map<Product>(postDto);
        await _unitOfWork.ProductWriteRepository.AddAsync(product);
        await _unitOfWork.ProductWriteRepository.CommitAsunc();
    }

    public async Task DeleteAsync(int id)
    {
        Product product = await _unitOfWork.ProductReadRepository.GetAsync(true,x=>x.id==id&&!x.IsDeleted);

        if (product == null)
            throw new ItemNotFoundExeption($"{id}-Product not found");

        product.IsDeleted = true;
        await _unitOfWork.ProductWriteRepository.CommitAsunc();
    }

    public async Task<ListDto<ProductGetDto>> GetAll()
    {
       var products= _unitOfWork.ProductReadRepository.GetAll(false,x=>!x.IsDeleted ,"Category");

         ListDto<ProductGetDto> listDto = new ListDto<ProductGetDto>();
        listDto.Values = await products.Select(x => new ProductGetDto { Name = x.Name, CategoryId = x.CategoryId, State = x.State, CreatedDate = x.CreatedDate, id = x.id, Price = x.Price }).ToListAsync();
        return listDto;
    }

    public async Task<ProductGetDto> GetByIdAsync(int id)
    {
       ProductGetDto productGetDto=_mapper.Map<ProductGetDto>(await _unitOfWork.ProductReadRepository.GetAsync(false,x=>x.id==id&&!x.IsDeleted,"Category"));
        if (productGetDto == null) throw new ItemNotFoundExeption("Item not found");

        return productGetDto;
    
    }

    public async Task UpdateAsync(int id, ProductPostDto postDto)
    {
        Product ExsistProduct = await _unitOfWork.ProductReadRepository.GetAsync(true, x => x.id == id && !x.IsDeleted);

        if (ExsistProduct == null)
            throw new ItemNotFoundExeption($"{id}-Product not found");

        Category category = await _unitOfWork.CategoryReadRepository.GetAsync(false, x => x.id == postDto.CategoryId);
        if (category == null)
            throw new ItemNotFoundExeption("Category not found");
        ExsistProduct.Name = postDto.Name;
        ExsistProduct.CategoryId = postDto.CategoryId;
        ExsistProduct.State = postDto.State;
        ExsistProduct.Price = postDto.Price;
         _unitOfWork.ProductWriteRepository.Update(ExsistProduct);
         _unitOfWork.ProductWriteRepository.Commit();
    }

}

