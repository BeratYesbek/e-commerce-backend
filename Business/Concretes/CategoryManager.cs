using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("IServiceRepository.GetById.CategoryManager")]
        [PerformanceAspect(3)]
        [SecuredOperation("Category.Add,admin")]
        public IResult Add(Category entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult(CategoryMessages.CategoryAddSuccessMessage);
        }

        [CacheRemoveAspect("IServiceRepository.GetById.CategoryManager")]
        [PerformanceAspect(3)]
        [ValidationAspect(typeof(CategoryValidator))]
        [SecuredOperation("Category.Add,admin")]
        public IResult Update(Category entity)
        {
            _categoryDal.Update(entity);
            return new SuccessResult(CategoryMessages.CategoryUpdateSuccessMessage);
        }
        [CacheRemoveAspect("IServiceRepository.GetById.CategoryManager")]
        [PerformanceAspect(3)]
        [SecuredOperation("Category.Add,admin")]
        public IResult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult(CategoryMessages.CategoryDeleteSuccessMessage);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(c => c.CategoryId == id);
            return new SuccessDataResult<Category>(result);
        }
        [PerformanceAspect(3)]
        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result);
        }
    }
}