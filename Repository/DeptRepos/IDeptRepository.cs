using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.GenericRepos;
using Entities;

namespace Repository.DeptRepos
{
    public interface IDeptRepository : IRepository<DEPT>
    {
        void Modify(int id, string newname, int newloc);
    }
}
