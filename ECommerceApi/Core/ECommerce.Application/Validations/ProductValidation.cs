using ECommerce.Application.Features.Products.Commands;
using FluentValidation;

namespace ECommerce.Application.Validations
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.BrandId)
                .GreaterThan(0);
            RuleFor(x => x.Price)
                .GreaterThan(0);
            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any());
        }
    }

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.BrandId)
                .GreaterThan(0);
            RuleFor(x => x.Price)
                .GreaterThan(0);
            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any());
        }
    }

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
