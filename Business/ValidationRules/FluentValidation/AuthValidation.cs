using Entity.Concretes.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidation : AbstractValidator<UserForRegisterDto>
    {
        public AuthValidation()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be blank");
            RuleFor(p => p.FirstName).NotEmpty().MinimumLength(2).WithMessage("First Name cannot be blank and less than more 2 character");
            RuleFor(p => p.LastName).NotEmpty().MinimumLength(2).WithMessage("Last Name cannot be blank and less than more 2 character");
            RuleFor(p => p.Password).NotEmpty().MinimumLength(6).WithMessage("Password cannot be blank and less than more 6 character");

        }
    }
}
