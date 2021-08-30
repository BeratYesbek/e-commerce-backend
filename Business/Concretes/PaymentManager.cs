using Business.Abstracts;
using Business.Messages;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        private readonly ICartSummaryService _cartSummaryService;
        public PaymentManager(IPaymentDal paymentDal,ICartSummaryService cartSummaryService)
        {
            _paymentDal = paymentDal;   
            _cartSummaryService = cartSummaryService;   
        }
        public IResult Add(Payment entity)
        {
            _paymentDal.Add(entity);
            CartSummary cartSummary = new CartSummary();
            cartSummary.ProductId = entity.ProductId;
            cartSummary.UserId = entity.UserId;
            cartSummary.Id = entity.CartSummaryId;
            _cartSummaryService.Delete(cartSummary);
            return new SuccessResult(PaymentMessages.PaymentAddSuccessMessage);
        }

        public IResult Delete(Payment entity)
        {
           _paymentDal.Delete(entity);
            return new SuccessResult(PaymentMessages.PaymentDeleteSuccessMessage);  
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var data = _paymentDal.GetAll();
            if(data.Count > 0)
            {
                return new SuccessDataResult<List<Payment>>(data);  
            }
            return new ErrorDataResult<List<Payment>>(null);
        }

        public IDataResult<Payment> GetById(int id)
        {
            var data = _paymentDal.Get(p => p.PaymentId == id);
            if(data != null)
            {
                return new SuccessDataResult<Payment>(data);    
            }
            return new ErrorDataResult<Payment>(null);  
        }

        public IResult Update(Payment entity)
        {
           _paymentDal.Update(entity);  
            return new SuccessResult(PaymentMessages.PaymentUpdateSuccessMessage);
        }
    }
}
