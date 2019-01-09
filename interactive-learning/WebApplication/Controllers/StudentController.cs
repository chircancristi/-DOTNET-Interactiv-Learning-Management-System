using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataLayer;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        Student student = new Student("Tudor", "Melnic");
        Guid id = Guid.Parse("7ACB0120-0474-4917-AF6D-178287E667C8");
        List<String> coursesNames = new List<String>();

        public IActionResult Student()
        {
            //this.GenerateStudent();
            //SetData();
            return View();
        }

        private void SetData()
        {
            foreach (Course course in this.courses.GetAllCourses())
                coursesNames.Add(course.Name);
            @ViewBag.courses = coursesNames;

            SetRooms();



        }

            private void GenerateStudent()
        {
            student = people.GetStudent(this.id);

        }


        private void SetRooms()
        {
            foreach (Room room in courses.GetAllRoomsByCourseId(course.Id))
            {
                rooms.Add(room);
            }

        }

        private void SetQuestions()
        {
            String firstName, lastName, fullName;
            questions = interaction.GetQuestionsByRoomId(this.course.GeneralRoomId);

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
            }
        }
    }
}