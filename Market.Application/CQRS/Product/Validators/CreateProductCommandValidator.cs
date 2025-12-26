using FluentValidation;
using Market.Application.CQRS.Product.Commands.CreateProduct;

namespace Market.Application.CQRS.Product.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage($"Title field must have value");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage($"Price field must have value")
            .GreaterThan(0)
            .WithMessage($"Price field should be greater than 0");

        RuleFor(p => p.Quantity)
            .NotEmpty()
            .WithMessage($"Quantity field must have value")
            .GreaterThan(0)
            .WithMessage($"Quantity field should be greater than 0");
    }
}