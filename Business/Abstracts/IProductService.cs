using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concretes;

namespace Business.Abstracts
{
    public interface IProductService :  IServiceRepository<Product>
    {
    }
}
