using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstracts;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Messages;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            return new SuccessResult(ProductMessages.ProductAddSuccessMessage);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(ProductMessages.ProductUpdateSuccessMessage);
        }

        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(ProductMessages.ProductDeleteSuccessMessage);
        }

        public IDataResult<Product> GetById(Expression<Func<Product, bool>> filter)
        {
            var result = _productDal.GetById(filter);
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result);
        }
    }
}