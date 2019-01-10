using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{

    public class ProfessorController : Controller
    {
        InteractionModel interaction = new InteractionModel();
        CoursesModel courses = new CoursesModel();
        PeopleModel people = new PeopleModel();
        Profesor profesor = new Profesor();
        Guid id = Guid.Parse("0E603DD9-54DA-4E23-BBEA-2AF4C249D450");
        Course course = new Course();
        List<Student> students = new List<Student>();
        List<Question> questions = new List<Question>();
        List<String> ownersName = new List<String>();
        List<String> answerContent = new List<String>();
        List<Answer> Answers = new List<Answer>();

        List<Room> rooms = new List<Room>();
       

        public IActionResult Professor()
        {
            this.GenerateProfessor();
            SetData();
            SetQuestions(course.GeneralRoomId);
            HttpContext.Session.SetString("roomId", course.GeneralRoomId.ToString());
            return View();
        }
        [HttpPost]
        public IActionResult AddQuestion(string question)
        {
            String author;
            this.GenerateProfessor();
            Question newQuestion = new Question(this.id, Guid.Parse(HttpContext.Session.GetString("roomId")), "professor", question);
            interaction.AddQuestion(newQuestion);
            SetData();
            SetQuestions(Guid.Parse(HttpContext.Session.GetString("roomId")));
            author = profesor.LastName + " " + profesor.FirstName;
            return Json(new
            {
                type = "question",
                questionAuthor = author,
                questionContent = question,
                questionId = questions[questions.Count - 1].Id

            });
        }
        [HttpPost]
        public IActionResult AddAnswer(string answer)
        {
            String author;
            this.GenerateProfessor();
                
            Answer newAnswer = new Answer(this.id, Guid.Parse(HttpContext.Session.GetString("questionId")), answer, "professor");
            interaction.AddAnswer(newAnswer);
            SetData();
              
            author = profesor.LastName + " " + profesor.FirstName;
            return Json(new
            {
                type = "answer",
                answerAuthor = author,
                answerContent = answer,
            });
        }
        
        [HttpPost]
        public ActionResult LeaveRoom()
        {
            this.GenerateProfessor();
            SetData();
            SetQuestions(course.GeneralRoomId);
            HttpContext.Session.SetString("roomId", course.GeneralRoomId.ToString());

            List<String> questionContent = new List<string>();
            List<Guid> questionId = new List<Guid>();
            for (int i = 0; i < questions.Count; i++)
            {
                questionContent.Add(questions[i].Content);
                questionId.Add(questions[i].Id);
            }
            return Json(new
            {
                type = "null",
                numberOfQuestion = questions.Count,
                questionAuthor = this.ownersName,
                questionContent = questionContent,
                questionId = questionId

            });

        }
        [HttpPost]
        public ActionResult JoinRoom( Guid id)
        {
            this.GenerateProfessor();
            SetData();
            SetQuestions(id);
            
            HttpContext.Session.SetString("roomId", id.ToString());

            List<String> questionContent = new List<string>();
            List<Guid> questionId = new List<Guid>();
            for (int i=0; i < questions.Count; i++)
            {
                questionContent.Add(questions[i].Content);
                questionId.Add(questions[i].Id);
            }
            return Json(new
            {
                type="null",
                numberOfQuestion = questions.Count,
                questionAuthor = this.ownersName,
                questionContent = questionContent,
                questionId = questionId

            });
        }

        [HttpPost]
        public ActionResult CloseRoom(Guid id)
        {
            String roomId = HttpContext.Session.GetString("roomId");
            return Json(new
            {
                Id = roomId
            });
        }

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
            String idQuestion = id.ToString();
            HttpContext.Session.SetString( "questionId", idQuestion);
            
            return Json(new
            {
                type= "null",
                Authors = ownersName,
                Answers = answerContent,
                NumberOfAnswers = ownersName.Count,
                QuestionId = id
            }); 
        }
       
        

        private void SetData()
        {
            
            SetStudents();
            SetRooms();
            @ViewBag.students = students;
            @ViewBag.rooms = rooms;
            @ViewBag.course = this.course; 
        }
        
        [HttpPost]
        public ActionResult AddRoom()
        {
            this.GenerateProfessor();
            
            Room room = new Room(course.Id, profesor.Id);
            courses.AddRoom(room);
            SetData();
             
            return Json(new {
                type="null",
                number=rooms.Count,
                token= rooms[rooms.Count-1].Token,
                id= rooms[rooms.Count-1].Id
            });
        }

        private void GenerateProfessor()
        {
            
            profesor = people.GetProfesor(this.id);
            this.course = courses.GetCourse(profesor.CourseId);

        }
        public void SetStudents()
        {
            
            students = courses.GetStudentsByCourse(this.course.Id);
            
        }
        public void SetQuestions(Guid id)
        {
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
            }
            @ViewBag.questions = questions;
            @ViewBag.owners = ownersName;
        }

        private void SetRooms()
        {
            foreach(Room room in courses.GetAllRoomsByCourseId(course.Id)) {
                if (room.Id!=course.GeneralRoomId) rooms.Add(room);
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
