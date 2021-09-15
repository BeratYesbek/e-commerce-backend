using Business.Abstracts;
using Business.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class CartSummaryManager : ICartSummaryService
    {
        private readonly ICartSummaryDal _cartSummaryDal;
        public CartSummaryManager(ICartSummaryDal cartSummaryDal)
        {
            _cartSummaryDal = cartSummaryDal;
        }

        [ValidationAspect(typeof(CartSummaryValidation))]
        [CacheRemoveAspect("IServiceRepository.CartSummaryManager.GetAll")]
        [PerformanceAspect(3)]
        public IResult Add(CartSummary entity)
        {
            _cartSummaryDal.Add(entity);
            return new SuccessResult(CartSummaryMessages.CartSummaryAddSuccessMessage);
        }

        [CacheRemoveAspect("IServiceRepository.CartSummaryManager.GetAll")]
        [PerformanceAspect(3)]
        public IResult Delete(CartSummary entity)
        {
            _cartSummaryDal.Delete(entity);
            return new SuccessResult(CartSummaryMessages.CartSummaryDeleteSuccessMessage);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<CartSummary>> GetAll()
        {
            var result = _cartSummaryDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CartSummary>>(result);
            }
            return new ErrorDataResult<List<CartSummary>>(null);
        }
        [CacheAspect]
        [PerformanceAspect(3)]  
        public IDataResult<CartSummary> GetById(int id)
        {
            var result = _cartSummaryDal.Get(c => c.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<CartSummary>(result);
            }

            return new ErrorDataResult<CartSummary>(null);
        }

        [ValidationAspect(typeof(CartSummaryValidation))]
        [CacheRemoveAspect("IServiceRepository.CartSummaryManager.GetAll")]
        [PerformanceAspect(3)]
        public IResult Update(CartSummary entity)
        {
            _cartSummaryDal.Update(entity);
            return new SuccessResult(CartSummaryMessages.CartSummaryUpdateSuccessMessage);
        }

        [PerformanceAspect(3)]
        public IDataResult<List<CartSummaryDto>> GetCartSummaryDetailByUserId(int userId)
        {
            var result = _cartSummaryDal.GetCartSummaryDetailByUserId(c => c.UserId == userId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CartSummaryDto>>(result);
            }

            return new ErrorDataResult<List<CartSummaryDto>>(null);
        }

        [PerformanceAspect(3)]
        public IDataResult<List<CartSummary>> GetAllByUserId(int userId)
        {
            var result = _cartSummaryDal.GetAll(c => c.UserId == userId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CartSummary>>(result);
            }
            return new ErrorDataResult<List<CartSummary>>(null);

        }
    }
}
