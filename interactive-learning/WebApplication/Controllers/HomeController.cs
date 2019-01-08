using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Guid id = Guid.Parse("6F17AA98-75E3-46DC-BBB9-8FE57CECC6E8");
        Course course = new Course();
        List<Student> students = new List<Student>();
        List<Question> questions = new List<Question>();
        List<String> ownersName = new List<String>();
        List<String> answerContent = new List<String>();
        List<Room> rooms = new List<Room>();
        List<Answer> Answers = new List<Answer>();

        public IActionResult Professor()
        {
            this.GenerateProfessor();
            SetData();
            return View();
        }
        [HttpPost]
        public IActionResult Professor(string questionProfessor)
        {
            
            this.GenerateProfessor();
            Question question = new Question(this.id, this.course.GeneralRoomId, "professor", questionProfessor);
            interaction.AddQuestion(question);
            SetData();

            return View();
        }
        /*
        [HttpPost]
        public ActionResult ProfessorAnswer()
        {
        }*/
        [HttpPost]
        public ActionResult ProfessorAnswers(Guid id)
        {
            String firstName, lastName, fullName;
            this.GenerateProfessor();
            SetData();
            
            Answers = interaction.GetAnswersByQuestionId(id);
            ownersName = new List<string>();
            answerContent = new List<string>();
            
            for (int i = 0; i < Answers.Count; i++)
            {
                answerContent.Add(Answers[i].Content);
                if (Answers[i].Type.Equals("professor"))
                {
                    firstName = people.GetProfesor(Answers[i].OwnerId).FirstName;
                    lastName = people.GetProfesor(Answers[i].OwnerId).LastName;
                }
                else
                {
                    firstName = people.GetStudent(Answers[i].OwnerId).FirstName;
                    lastName = people.GetStudent(Answers[i].OwnerId).LastName;
                }
                fullName = firstName + " " + lastName;
                ownersName.Add(fullName);
            }


            return Json(new
            {
                Authors = ownersName,
                Answers = answerContent,
                NumberOfAnswers = ownersName.Count,
                QuestionId = id
            }); 
        }

        [HttpPost]
         public ActionResult ProfessorAnswer(Guid QuestionId,String answerProfessor)
        {
            return Redirect("/Professor");
        }

        private void SetData()
        {
            
            SetStudents();
            SetRooms();
            @ViewBag.students = students;
            @ViewBag.questions = questions;
            @ViewBag.owners = ownersName;
            @ViewBag.answer = false;
            @ViewBag.rooms = rooms;
        }
        
        [HttpPost]
        public ActionResult AddRoom()
        {
            Room room = new Room(course.Id, profesor.Id);
            courses.AddRoom(room);

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

        private void SetRooms()
        {
            foreach(Room room in courses.GetAllRoomsByCourseId(course.Id)) {
                rooms.Add(room);
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
