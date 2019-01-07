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

            var profesor = new Profesor("Valeriu", "Mardare", "Franceza");

            var course = new Course("Dotnet", profesor.Id);
            var course2 = new Course("CLIW", profesor.Id);

            var room = new Room(course.Id, profesor.Id);

            var question1 = new Question(student1.Id, room.Id, "intrebare desteapta", "Se da cursul asta in sesiune?");

            var question2 = new Question(student2.Id, room.Id, "alta intrebare desteapta", "Putem pleca?");

            var answer1 = new Answer(profesor.Id, question1.Id, "Nu");
            var answer2 = new Answer(profesor.Id, question2.Id, "Nu stiu");
            var answer3 = new Answer(profesor.Id, question2.Id, "Eu sunt Patrut nu ma pricep");

            MyUnitOfWork.StudentRepository.Add(student1);
            MyUnitOfWork.StudentRepository.Add(student2);

            MyUnitOfWork.ProfesorRepository.Add(profesor);

            MyUnitOfWork.CourseRepository.Add(course);
            MyUnitOfWork.RoomRepository.Add(room);

            MyUnitOfWork.QuestionRepository.Add(question1);
            MyUnitOfWork.QuestionRepository.Add(question2);

            MyUnitOfWork.AnswerRepository.Add(answer1);
            MyUnitOfWork.AnswerRepository.Add(answer2);
            MyUnitOfWork.AnswerRepository.Add(answer3);

            var relationship1 = new StudentCourseRelationship(student1.Id, course.Id);
            var relationship2 = new StudentCourseRelationship(student2.Id, course.Id);
            var relationship3 = new StudentCourseRelationship(student2.Id, course2.Id);

            MyUnitOfWork.StudentCourseRelationshipRepository.Add(relationship1);
            MyUnitOfWork.StudentCourseRelationshipRepository.Add(relationship2);
            MyUnitOfWork.StudentCourseRelationshipRepository.Add(relationship3);

            MyUnitOfWork.Commit();
            
            var peopleModel = new PeopleModel();
            var coursesModel = new CoursesModel();
            var interactionModel = new InteractionModel();

            //System.Console.Write(peopleModel.GetStudent(student1.Id).FirstName);
            //System.Console.Write(peopleModel.GetProfesor(profesor.Id).FirstName);

            foreach (Student student in coursesModel.GetStudentsByCourse(course.Id))
            {
                System.Console.WriteLine("Un student:" + student.FirstName);
            }
            foreach (Answer answer in interactionModel.GetAnswersByQuestionId(question2.Id) )
            {
                System.Console.WriteLine(answer.Id);
            }
            System.Console.Read();
        }
    }
}
