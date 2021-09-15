using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CartSummaryValidation : AbstractValidator<CartSummary>
    {
        public CartSummaryValidation()
        {
            RuleFor(c => c.ProductId).NotNull().NotEqual(0).WithMessage("Product Id cannot be null");
            RuleFor(c => c.UserId).NotNull().NotEqual(0).WithMessage("User Id cannot be null");
        }
    }
}
