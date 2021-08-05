using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;

namespace DataAccess.Concretes
{ 
    public class EfProductDal : EntityRepositoryBase<Product,DatabaseContext>, IProductDal
    {
    }
}
