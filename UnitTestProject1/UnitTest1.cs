using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Repository.EmpRepos;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAverages()
        {
            EmpDeptEntities ED = new EmpDeptEntities();
            EmpEFRepository RepoEF = new EmpEFRepository(ED);
            EmpListRepository RepoList = new EmpListRepository();

            var actual = RepoEF.GetAverages().ToList();
            var expected = RepoList.GetAverages().ToList();
            //actual.Add(null);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
