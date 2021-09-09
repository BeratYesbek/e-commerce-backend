using Core.Utilities.Results.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface ICartSummaryService : IServiceRepository<CartSummary>
    {
        IDataResult<List<CartSummaryDto>> GetCartSummaryDetailByUserId(int userId);

        IDataResult<List<CartSummary>> GetAllByUserId(int userId);  
    }
}

