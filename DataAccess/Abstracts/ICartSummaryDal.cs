using Core.DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstracts
{
    public interface ICartSummaryDal : IEntityRepository<CartSummary>
    {
        List<CartSummaryDto> GetCartSummaryDetailByUserId(Expression<Func<CartSummary, bool>> filter);
    }
}
