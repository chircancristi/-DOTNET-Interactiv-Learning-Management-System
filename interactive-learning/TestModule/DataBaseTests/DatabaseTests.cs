using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Models;

namespace TestModule.DataBaseTests
{
    public class DatabaseTests
    {
        PeopleModel people = new PeopleModel();
        CoursesModel courses = new CoursesModel();
        InteractionModel interaction = new InteractionModel();

        [Fact]
        private void TestsIfStudentExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(people.GetStudent(Guid.Parse("AF3A7A50-BBE6-486C-BCDE-74692CA64481")).FirstName == "Tudor");
        }
        [Fact]
        private void TestIfProfesorExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(people.GetProfesor(Guid.Parse("0E603DD9-54DA-4E23-BBEA-2AF4C249D450")).FirstName == "Valeriu");
        }
        [Fact]
        private void TestIfCourseExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(courses.GetCourse(Guid.Parse("79EC2E50-B26F-44F0-9462-B57AF3C49CEB")).Name == "CLIW");
        }
        [Fact]
        private void TestIfRoomExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(courses.GetRoom(Guid.Parse("120AD737-95C9-4F86-A21C-4636D2A44CA7")).ProfesorId == people.GetProfesor(Guid.Parse("0E603DD9-54DA-4E23-BBEA-2AF4C249D450")).Id);
        }
        [Fact]
        private void TestIfAnswerExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(interaction.GetAnswer(Guid.Parse("16FC0782-5B56-40C5-AC10-5052CF3F3941")).Content == "Nu");
        }
        [Fact]
        private void TestIfQuestionExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(interaction.GetQuestion(Guid.Parse("1D588E4B-7DA2-4380-91FE-3E168D9A7789")).Content == "Se face seminarul maine?");
        }

    }
}
