using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestModule
{
    public class CoursesTests
    {
        private Course _Course = new Course("Mate",new Guid());

        [Fact]
        private void When_CourseIsInitialized_IsCreatedSuccessfully()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Course.Name == "Mate");
        }

    }
}
