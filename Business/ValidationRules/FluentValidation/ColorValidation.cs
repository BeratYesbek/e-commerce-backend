using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidation : AbstractValidator<Color>
    {
        public ColorValidation()
        {
            RuleFor(c => c.ColorCode).NotEmpty().WithMessage("Color code cannot be blank");
            RuleFor(c => c.ColorName).NotEmpty().WithMessage("Color name cannot be blank");
        }
    }
}
