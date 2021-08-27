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
    public class CartSummaryManager : ICartSummaryService
    {
        private readonly ICartSummaryDal _cartSummaryDal;
        public CartSummaryManager(ICartSummaryDal cartSummaryDal)
        {
            _cartSummaryDal = cartSummaryDal;
        }

        public IResult Add(CartSummary entity)
        {
            _cartSummaryDal.Add(entity);
            return new SuccessResult(CartSummaryMessages.CartSummaryAddSuccessMessage);
        }

        public IResult Delete(CartSummary entity)
        {
            _cartSummaryDal.Delete(entity);
            return new SuccessResult(CartSummaryMessages.CartSummaryDeleteSuccessMessage);
        }

        public IDataResult<List<CartSummary>> GetAll()
        {
            var result = _cartSummaryDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CartSummary>>(result);
            }
            return new ErrorDataResult<List<CartSummary>>(null);
        }

        public IDataResult<CartSummary> GetById(int id)
        {
            var result = _cartSummaryDal.Get(c => c.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<CartSummary>(result);
            }

            return new ErrorDataResult<CartSummary>(null);
        }

        public IResult Update(CartSummary entity)
        {
            _cartSummaryDal.Update(entity);
            return new SuccessResult(CartSummaryMessages.CartSummaryUpdateSuccessMessage);
        }
    }
}
