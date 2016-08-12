using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.GenericRepos;
using Entities;

namespace Repository.DeptRepos
{
    public class DeptSQLRepository : GenericSQLRepository<DEPT>, IDeptRepository
    {
        public DeptSQLRepository(string connStr) : base(connStr, "dept", "deptno")
        {
        }

        public override int GetIdValue(DEPT input)
        {
            return (int)input.DEPTNO;
        }

        public override DEPT RowToEntity(Dictionary<string, object> row)
        {
            DEPT result = new DEPT();
            result.DEPTNO = (decimal)row["DEPTNO"];
            result.DNAME = (string)row["DNAME"];
            result.LOC = (int)row["LOC"];
            return result;
        }

        public override void Insert(DEPT newentity)
        {
            string sql = String.Format("INSERT INTO {0} VALUES (NEXT VALUE FOR DEPTSEQ, @dname, @loc) ", tableName);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("dname", newentity.DNAME);
            dict.Add("loc", newentity.LOC.ToString());
            driver.ExecOther(sql, dict);
        }

        public void Modify(int id, string newname, int newloc)
        {
            string sql = String.Format("UPDATE {0} SET dname=@dname, loc=@loc WHERE {1} = @id", tableName, idName);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("dname", newname);
            dict.Add("loc", newloc.ToString());
            dict.Add("id", id.ToString());
            driver.ExecOther(sql, dict);
        }
    }
}
