using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.GenericRepos;
using Entities;

namespace Repository.EmpRepos
{
    public interface IEmpRepository : IRepository<EMP>
    {
        IQueryable<GetAveragesResult> GetAverages();
    }
}
