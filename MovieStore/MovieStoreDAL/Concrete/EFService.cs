using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MovieStoreDAL.Abstarct;

namespace MovieStoreDAL.Concrete
{
    public class EFService<TContext, TEntity> : IEFService<TEntity>
        where TContext:DbContext where TEntity:class
    {
        internal TContext Context;
        internal DbSet<TEntity> DbSet;

        public EFService(TContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "")
        {
            return Get(null,orderBy,includeProperties);
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter!=null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split( new [] {','},StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy!=null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.Distinct().ToList();
            }
        }
        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }
        public TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            return Get(filter, null, includeProperties).SingleOrDefault();
        }
        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return Get(filter,orderBy,includeProperties).FirstOrDefault();
        }

        public TEntity GetLast(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return Get(filter,orderBy,includeProperties).LastOrDefault();
        }

        public TEntity Create(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public TEntity Delete(int id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            return DbSet.Remove(entity);
        }
        public TEntity Update(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return Get(filter).Count();
        }
     
        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            return Count(filter) > 0;
        }
    }
}
