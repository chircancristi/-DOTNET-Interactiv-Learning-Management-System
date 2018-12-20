using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using Xunit;

namespace TestModule
{
    [TestClass]
    public class StudentTest
    {
        private Student _Student= new Student("Teo", "Ploae", ".NET");

        [Fact]
        private void When_StudentIsInitialized_IsCreatedSuccessfully()
        {
           Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Student.FirstName == "Teo");
        }
        [Fact]
        private void When_StudentIsUpdated()
        {
            _Student.Update("Dorel", "Gelu", "Mate");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Student.FirstName == "Dorel");
        }
        [Fact]
        private void When_StudentReceivesAPlus()
        {
            _Student.addPlus();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Student.Pluses == 1);
        }

    }

}
