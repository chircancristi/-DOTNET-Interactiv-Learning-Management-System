using DataLayer;
using BusinessLayer;

namespace Executable
{
    public class Program
    {
        static void Main(string[] args)
        {
            var MyUnitOfWork = new UnitOfWork();

            var student1 = new Student("Alex", "Stoica", "Retele");
            var student2 = new Student("Tudor", "Melnic", "Franceza");

            var profesor = new Profesor("Test", "Mardare", "Franceza");

            var course = new Course("Dotnet", profesor.Id);

            var room = new Room(course.Id, profesor.Id);

            var question1 = new Question(student1.Id, room.Id, "intrebare desteapta", "Se da cursul asta in sesiune?");

            var question2 = new Question(student2.Id, room.Id, "alta intrebare desteapta", "Putem pleca?");

            var answer1 = new Answer(profesor.Id, question1.Id, "Nu");
            var answer2 = new Answer(profesor.Id, question2.Id, "Nu");

            MyUnitOfWork.StudentRepository.Add(student1);
            MyUnitOfWork.StudentRepository.Add(student2);

            MyUnitOfWork.ProfesorRepository.Add(profesor);

            MyUnitOfWork.CourseRepository.Add(course);
            MyUnitOfWork.RoomRepository.Add(room);

            MyUnitOfWork.QuestionRepository.Add(question1);
            MyUnitOfWork.QuestionRepository.Add(question2);

            MyUnitOfWork.AnswerRepository.Add(answer1);
            MyUnitOfWork.AnswerRepository.Add(answer2);

            MyUnitOfWork.Commit();

            System.Console.Write(MyUnitOfWork.StudentRepository.GetStudentById(student1.Id).FirstName);
            System.Console.Write(MyUnitOfWork.ProfesorRepository.GetProfesorById(profesor.Id).FirstName);
            System.Console.Write(MyUnitOfWork.QuestionRepository.GetQuestionById(question1.Id).Content);
            System.Console.Write(MyUnitOfWork.AnswerRepository.GetAnswerById(answer1.Id).Content);
            System.Console.Write(MyUnitOfWork.CourseRepository.GetCourseById(course.Id).Name);
            System.Console.Write(MyUnitOfWork.RoomRepository.GetRoomById(room.Id).CourseId);
            System.Console.Read();
        }
    }
}
