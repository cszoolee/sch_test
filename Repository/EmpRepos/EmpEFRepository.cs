using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;
using Repository.GenericRepos;
using System.Data.Entity;

namespace Repository.EmpRepos
{
    public class EmpEFRepository : GenericEFRepository<EMP>, IEmpRepository
    {
        public EmpEFRepository(DbContext newctx) : base (newctx)
        {
        }

        public override EMP GetById(int id)
        {
            return Get(akt => akt.EMPNO == id).SingleOrDefault();
        }
        public IQueryable<GetAveragesResult> GetAverages()
        {
            var q = from akt in GetAll()
                    group akt by akt.DEPTNO into g
                    select new GetAveragesResult()
                    {
                        ID=g.Key, AVG=g.Average(x=>x.SAL)
                    };
            return q;
        }
    }
}
