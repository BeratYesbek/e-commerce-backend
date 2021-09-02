using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dtos;

namespace Business.Abstracts
{
    public interface IProductService :  IServiceRepository<Product>
    {

        IDataResult<List<ProductDto>> GetAllProductDetail();
        IDataResult<ProductDto> GetProductDetailById(int id);
        IDataResult<List<ProductDto>> GetProductDetailByCategoryId(int categoryId);
    }
}
    