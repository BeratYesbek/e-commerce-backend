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
using System.Collections.Generic;

namespace Business.Concretes
{
    public class BrandManager : IBrandService
    {

        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidation))]
        [CacheRemoveAspect("IServiceRepository.BrandManager.GetAll")]
        [PerformanceAspect(3)]
        [SecuredOperation("brand.add,admin")]
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(BrandMessage.BrandAddSuccessMessage);
        }

        [CacheRemoveAspect("IServiceRepository.BrandManager.GetAll")]
        [PerformanceAspect(3)]
        [SecuredOperation("brand.delete,admin")]
        public IResult Delete(Brand entity)
        {
           _brandDal.Delete(entity);
            return new SuccessResult(BrandMessage.BrandDeleteSuccessMessage); 
        }

        [CacheAspect]
        [PerformanceAspect(3)]  
        public IDataResult<List<Brand>> GetAll()
        {
            var data = _brandDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Brand>>(data);    
            }
            return new ErrorDataResult<List<Brand>>(null);
        }

        [CacheAspect]
        [PerformanceAspect(3)]  
        public IDataResult<Brand> GetById(int id)
        {
            var data = _brandDal.Get(b => b.BrandId == id);
            if (data != null)
            {
                return new SuccessDataResult<Brand>(data); 
            }
            return new ErrorDataResult<Brand>(null);  
        }

        [ValidationAspect(typeof(BrandValidation))]
        [CacheRemoveAspect("IServiceRepository.BrandManager.GetAll")]
        [PerformanceAspect(3)]
        [SecuredOperation("brand.update,admin")]
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);       
            return new SuccessResult(BrandMessage.BrandUpdateSuccessMessage);   
        }

    }
}
