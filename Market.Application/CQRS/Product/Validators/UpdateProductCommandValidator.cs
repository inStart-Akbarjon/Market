using FluentValidation;
using Market.Application.CQRS.Product.Commands.UpdateProduct;

namespace Market.Application.CQRS.Product.Validators;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}