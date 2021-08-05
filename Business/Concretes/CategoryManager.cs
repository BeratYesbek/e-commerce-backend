using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstracts;
using Business.Messages;
using Business.ValidationRules.FluentValidation;
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
        public IResult Add(Category entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult(CategoryMessages.CategoryAddSuccessMessage);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category entity)
        {
            _categoryDal.Update(entity);
            return new SuccessResult(CategoryMessages.CategoryUpdateSuccessMessage);
        }

        public IResult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult(CategoryMessages.CategoryDeleteSuccessMessage);
        }

        public IDataResult<Category> GetById(Expression<Func<Category, bool>> filter)
        {
            var result = _categoryDal.GetById(filter);
            return new SuccessDataResult<Category>(result);
        }

        public IDataResult<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var result = _categoryDal.GetAll(filter);
            return new SuccessDataResult<List<Category>>(result);
        }
    }
}