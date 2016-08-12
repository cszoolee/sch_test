using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepos
{
    abstract public class GenericSQLRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected SqlDriver driver;
        protected string tableName;
        protected string idName;

        public abstract void Insert(TEntity newentity);
        public abstract int GetIdValue(TEntity input);
        public abstract TEntity RowToEntity(Dictionary<string, object> row);

        public GenericSQLRepository(string connStr, string newtable, string newid)
        {
            driver = new SqlDriver(connStr);
            tableName = newtable;
            idName = newid;
        }

        public void Delete(int id)
        {
            string sql = String.Format("delete from {0} where {1} = @idVal", tableName, idName);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("idVal", id.ToString());

            driver.ExecOther(sql, dict);
        }

        public void Delete(TEntity entityToDelete)
        {
            Delete(GetIdValue(entityToDelete));
        }
        public TEntity GetById(int id)
        {
            string sql = String.Format("select * from {0} where {1} = @idVal", tableName, idName);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("idVal", id.ToString());

            var result = driver.ExecSelect(sql, dict).SingleOrDefault();
            return result == null ? null : RowToEntity(result);
        }
        public IQueryable<TEntity> GetAll()
        {
            string sql = String.Format("select * from {0}", tableName);
            return driver.ExecSelect(sql).Select(x => RowToEntity(x)).AsQueryable();
        }
        public IQueryable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return GetAll().Where(filter);
        }
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
