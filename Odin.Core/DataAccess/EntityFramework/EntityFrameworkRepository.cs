using Microsoft.EntityFrameworkCore;
using Odin.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Odin.Core.DataAccess.EntityFramework
{
    public class EntityFrameworkRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using TContext context = new TContext();

            var addedEntry = context.Entry(entity);
            addedEntry.State = EntityState.Added;

            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new TContext();

            var deletedEntry = context.Entry(entity);

            deletedEntry.State = EntityState.Deleted;

            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            using TContext context = new TContext();

            return context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null)
        {
            using TContext context = new TContext();

            return predicate == null ? context.Set<TEntity>().ToList()
                                     : context.Set<TEntity>().Where(predicate).ToList();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new TContext();

            var updatedEntry = context.Entry(entity);
            updatedEntry.State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
