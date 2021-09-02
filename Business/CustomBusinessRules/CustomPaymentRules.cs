using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CustomBusinessRules
{
    public class CustomPaymentRules
    {
        public static IResult  SendPurchaseMail(Payment payment)
        {
            BusinessMailer.PurchaseMailer.SendPurchaseMail(payment);
            return new SuccessResult();
        }
    }
}
