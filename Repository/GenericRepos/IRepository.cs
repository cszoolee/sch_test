using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepos
{
    public interface IRepository<TEntity> : IDisposable where TEntity:class
    {
        void Insert(TEntity newentity);
        void Delete(int id);
        void Delete(TEntity entityToDelete);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        /*
         * List<int> szamok=xxxx
         * szamok.Where(x=>x%2==2).Where(x=>x%3==0).OrderBy(x=>x).Reverse();

         * var result = DBCONTEXT.TABLA.Where(x=>x.id%2==2).Where(x=>x.id%3==0).OrderBy(x=>x.id).Reverse();
         * foreach (var akt in result){
         * }
         */
    }
}
