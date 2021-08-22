using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Abstracts;
using Entity.Concretes;

namespace DataAccess.Abstracts
{
    public interface IProductImageDal : IEntityRepository<ProductImage>
    {
    }
}
