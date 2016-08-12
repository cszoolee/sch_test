using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;
using Repository.GenericRepos;

namespace Repository.EmpRepos
{
    public class EmpSQLRepository : GenericSQLRepository<EMP>, IEmpRepository
    {
        public EmpSQLRepository(string connStr) : base(connStr, "emp", "empno")
        {
        }

        public override int GetIdValue(EMP input)
        {
            return (int)input.EMPNO;
        }

        public override void Insert(EMP newentity)
        {
            string sql = String.Format("INSERT INTO {0} VALUES (@empno, @ename, @job, @mgr, @hiredate, @sal, @comm, @deptno) ", tableName);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("empno", newentity.EMPNO.ToString());
            dict.Add("ename", newentity.ENAME);
            dict.Add("job", newentity.JOB);
            dict.Add("mgr", newentity.MGR.ToString());
            dict.Add("hiredate", newentity.HIREDATE.Value.ToShortDateString());
            dict.Add("sal", newentity.SAL.ToString());
            dict.Add("comm", newentity.COMM.ToString());
            dict.Add("deptno", newentity.DEPTNO.ToString());
            // nullReferenceException ????
            driver.ExecOther(sql, dict);
        }

        public override EMP RowToEntity(Dictionary<string, object> row)
        {
            EMP result = new EMP();
            result.EMPNO = (decimal)row["EMPNO"];
            result.ENAME = (string)row["ENAME"];
            result.JOB = (string)row["JOB"];
            result.MGR = (decimal)row["MGR"];
            result.HIREDATE = (DateTime)row["HIREDATE"];
            result.SAL = (decimal)row["SAL"];
            result.COMM = (decimal)row["COMM"];
            result.DEPTNO = (decimal)row["DEPTNO"];
            return result;
        }

        public IQueryable<GetAveragesResult> GetAverages()
        {
            string sql = String.Format("SELECT deptno, avg(sal) AS avgsal FROM {0} GROUP BY deptno", tableName);
            return driver.ExecSelect(sql).Select(x => new GetAveragesResult()
            {
                ID=(int)(decimal)x["DEPTNO"], AVG=(decimal)x["AVGSAL"]
            }).AsQueryable();
        }
    }
}
