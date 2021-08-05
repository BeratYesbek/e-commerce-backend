using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Abstracts;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;

namespace Core.DataAccess.Abstracts
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(Expression<Func<T, bool>> filter);

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}