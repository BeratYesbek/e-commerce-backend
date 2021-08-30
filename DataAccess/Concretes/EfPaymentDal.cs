using Core.DataAccess.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concretes
{
    public class EfPaymentDal : EntityRepositoryBase<Payment,DatabaseContext>, IPaymentDal
    {
    }
}
