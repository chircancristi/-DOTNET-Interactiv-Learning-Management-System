using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataLayer;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        InteractionModel interaction = new InteractionModel();
        CoursesModel courses = new CoursesModel();
        Course course = new Course();
        List<Room> rooms = new List<Room>();
        PeopleModel people = new PeopleModel();
        List<Question> questions = new List<Question>();
        List<String> ownersName = new List<String>();
        Student student ;
        Guid id = Guid.Parse("F6722404-295C-4C96-BADE-8DDE246F596B");
        List<Course> coursesList = new List<Course>();
        List<Guid> roomIds = new List<Guid>();
        List<Guid> questionIds = new List<Guid>();
        List<String> questionContent = new List<String>();

        public IActionResult Student()
        {
            //this.GenerateStudent();
            SetData();
            return View();
        }

        private void SetData()
        {
            foreach (Course course in this.courses.GetAllCourses())
                coursesList.Add(course);
            @ViewBag.courses = coursesList;

            //SetRooms(); <------------
            //SetQuestions();
            @ViewBag.questions = questions;
            @ViewBag.owners = ownersName;



        }
            private void GenerateStudent()
        {
            student = people.GetStudent(this.id);
           
        }
        [HttpPost]
        public ActionResult StudentEnterCourse ( Guid id)
        {
            course = courses.GetCourse(id);
            HttpContext.Session.SetString("roomId", id.ToString());
            rooms = courses.GetAllRoomsByCourseId(id);
            for (int i=0; i < rooms.Count; i++)
            {
                roomIds.Add(rooms[i].Id);

            }
            SetQuestions(course.GeneralRoomId);

            return Json(new
            {
               numberOfQuestion = questions.Count,
               numberOfRooms = rooms.Count,
               roomsId = roomIds,
               owners = ownersName,
               questionsContent= questionContent,
               questionId = questionIds
            });

        }

       

        private void SetQuestions(Guid id)
        {
            questionIds = new List<Guid>();
            String firstName, lastName, fullName;
            questions = interaction.GetQuestionsByRoomId(id);

            for (int i = 0; i < questions.Count; i++)
            {

                if (questions[i].Type.Equals("professor"))
                {
                    firstName = people.GetProfesor(questions[i].OwnerId).FirstName;
                    lastName = people.GetProfesor(questions[i].OwnerId).LastName;
                }
                else
                {
                    firstName = people.GetStudent(questions[i].OwnerId).FirstName;
                    lastName = people.GetStudent(questions[i].OwnerId).LastName;
                }
                fullName = firstName + " " + lastName;
                ownersName.Add(fullName);
                questionContent.Add(questions[i].Content);
                questionIds.Add(questions[i].Id);
            }
        }
    }
}