
using System.Reflection;

public static class ServiceRegisteration
{
    public static void RegisterService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfwork, UnitOfWork>();
        services.AddScoped<IProductStockService, ProductStockService>();
    }
}

