using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using Xunit;
using Models;

namespace TestModule
{
    [TestClass]
    public class StudentTest
    {
        private Student _Student= new Student("Teo", "Ploae");
        PeopleModel students = new PeopleModel();

        [Fact]
        private void When_StudentIsInitialized_IsCreatedSuccessfully()
        {
           Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Student.FirstName == "Teo");
        }
        [Fact]
        private void When_StudentIsUpdated()
        {
            _Student.Update("Dorel", "Gelu");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Student.FirstName == "Dorel");
        }
        [Fact]
        private void When_GetAllStudents_IsCalled_ReturnAllStudents()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(students.GetAllStudents().Count == 2);
        }
    }

}
