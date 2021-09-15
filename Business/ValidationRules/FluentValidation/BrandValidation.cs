using Core.Aspects.Autofac.Validation;
using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidation  : AbstractValidator<Brand>
    {
        public BrandValidation()
        {
            RuleFor(b => b.BrandName).NotEmpty().MinimumLength(2).WithMessage("Brand Name cannot be blank and less than more two character");
 
        }
      
    }
}
