
using FluentValidation;

public class ProductPostDto
{
    public string Name { get; set; }
    public string State { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

}

public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
{
    public ProductPostDtoValidator()
    {
        RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("The field category is required");
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("The field Name is required").MaximumLength(50);
        RuleFor(x => x.State).NotNull().NotEmpty().WithMessage("The field State is required").MaximumLength(100);
        RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("The field Price is required").GreaterThanOrEqualTo(0);
    }
}

