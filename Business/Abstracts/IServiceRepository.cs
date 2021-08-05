using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Abstracts;
using Core.Utilities.Results.Abstracts;

namespace Business.Abstracts
{
    public interface IServiceRepository<T>
        where T : class, IEntity, new()
    {
        IResult Add(T entity);

        IResult Update(T entity);

        IResult Delete(T entity);

        IDataResult<T> GetById(Expression<Func<T, bool>> filter);

        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
    }
}