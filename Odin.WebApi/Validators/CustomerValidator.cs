using FluentValidation;
using Odin.Models;

namespace Odin.WebApi.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.TCIdentityNumber)
                .Length(11)
                .WithMessage("T.C. Kimlik Numarası 11 hanelidir. Lütfen tekrar kontrol ediniz.");

            RuleFor(customer => customer.Phone)
                .Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{5}")
                .WithMessage("Telefon numaranızın başında sıfır olmalı ve toplam 11 haneden oluşmalıdır.");

            RuleFor(customer => customer.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Ad alanı boş olmamalıdır.");

            RuleFor(customer => customer.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Soyad alanı boş olmamalıdır.");
        }
    }
}
