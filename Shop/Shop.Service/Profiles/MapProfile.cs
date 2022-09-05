
using AutoMapper;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<ProductPostDto, Product>();
        CreateMap<Product, ProductGetDto>();
        CreateMap<Category, CategoryGetDto>();
        CreateMap<CategoryPostDto, Category>();
        CreateMap<Category, CategoryInProductGetDto>();
    }
}

