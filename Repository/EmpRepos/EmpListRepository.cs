using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;
using Repository.GenericRepos;

namespace Repository.EmpRepos
{
    public class EmpListRepository : GenericListRepository<EMP>, IEmpRepository
    {
        public EmpListRepository()
        {
            Insert(new EMP()
            {
                EMPNO = 7839,
                ENAME = "KINGX",
                JOB = "PRESIDENT",
                MGR = null,
                HIREDATE = new DateTime(1981, 11, 17),
                SAL = 5000,
                COMM = null,
                DEPTNO = 10
            });

            Insert(new EMP()
            {
                EMPNO = 7698,
                ENAME = "BLAKEX",
                JOB = "MANAGER",
                MGR = 7839,
                HIREDATE = new DateTime(1981, 5, 1),
                SAL = 2850,
                COMM = null,
                DEPTNO = 30
            });
            Insert(new EMP()
            {
                EMPNO = 7782,
                ENAME = "CLARKX",
                JOB = "MANAGER",
                MGR = 7839,
                HIREDATE = new DateTime(1981, 6, 9),
                SAL = 2450,
                COMM = null,
                DEPTNO = 10
            });
            Insert(new EMP()
            {
                EMPNO = 7566,
                ENAME = "JONESX",
                JOB = "MANAGER",
                MGR = 7839,
                HIREDATE = new DateTime(1981, 4, 2),
                SAL = 2975,
                COMM = null,
                DEPTNO = 20
            });

            Insert(new EMP()
            {
                EMPNO = 7654,
                ENAME = "MARTINX",
                JOB = "SALESMAN",
                MGR = 7698,
                HIREDATE = new DateTime(1981, 9, 28),
                SAL = 1250,
                COMM = 1400,
                DEPTNO = 30
            });
            Insert(new EMP()
            {
                EMPNO = 7499,
                ENAME = "ALLENX",
                JOB = "SALESMAN",
                MGR = 7698,
                HIREDATE = new DateTime(1981, 2, 20),
                SAL = 1600,
                COMM = 300,
                DEPTNO = 30
            });
            Insert(new EMP()
            {
                EMPNO = 7844,
                ENAME = "TURNERX",
                JOB = "SALESMAN",
                MGR = 7698,
                HIREDATE = new DateTime(1981, 9, 8),
                SAL = 1500,
                COMM = 0,
                DEPTNO = 30
            });
            Insert(new EMP()
            {
                EMPNO = 7521,
                ENAME = "WARDX",
                JOB = "SALESMAN",
                MGR = 7698,
                HIREDATE = new DateTime(1981, 2, 22),
                SAL = 1250,
                COMM = 500,
                DEPTNO = 30
            });
            Insert(new EMP()
            {
                EMPNO = 7900,
                ENAME = "JAMESX",
                JOB = "CLERK",
                MGR = 7698,
                HIREDATE = new DateTime(1981, 12, 3),
                SAL = 950,
                COMM = null,
                DEPTNO = 30
            });
            Insert(new EMP()
            {
                EMPNO = 7902,
                ENAME = "FORDX",
                JOB = "ANALYST",
                MGR = 7566,
                HIREDATE = new DateTime(1981, 12, 3),
                SAL = 3000,
                COMM = null,
                DEPTNO = 20
            });
            Insert(new EMP()
            {
                EMPNO = 7369,
                ENAME = "SMITHX",
                JOB = "CLERK",
                MGR = 7902,
                HIREDATE = new DateTime(1980, 12, 17),
                SAL = 800,
                COMM = null,
                DEPTNO = 20
            });
            Insert(new EMP()
            {
                EMPNO = 7788,
                ENAME = "SCOTTX",
                JOB = "ANALYST",
                MGR = 7566,
                HIREDATE = new DateTime(1982, 12, 9),
                SAL = 3000,
                COMM = null,
                DEPTNO = 20
            });
            Insert(new EMP()
            {
                EMPNO = 7876,
                ENAME = "ADAMSX",
                JOB = "CLERK",
                MGR = 7788,
                HIREDATE = new DateTime(1983, 1, 12),
                SAL = 1100,
                COMM = null,
                DEPTNO = 20
            });
            Insert(new EMP()
            {
                EMPNO = 7934,
                ENAME = "MILLERX",
                JOB = "CLERK",
                MGR = 7782,
                HIREDATE = new DateTime(1982, 1, 23),
                SAL = 1300,
                COMM = null,
                DEPTNO = 10
            });
        }

        public override EMP GetById(int id)
        {
            return Get(akt => akt.EMPNO == id).SingleOrDefault();
        }

        public IQueryable<GetAveragesResult> GetAverages()
        {
            List<GetAveragesResult> result = new List<GetAveragesResult>();
            result.Add(new GetAveragesResult() { ID = 10, AVG = 2916.666666M });
            result.Add(new GetAveragesResult() { ID = 20, AVG = 2175 });
            result.Add(new GetAveragesResult() { ID = 30, AVG = 1566.666666M });
            return result.AsQueryable();
        }
    }
}
