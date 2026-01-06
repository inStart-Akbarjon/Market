using FluentValidation;
using Market.Application.CQRS.Product.Commands.CreateProduct;

namespace Market.Application.CQRS.Product.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage($"Property Title must have value");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage($"Property Price should not be null or 0")
            .GreaterThan(0)
            .WithMessage($"Property Price should not be negative");

        RuleFor(p => p.Quantity)
            .NotEmpty()
            .WithMessage($"Property Quantity should not be null or 0")
            .GreaterThan(0)
            .WithMessage($"Property Quantity should not be negative");
    }
}