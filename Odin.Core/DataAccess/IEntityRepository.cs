using Odin.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Odin.Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate = null);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
