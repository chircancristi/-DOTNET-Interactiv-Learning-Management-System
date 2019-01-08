using DataLayer;
using BusinessLayer;
using Models;
using System.Collections.Generic;

namespace Executable
{
    public class Program
    {
        static void Main(string[] args)
        {
            var MyUnitOfWork = new UnitOfWork();

            var student1 = new Student("Alex", "Stoica");
            var student2 = new Student("Tudor", "Melnic");

            var profesor = new Profesor();

            var course = new Course("Dotnet", profesor.Id);
            var course2 = new Course("CLIW", profesor.Id);

            profesor.Update("Valeriu", "Mardare", course.Id);

            var room = new Room(course.Id, profesor.Id);
            var room2 = new Room(course.Id, profesor.Id);

            course.SetGeneralRoomId(room);
            course2.SetGeneralRoomId(room2);

            var question1 = new Question(student1.Id, room.Id, "student", "Se da cursul asta in sesiune?");

            var question2 = new Question(student2.Id, room.Id, "student", "Putem pleca?");
            var question3 = new Question(student2.Id, room.Id, "student",  "Cum rezolvam?");
            var question4 = new Question(student2.Id, room2.Id, "student", "Se face seminarul maine?");
            var question5 = new Question(student2.Id, room2.Id, "student", "Are cineva modele de examen?");

            var answer1 = new Answer(profesor.Id, question1.Id, "Nu","professor");
            var answer2 = new Answer(profesor.Id, question2.Id, "Nu stiu", "professor");
            var answer3 = new Answer(profesor.Id, question2.Id, "Merge", "professor");

            MyUnitOfWork.StudentRepository.Add(student1);
            MyUnitOfWork.StudentRepository.Add(student2);

            MyUnitOfWork.ProfesorRepository.Add(profesor);

            MyUnitOfWork.CourseRepository.Add(course);
            MyUnitOfWork.CourseRepository.Add(course2);

            MyUnitOfWork.RoomRepository.Add(room);
            MyUnitOfWork.RoomRepository.Add(room2);


            MyUnitOfWork.QuestionRepository.Add(question1);
            MyUnitOfWork.QuestionRepository.Add(question2);
            MyUnitOfWork.QuestionRepository.Add(question3);
            MyUnitOfWork.QuestionRepository.Add(question4);
            MyUnitOfWork.QuestionRepository.Add(question5);
            

            MyUnitOfWork.AnswerRepository.Add(answer1);
            MyUnitOfWork.AnswerRepository.Add(answer2);
            MyUnitOfWork.AnswerRepository.Add(answer3);

            var relationship1 = new StudentCourseRelationship(student1.Id, course.Id);
            var relationship2 = new StudentCourseRelationship(student2.Id, course.Id);
            var relationship3 = new StudentCourseRelationship(student2.Id, course2.Id);

            var StudRoomRel1 = new StudentRoomRelationship(student1.Id, room.Id);
            var StudRoomRel2 = new StudentRoomRelationship(student2.Id, room.Id);
            var StudRoomRel11 = new StudentRoomRelationship(student1.Id, room.Id);

            MyUnitOfWork.StudentCourseRelationshipRepository.Add(relationship1);
            MyUnitOfWork.StudentCourseRelationshipRepository.Add(relationship2);
            MyUnitOfWork.StudentCourseRelationshipRepository.Add(relationship3);

            MyUnitOfWork.StudentRoomRelationshipRepository.Add(StudRoomRel1);
            MyUnitOfWork.StudentRoomRelationshipRepository.Add(StudRoomRel2);
            MyUnitOfWork.StudentRoomRelationshipRepository.Add(StudRoomRel11);

            MyUnitOfWork.Commit();

            var peopleModel = new PeopleModel();
            var coursesModel = new CoursesModel();
            var interactionModel = new InteractionModel();

            //System.Console.Write(peopleModel.GetStudent(student1.Id).FirstName);
            //System.Console.Write(peopleModel.GetProfesor(profesor.Id).FirstName);

            foreach (Student student in coursesModel.GetStudentsByCourse(course.Id))
            {
                System.Console.WriteLine("Student la CourseId " + student.FirstName);
            }
            foreach (Answer answer in interactionModel.GetAnswersByQuestionId(question2.Id))
            {
                System.Console.WriteLine(answer.Id);
            }
            foreach (Student student in coursesModel.GetStudentsByRoomId(room.Id))
            {
                System.Console.WriteLine("Student la RoomId " + student.FirstName);
            }
            System.Console.Read();
        }
    }
}