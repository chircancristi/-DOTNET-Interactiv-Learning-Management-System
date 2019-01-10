using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Models;

namespace TestModule
{
    public class RoomTests
    {
        private Room _Room = new Room(new Guid(), new Guid());
        CoursesModel courses = new CoursesModel();
        

        [Fact]
        private void When_GetAllRooms_IsCalled_ReturnAllRooms()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(courses.GetAllRooms().Count == 3);
        }

    }
}
