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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidation))]
        [CacheRemoveAspect("IServiceRepository.ColorManager.GetAll")]
        [PerformanceAspect(3)]
        [SecuredOperation("color.add,admin")]
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);  
            return new SuccessResult(ColorMessages.ColorAddSuccessMessage);  
        }

        [CacheRemoveAspect("IServiceRepository.ColorManager.GetAll")]
        [PerformanceAspect(3)]
        [SecuredOperation("color.delete,admin")]
        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(ColorMessages.ColorDeleteSuccessMessage);
        }

        [CacheAspect]
        [PerformanceAspect(3)]  
        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();    
            if(result.Count != 0)
            {
                return new SuccessDataResult<List<Color>>(result);
            }
            return new ErrorDataResult<List<Color>>(null);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<Color> GetById(int id)
        {
            var result = _colorDal.Get(c => c.ColorId == id);
            if (result != null)
            {
                return new SuccessDataResult<Color>(result);    
            }
            return new ErrorDataResult<Color>(null);        
        }

        [ValidationAspect(typeof(ColorValidation))]
        [CacheRemoveAspect("IServiceRepository.ColorManager.GetAll")]
        [PerformanceAspect(3)]
        [SecuredOperation("color.update,admin")]
        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(ColorMessages.ColorUpdateSuccessMessage);
        }
    }
}
