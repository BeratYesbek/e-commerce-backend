using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidation : AbstractValidator<Payment>
    {
        public PaymentValidation()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be blank");
            RuleFor(p => p.Address).NotEmpty().WithMessage("Address cannot be blank");
            RuleFor(p => p.CardHolderName).NotEmpty().WithMessage("CardHolderName cannot be blank");
            RuleFor(p => p.CardNumber).NotEmpty().WithMessage("CardNumber cannot be blank");
            RuleFor(p => p.Cvv).NotEmpty().WithMessage("Cvv cannot be blank");
            RuleFor(p => p.CartSummaryId).NotEmpty().WithMessage("CartSummaryId cannot be blank");
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("ProductId cannot be blank");
            RuleFor(p => p.date).NotEmpty().WithMessage("date cannot be blank");
            RuleFor(p => p.ExpiryDate).NotEmpty().WithMessage("ExpiryDate cannot be blank");
            RuleFor(p => p.UserId).NotEmpty().WithMessage("UserId cannot be blank");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("PhoneNumber cannot be blank");
            RuleFor(p => p.TotalPrice).NotEmpty().WithMessage("TotalPrice cannot be blank");


        }
    }
}
