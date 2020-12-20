using FluentValidation;
using Odin.Models;

namespace Odin.WebApi.Validators
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("Ürün adı boş olamaz.");

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty().WithMessage("Ürün fiyatı olamaz.");
        }
    }
}
