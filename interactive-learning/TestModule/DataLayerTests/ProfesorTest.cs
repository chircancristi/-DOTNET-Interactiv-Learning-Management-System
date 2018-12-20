using DataLayer;
using Xunit;

namespace TestModule
{
    public class ProfesorTest
    {

        private Profesor _Profesor = new Profesor("Nelu", "Gelu", ".NET");

        [Fact]
        private void When_ProfesorIsInitialized_IsCreatedSuccessfully()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Profesor.FirstName == "Nelu");
        }
        [Fact]
        private void When_ProfesorIsUpdated()
        {
            _Profesor.Update("Dorel", "Gelu", "Mate");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Profesor.FirstName == "Dorel");
        }

    }
}
