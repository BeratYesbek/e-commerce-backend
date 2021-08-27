using Core.DataAccess.Abstracts;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstracts
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
    }
}
