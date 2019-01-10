using DataLayer;
using System;
using Xunit;
using Models;

namespace TestModule
{
    public class ProfesorTest
    {

        private Profesor _Profesor = new Profesor();
        PeopleModel professors = new PeopleModel();

        

        [Fact]
        private void When_ProfesorIsUpdated()
        {
            _Profesor.Update("Nelu", "George", Guid.Parse("57D3CD12-C69D-427F-87FD-AB4560A13337"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Profesor.FirstName == "Nelu");
        }

        [Fact]
        private void When_GetAllProfessors_IsCalled_ReturnAllProfessors()
        {

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(professors.GetAllProfessors().Count == 1);
        }


    }
}
