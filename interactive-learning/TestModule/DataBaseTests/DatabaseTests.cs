using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestModule.DataBaseTests
{
    public class DatabaseTests
    {
        private readonly DataBase dataBase = new DataBase();
        
        [Fact]
        private void TestsIfStudentExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(dataBase.MyUnitOfWork.StudentRepository.GetStudentById(dataBase.student1.Id).FirstName == "Alex");
        }
        [Fact]
        private void TestIfProfesorExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(dataBase.MyUnitOfWork.ProfesorRepository.GetProfesorById(dataBase.profesor.Id).FirstName == "Test");
        }
        [Fact]
        private void TestIfCourseExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(dataBase.MyUnitOfWork.CourseRepository.GetCourseById(dataBase.course.Id).Name == "Dotnet");
        }
        [Fact]
        private void TestIfRoomExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(dataBase.MyUnitOfWork.RoomRepository.GetRoomById(dataBase.room.Id).ProfesorId == dataBase.profesor.Id);
        }
        [Fact]
        private void TestIfAnswerExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(dataBase.MyUnitOfWork.AnswerRepository.GetAnswerById(dataBase.answer1.Id).Content == "Nu");
        }
        [Fact]
        private void TestIfQuestionExistsInDatabase()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(dataBase.MyUnitOfWork.QuestionRepository.GetQuestionById(dataBase.question1.Id).Content == "Se da cursul asta in sesiune?");
        }

    }
}
