using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.DataAccess.Abstracts;
using Core.Utilities.Results.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dtos;

namespace DataAccess.Abstracts
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDto> GetAllProductDetail(Expression<Func<ProductDto, bool>> filter = null);
        ProductDto GetProductDetailById(Expression<Func<Product,bool>> filter);

    }
}
