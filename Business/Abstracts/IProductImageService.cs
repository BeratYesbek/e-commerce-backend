using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstracts;
using Core.Utilities.Results.Abstracts;
using Entity.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Abstracts
{
    public interface IProductImageService
    {
        IResult Add(ProductImage entity, IFormFile[] file);

        IResult Update(ProductImage[] entity, IFormFile[] file);

        IResult Delete(ProductImage entity, IFormFile[] file);

        IDataResult<ProductImage> GetById(int id);

        IDataResult<List<ProductImage>> GetAll();
    }
}