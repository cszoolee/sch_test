using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.GenericRepos;
using Entities;
using System.Data.Entity;
using System.Data;

namespace Repository.DeptRepos
{
    public class DeptEFRepository : GenericEFRepository<DEPT>, IDeptRepository
    {
        public DeptEFRepository(DbContext newctx) : base(newctx)
        {
        }

        public void Modify(int id, string newname, int newloc)
        {
            DEPT akt = GetById(id);
            if (akt == null) throw new ArgumentException("NO DATA");
            if (newname != null) akt.DNAME = newname;
            if (newloc != 0) akt.LOC = newloc;
            context.Entry<DEPT>(akt).State = EntityState.Modified;
            context.SaveChanges(); //BUG: invalid loc & concurrencyException
        }

        public override DEPT GetById(int id)
        {
            return Get(akt => akt.DEPTNO == id).SingleOrDefault();
        }
    }
}
