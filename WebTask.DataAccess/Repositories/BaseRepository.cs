using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebTask.DataAccess.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        internal WebTaskEntities context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(WebTaskEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetList()
        {
            IQueryable<TEntity> query = dbSet;

            return query.ToList();
        }

        public virtual TEntity GetDetails(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
            context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
