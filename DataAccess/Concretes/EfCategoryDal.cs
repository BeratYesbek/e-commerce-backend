using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;

namespace DataAccess.Concretes
{
    public class EfCategoryDal : EntityRepositoryBase<Category, DatabaseContext>, ICategoryDal
    {
    }
}