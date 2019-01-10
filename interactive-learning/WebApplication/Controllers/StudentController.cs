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
        Guid id = Guid.Parse("2DC60396-272B-4F54-B8EC-5F2F918284F0");
        List<Course> coursesList = new List<Course>();
        List<Guid> roomIds = new List<Guid>();
        List<Guid> questionIds = new List<Guid>();
        List<String> questionContent = new List<String>();
        List<String> answerContent = new List<String>();
        List<Answer> Answers = new List<Answer>();

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
        public IActionResult CheckRoomExpiration(Guid id)
        {
            Room currentRoom = courses.GetRoom(id);
            return Json(new
            {
                opened = currentRoom.Open

            });            
        }
        [HttpPost]
        public IActionResult CheckToken(int token,Guid id)
        {
            bool valid;
            Room currentRoom = courses.GetRoom(id);
            if (currentRoom.Token == token)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return Json(new
            {
                valid = valid
            });
        }
        [HttpPost]
        public ActionResult LeaveRoomStudent()
        {
            this.GenerateStudent();
            HttpContext.Session.SetString("IsInRoom", "false");
            course =courses.GetCourse(Guid.Parse(HttpContext.Session.GetString("CourseIdStudent")));
            HttpContext.Session.SetString("roomId", course.GeneralRoomId.ToString());
            SetQuestions(course.GeneralRoomId);
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
        public IActionResult JoinRoomStudent(Guid Id)
        {
            this.GenerateStudent();
            HttpContext.Session.SetString("IsInRoom", "true");
            SetQuestions(Id);
            Room room = courses.GetRoom(Id);
            HttpContext.Session.SetString("roomIdStudent", Id.ToString());

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
                questionId = questionId,
            });

        }
        [HttpPost]
        public IActionResult AddAnswerStudent(string answer)
        {
            String author;
            this.GenerateStudent();

            Answer newAnswer = new Answer(this.id, Guid.Parse(HttpContext.Session.GetString("questionIdStudent")), answer, "student");
            interaction.AddAnswer(newAnswer);
            SetData();

            author = student.LastName + " " + student.FirstName;
            return Json(new
            {
                type = "answer",
                answerAuthor = author,
                answerContent = answer,
                
        });
        }
        [HttpPost]
        public IActionResult AddQuestionStudent(string question)
        {
            String author;
            this.GenerateStudent();
            Question newQuestion = new Question(this.id, Guid.Parse(HttpContext.Session.GetString("roomIdStudent")), "student", question);
            interaction.AddQuestion(newQuestion);
            SetData();
            SetQuestions(Guid.Parse(HttpContext.Session.GetString("roomIdStudent")));
            author = student.LastName + " " + student.FirstName;
            return Json(new
            {
                type = "question",
                questionAuthor = author,
                questionContent = question,
                questionId = questions[questions.Count - 1].Id

            });
        }

        [HttpPost]
        public ActionResult StudentAnswers(Guid id)
        {
            String firstName, lastName, fullName;
            this.GenerateStudent();
            SetData();
            Question question = interaction.GetQuestion(id);
            Answers = interaction.GetAnswersByQuestionId(id);
            ownersName = new List<string>();
            answerContent = new List<string>();
            Room room = courses.GetRoom(Guid.Parse(HttpContext.Session.GetString("roomIdStudent")));
            bool favoriteAnswerFlag=false;
            bool timeExpired = false;
            int favoriteAnswerPosition=0;

            for (int i = 0; i < Answers.Count; i++)
            {
                if (Answers[i].FavouriteAnswerFlag == true)
                {
                    favoriteAnswerFlag = true;
                    favoriteAnswerPosition=i;
                }
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
            HttpContext.Session.SetString("questionIdStudent", idQuestion);
            if (question.Start<= DateTime.Now && question.Stop>=DateTime.Now)
            {
                timeExpired = false;
            }
            else
            {
                timeExpired = true;
            }
            return Json(new
            {
                type = "null",
                Authors = ownersName,
                Answers = answerContent,
                NumberOfAnswers = ownersName.Count,
                QuestionId = id,
                isInRoom = HttpContext.Session.GetString("IsInRoom"),
                roomOpen = room.Open,
                favoriteAnswerFlag = favoriteAnswerFlag,
                favoriteAnswerPosition = favoriteAnswerPosition,
                timeExpired = timeExpired,
                endDate = question.Stop.ToString()
            });
        }
        [HttpPost]
        public ActionResult StudentEnterCourse ( Guid id)
        {
            course = courses.GetCourse(id);
            HttpContext.Session.SetString("roomIdStudent", course.GeneralRoomId.ToString());
            HttpContext.Session.SetString("CourseIdStudent", course.Id.ToString());
            rooms = courses.GetAllRoomsByCourseId(id);
            for (int i=0; i < rooms.Count; i++)
            {
               if(rooms[i].Id!=course.GeneralRoomId) roomIds.Add(rooms[i].Id);

            }
            SetQuestions(course.GeneralRoomId);

            return Json(new
            {
               numberOfQuestion = questions.Count,
               numberOfRooms = rooms.Count-1,
               roomsId = roomIds,
               owners = ownersName,
               questionsContent= questionContent,
               questionId = questionIds
            });
        }

        private void GenerateStudent(Guid id)
        {
            student = people.GetStudent(this.id);
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