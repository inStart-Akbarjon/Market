using FluentValidation;
using Market.Application.CQRS.Product.Commands.UpdateProduct;

namespace Market.Application.CQRS.Product.Validators;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage($"Property Title must have value");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage($"Property Price must have value")
            .GreaterThan(0)
            .WithMessage($"Property Price should not be negative");

        RuleFor(p => p.Quantity)
            .NotEmpty()
            .WithMessage($"Property Quantity must have value")
            .GreaterThan(0)
            .WithMessage($"Property Quantity should not be negative");
    }
}