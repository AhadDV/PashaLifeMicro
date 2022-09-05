
using FluentValidation;
using FluentValidation.AspNetCore;
using Shop.Service.Abstractions.Services.Category;
using Shop.Service.Filters;
using System.Reflection;

public static class ServiceRegisteration
{
    public static void RegisterService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddAutoMapper(opt =>
        {
            opt.AddProfile(new MapProfile());
        });



    }
}

