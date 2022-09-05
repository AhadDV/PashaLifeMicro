
using FluentValidation;

public class CategoryPostDto
{
    public string Name { get; set; }
}

public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
{
    public CategoryPostDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("The field name is required").MaximumLength(50);
    }
}

