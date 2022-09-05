using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Shop.Service.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
     .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<ProductPostDtoValidator>())
     .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ShopStockDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Stock.Api"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
