using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestModule
{
    public class CoursesTests
    {
        private Course _Course = new Course("Mate",new Guid());
        InteractionModel interaction = new InteractionModel();
        CoursesModel courses = new CoursesModel();

        [Fact]
        private void When_CourseIsInitialized_IsCreatedSuccessfully()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Course.Name == "Mate");
        }

        [Fact]
        private void When_GetAllCourses_IsCalled_ReturnAllCourses()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(courses.GetAllCourses().Count == 2);
        }

    }
}
