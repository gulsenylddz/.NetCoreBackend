using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); //birim fiyat 0dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId==2);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A Harfi ile Başlamalı.");
           
        }

        private bool StartWithA(string arg) //arg-->productName
        {
            return arg.StartsWith("A");
        }
    }
}
