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
using Entity.Concretes.Dtos;

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
        [SecuredOperation("product.add,admin")]
        [PerformanceAspect(3)]
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            var data = _productDal.Get(p => p.ProductDescription == entity.ProductDescription);
            return new SuccessResult($"{ProductMessages.ProductAddSuccessMessage},{data.ProductId}");
        }

        [CacheRemoveAspect("IServiceRepository.ProductManager.GetById")]
        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("product.update,admin")]
        [PerformanceAspect(3)]
        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(ProductMessages.ProductUpdateSuccessMessage);
        }


        [SecuredOperation("product.delete,admin")]
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

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<ProductDto>> GetAllProductDetail()
        {
            var result = _productDal.GetAllProductDetail();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ProductDto>>(result);

            }
            return new ErrorDataResult<List<ProductDto>>(result);   
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<ProductDto> GetProductDetailById(int id)
        {
            var result = _productDal.GetProductDetailById(p => p.ProductId == id);
            if (result != null)
            {
                return new SuccessDataResult<ProductDto>(result);
            }
            return new ErrorDataResult<ProductDto>(null);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<ProductDto>> GetProductDetailByCategoryId(int categoryId)
        {
            var result = _productDal.GetAllProductDetail(c => c.CategoryId == categoryId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ProductDto>>(result);
            }
            return new ErrorDataResult<List<ProductDto>>(result);       
        }
    }
}