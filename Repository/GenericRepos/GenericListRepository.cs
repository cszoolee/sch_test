using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepos
{
    abstract public class GenericListRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected List<TEntity> list;
        public abstract TEntity GetById(int id);

        public GenericListRepository(params TEntity[] entities)
        {
            list = new List<TEntity>();
            list.AddRange(entities);
        }
        public void Insert(TEntity newentity)
        {
            list.Add(newentity);
        }
        public void Delete(int id)
        {
            TEntity entityToDelete = GetById(id);
            if (entityToDelete == null) throw new ArgumentException("NO DATA");
            Delete(entityToDelete);
        }
        public void Delete(TEntity entityToDelete)
        {
            list.Remove(entityToDelete);
        }
        public IQueryable<TEntity> GetAll()
        {
            return list.AsQueryable();
        }
        public IQueryable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return list.Where(filter.Compile()).AsQueryable();
        }
        public void Dispose()
        {
            list.Clear();
            list = null;
        }
    }
}
