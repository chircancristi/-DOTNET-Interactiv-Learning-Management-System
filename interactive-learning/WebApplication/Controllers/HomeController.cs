using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        InteractionModel interaction = new InteractionModel();
        CoursesModel courses = new CoursesModel();
        PeopleModel people = new PeopleModel();
        Profesor profesor = new Profesor();
        Guid id = Guid.Parse("E0C3AC4D-6B9C-42F4-917C-FB307C6A652E");
        Course course = new Course();
        List<Student> students = new List<Student>();
        List<Question> questions = new List<Question>();
        List<String> ownersName = new List<String>();

        public IActionResult Professor()
        {
            
            this.GenerateProfessor();
            SetStudents();
           
            @ViewBag.students = students;
            @ViewBag.questions = questions;
            @ViewBag.owners = ownersName;
            return View();
        }
        [HttpPost]
        public IActionResult Professor(string questionProfessor)
        {
            this.GenerateProfessor();
            Question question = new Question(this.id, this.course.GeneralRoomId, "professor", questionProfessor);
            
            interaction.AddQuestion(question);
            SetStudents();
            @ViewBag.students = this.students;
            @ViewBag.questions = this.questions;
            @ViewBag.owners = this.ownersName;
            return View();
        }
        private void GenerateProfessor()
        {
            
            profesor = people.GetProfesor(this.id);
            this.course = courses.GetCourse(profesor.CourseId);

        }
        public void SetStudents()
        {
            String firstName, lastName, fullName;
            students = courses.GetStudentsByCourse(this.course.Id);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
