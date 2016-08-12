using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepos
{
    abstract public class GenericEFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext context;

        public abstract TEntity GetById(int id);

        public GenericEFRepository(DbContext newctx)
        {
            context = newctx;
        }

        public virtual void Insert(TEntity newentity)
        {
            context.Set<TEntity>().Add(newentity); 
            context.Entry<TEntity>(newentity).State = System.Data.EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entityToDelete)
        {
            context.Set<TEntity>().Remove(entityToDelete);
            context.Entry<TEntity>(entityToDelete).State = System.Data.EntityState.Deleted;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            TEntity entityToDelete = GetById(id);
            if (entityToDelete == null) throw new ArgumentException("NO DATA");
            Delete(entityToDelete);
        }
        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }
        public IQueryable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return GetAll().Where(filter);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
