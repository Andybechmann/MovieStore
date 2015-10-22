using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieStoreDAL.Abstarct;

namespace MovieStoreDAL.Concrete
{
    public class Service<TContext, TEntity> : IService<TContext, TEntity>
        where TContext:DbContext where TEntity:class
    {
        internal TContext context;
        internal DbSet<TEntity> dbSet;

        public Service(TContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
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
            IQueryable<TEntity> query = dbSet;
            if (filter!=null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split( new char[] {','},StringSplitOptions.RemoveEmptyEntries))
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
        public TEntity GetById(int id, string includeProperties = "")
        {
            return dbSet.Find(id);
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

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            context.Entry(entity).State = EntityState.Modified;
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
