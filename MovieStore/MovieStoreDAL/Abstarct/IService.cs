using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieStoreDAL.Abstarct
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(
            Func< IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(int id, string includeProperties = "");

        TEntity GetOne(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "");

        TEntity GetFirst(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetLast(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        int Count(Expression<Func<TEntity, bool>> filter = null);
        bool Any(Expression<Func<TEntity,bool>> filter = null );
    }
}
