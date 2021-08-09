using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concretes;
using Core.Utilities.Results.Abstracts;

namespace Business.Abstracts
{
    public interface IUserService : IServiceRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByEmail(string email);
    }
}
