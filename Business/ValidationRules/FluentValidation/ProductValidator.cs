using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(p => p.ProductDescription).NotEmpty().NotNull().MinimumLength(1);
            RuleFor(p => p.ProductPrice).GreaterThan(0);
            RuleFor(p => p.ProductQuantity).GreaterThan(0);
            RuleFor(p => p.CategoryId).NotEmpty();
        }
    }
}