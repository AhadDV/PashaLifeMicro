
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Service.Abstractions.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddAsync(CategoryPostDto postDto)
    {
        if (null != await _unitOfWork.CategoryReadRepository.GetAsync(false, x => x.Name.ToLower() == postDto.Name.ToLower()))
        {
            throw new ItemExsistExeption($"{postDto.Name} alrady exsist");

        }

        await _unitOfWork.CategoryWriteRepository.AddAsync(_mapper.Map<Category>(postDto));
        await _unitOfWork.ProductWriteRepository.CommitAsunc();
    }

    public async Task DeleteAsync(int id)
    {
        Category category = await _unitOfWork.CategoryReadRepository.GetAsync(true, x => x.id == id);
        if (category == null)
        {
            throw new ItemNotFoundExeption("Item not found");
        }

        _unitOfWork.CategoryWriteRepository.Delete(category);
        await _unitOfWork.CategoryWriteRepository.CommitAsunc();
    }

    public async Task<List<CategoryGetDto>> GetAll()
    {
        var query = _unitOfWork.CategoryReadRepository.GetAll(false);

        List<CategoryGetDto> result = new List<CategoryGetDto>();
        result = await query.Select(x => new CategoryGetDto { Name = x.Name, CreatedDate = x.CreatedDate, UpdatedDate = x.UpdatedDate, id = x.id }).ToListAsync();
        return result;
    }


    public async Task<CategoryGetDto> GetByIdAsync(int id)
    {
        Category category = await _unitOfWork.CategoryReadRepository.GetAsync(false, x => x.id == id);

        if (category == null)
            throw new ItemNotFoundExeption("Item not found");

        CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);
        return categoryGetDto;
    }

    public async Task UpdateAsync(int id, CategoryPostDto postDto)
    {
        Category category = await _unitOfWork.CategoryReadRepository.GetAsync(true, x => x.id == id);

        if (category == null)
            throw new ItemNotFoundExeption("Item not found");

        if (null != await _unitOfWork.CategoryReadRepository.GetAsync(false, x =>x.id!=id&& x.Name.ToLower() == postDto.Name.ToLower()))
        {
            throw new ItemExsistExeption($"{postDto.Name} alrady exsist");

        }

        category.Name = postDto.Name;
        _unitOfWork.CategoryWriteRepository.Update(category);
        await _unitOfWork.CategoryWriteRepository.CommitAsunc();

    }

}
