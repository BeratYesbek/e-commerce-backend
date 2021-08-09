using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstracts;

namespace Core.Entities.Concretes
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OperationClaimId { get; set; }
    }
}
