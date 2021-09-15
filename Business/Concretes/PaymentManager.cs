using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.CustomBusinessRules;
using Business.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [CacheRemoveAspect("IServiceRepository.PaymentManager.GetAll")]
        [ValidationAspect(typeof(PaymentValidation))]
        [PerformanceAspect(3)]
        public IResult Add(Payment entity)
        {
            _paymentDal.Add(entity);
            CartSummary cartSummary = new CartSummary();
            cartSummary.ProductId = entity.ProductId;
            cartSummary.UserId = entity.UserId;
            cartSummary.Id = entity.CartSummaryId;
            _cartSummaryService.Delete(cartSummary);


            BusinessRules.run(CustomPaymentRules.SendPurchaseMail(entity));

            return new SuccessResult(PaymentMessages.PaymentAddSuccessMessage);
        }

        [CacheRemoveAspect("IServiceRepository.PaymentManager.GetAll")]
        [PerformanceAspect(3)]
        [SecuredOperation("payment.delete,admin")]
        public IResult Delete(Payment entity)
        {
           _paymentDal.Delete(entity);
            return new SuccessResult(PaymentMessages.PaymentDeleteSuccessMessage);  
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        [SecuredOperation("payment.delete,admin")]
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

        [ValidationAspect(typeof(PaymentValidation))]
        [CacheRemoveAspect("IServiceRepository.PaymentManager.GetAll")]
        [PerformanceAspect(3)]
        [SecuredOperation("payment.update,admin")]
        public IResult Update(Payment entity)
        {
           _paymentDal.Update(entity);  
            return new SuccessResult(PaymentMessages.PaymentUpdateSuccessMessage);
        }
    }
}
