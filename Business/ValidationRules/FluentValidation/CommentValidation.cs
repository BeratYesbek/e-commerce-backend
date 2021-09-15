using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(c => c.ProductComment).NotEmpty().WithMessage("Product Comment  cannot be blank");
            RuleFor(c => c.ProductId).NotNull().NotEqual(0).WithMessage("Product Id cannot be null");
            RuleFor(c => c.Rating).NotEmpty().GreaterThan(0).LessThanOrEqualTo(5).WithMessage("Rating must be between 0 and 5");
        }
    }
}
