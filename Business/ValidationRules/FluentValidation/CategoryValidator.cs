using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entity.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().NotNull().MinimumLength(2);
        }
    }
}
