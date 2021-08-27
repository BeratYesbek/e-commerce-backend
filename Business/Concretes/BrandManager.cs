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
    public class BrandManager : IBrandService
    {

        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(BrandMessage.BrandAddSuccessMessage);
        }

        public IResult Delete(Brand entity)
        {
           _brandDal.Delete(entity);
            return new SuccessResult(BrandMessage.BrandDeleteSuccessMessage); 
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var data = _brandDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Brand>>(data);    
            }
            return new ErrorDataResult<List<Brand>>(null);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var data = _brandDal.Get(b => b.BrandId == id);
            if (data != null)
            {
                return new SuccessDataResult<Brand>(data); 
            }
            return new ErrorDataResult<Brand>(null);  
        }

        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);       
            return new SuccessResult(BrandMessage.BrandUpdateSuccessMessage);   
        }

    }
}
