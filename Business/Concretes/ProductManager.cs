using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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

        [CacheRemoveAspect("IServiceRepository.ProductManager.GetById")]
        [ValidationAspect(typeof(ProductValidator))]
        //[SecuredOperation("Product.Add,admin")]
        [PerformanceAspect(3)]
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            var data = _productDal.Get(p => p.ProductDescription == entity.ProductDescription);
            return new SuccessResult($"{ProductMessages.ProductAddSuccessMessage},{data.ProductId}");
        }

        [CacheRemoveAspect("IServiceRepository.ProductManager.GetById")]
        [ValidationAspect(typeof(ProductValidator))]
       // [SecuredOperation("Product.Add,admin")]
        [PerformanceAspect(3)]
        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(ProductMessages.ProductUpdateSuccessMessage);
        }

        [SecuredOperation("Product.Add,admin")]
        [CacheRemoveAspect("IServiceRepository.ProductManager.GetById")]
        [PerformanceAspect(3)]
        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(ProductMessages.ProductDeleteSuccessMessage);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<Product> GetById(int id)
        {
            var result = _productDal.Get(p => p.ProductId == id);
            return new SuccessDataResult<Product>(result);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result);
        }
    }
}