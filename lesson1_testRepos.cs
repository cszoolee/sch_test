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
            DeptRepo.Insert(new DEPT() { DEPTNO=50, DNAME="THIEVES", LOC=4 });
            foreach (var akt in DeptRepo.GetAll())
            {
                Console.WriteLine("DEPTNO={0}, DNAME={1}", akt.DEPTNO, akt.DNAME);
            }
            Console.ReadLine();