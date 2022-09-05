
using FluentValidation;

public record ProductStockPostDto
{
    public int ProductId { get; set; }
    public int ProductCout { get; set; }    
}

public class ProductPostDtoValidator : AbstractValidator<ProductStockPostDto>
{
    public ProductPostDtoValidator()
    {
        RuleFor(x=>x.ProductId).NotEmpty().NotNull();
        RuleFor(x=>x.ProductCout).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
    }
}

