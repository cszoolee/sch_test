using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;
using Repository.DeptRepos;
using Repository.EmpRepos;

namespace lesson1_db
{
    class Program
    {

        //static string connStr=@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\anon\munka\Actual\tanfolyamok\SCH\Actual\lesson1_db\Entities\EmpDept.mdf;Integrated Security=True";
        static string connStr = @"data source=(LocalDB)\v11.0;attachdbfilename=|DataDirectory|\EmpDept.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        static IEmpRepository EmpRepo;
        static IDeptRepository DeptRepo;

        static void InitRepos()
        {
            //EmpRepo = new EmpListRepository();
            //DeptRepo = new DeptListRepository();

            //EmpRepo = new EmpSQLRepository(connStr);
            //DeptRepo = new DeptSQLRepository(connStr);

            EmpDeptEntities ED = new EmpDeptEntities();
            EmpRepo = new EmpEFRepository(ED);
            DeptRepo = new DeptEFRepository(ED);
        }

        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            
            SqlCommand cmd = new SqlCommand("select * from emp", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            object[] row = null;
            while (reader.Read())
            {
                if (row == null)
                {
                    row = new object[reader.FieldCount];
                }
                reader.GetValues(row);
                Console.WriteLine("=======================");
                for (int i = 0; i < row.Length; i++)
                {
                    Console.WriteLine("{0} = {1}", reader.GetName(i), row[i]);
                }
            }
            Console.ReadLine();
            Console.WriteLine();
            
            EmpDeptEntities ED = new EmpDeptEntities();
            foreach (DEPT akt in ED.DEPT)
            {
                Console.WriteLine("DEPTNO={0}, DNAME={1}",akt.DEPTNO,akt.DNAME);
            }
            var q = from akt in ED.EMP
                    group akt by akt.JOB into g
                    select new { JOB=g.Key, COUNT=g.Count() };
            foreach (var akt in q) Console.WriteLine(akt);

            Console.ReadLine();

            InitRepos();
            foreach (var akt in EmpRepo.GetAverages())
            {
                Console.WriteLine("DEPTNO={0}, AVG={1}", akt.ID, akt.AVG);
            }
            DEPT d = DeptRepo.GetById(30);
            Console.WriteLine();

            Console.WriteLine("DEPTNO={0}, DNAME={1}", d.DEPTNO, d.DNAME);
            Console.WriteLine();

            DeptRepo.Delete(40);
            DeptRepo.Insert(new DEPT() { DEPTNO = 50, DNAME = "THIEVES", LOC = 4 });
            foreach (var akt in DeptRepo.GetAll())
            {
                Console.WriteLine("DEPTNO={0}, DNAME={1}", akt.DEPTNO, akt.DNAME);
            }
            Console.ReadLine();
        }
    }
}
