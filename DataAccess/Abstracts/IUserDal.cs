using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Abstracts;
using Core.Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
