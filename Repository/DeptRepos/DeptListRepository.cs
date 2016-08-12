using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.GenericRepos;
using Entities;

namespace Repository.DeptRepos
{
    public class DeptListRepository : GenericListRepository<DEPT>, IDeptRepository
    { // http://szabozs.obudanik.hu/_SCH/DB/
        public DeptListRepository() : base(
            new DEPT() { DEPTNO = 10, DNAME = "ACCOUNTINGX", LOC = 1 },
            new DEPT() { DEPTNO = 20, DNAME = "RESEARCHX", LOC = 2 },
            new DEPT() { DEPTNO = 30, DNAME = "SALESX", LOC = 3 },
            new DEPT() { DEPTNO = 40, DNAME = "OPERATIONSX", LOC = 4 }
            )
        {
        }

        public override DEPT GetById(int id)
        {
            return Get(akt => akt.DEPTNO == id).SingleOrDefault();
        }

        public void Modify(int id, string newname, int newloc)
        {
            DEPT akt = GetById(id);
            if (akt == null) throw new ArgumentException("NO DATA");
            if (newname != null) akt.DNAME = newname;
            if (newloc != 0) akt.LOC = newloc;
        }
    }
}
