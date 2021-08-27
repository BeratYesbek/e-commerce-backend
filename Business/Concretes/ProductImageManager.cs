using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstracts;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Concretes
{
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public IResult Add(ProductImage entity, IFormFile[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                var result = FileHelper.Upload(file[i]);
                if (result.Success)
                {
                    entity.Id = 0;
                    entity.ImagePath = result.Message;
                    _productImageDal.Add(entity);
                }
                else
                {
                    return result;
                }
  

            }

            return new SuccessResult();
        }

        public IResult Update(ProductImage[] entity, IFormFile[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                var result = FileHelper.Update(file[i],entity[i].ImagePath);
                if (result.Success)
                {
                    entity[i].ImagePath = result.Message;
                    _productImageDal.Update(entity[i]);
                }
            }
            return new SuccessResult();
        }

        public IResult Delete(ProductImage entity, IFormFile[] file)
        {
            throw new NotImplementedException();
        }

        public IDataResult<ProductImage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
