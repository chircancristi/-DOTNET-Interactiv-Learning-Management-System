using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using BusinessLayer;

namespace TestModule
{
    [TestClass]
    public class StudentTest
    {
        private Student _Student;

        [TestInitialize]
        private void TestInitializer()
        {
            _Student = new Student("Teo", "Ploae", ".NET");

        }

        [TestMethod] 
        private void When_StudentIsInitialized_IsCreatedSuccessfully()
        {
            Assert.IsTrue(_Student.FirstName == "Teo");
        }

    }

}
