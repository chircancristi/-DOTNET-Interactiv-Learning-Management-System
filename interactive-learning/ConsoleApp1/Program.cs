using DataLayer;
using BusinessLayer;

namespace Executable
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            PeopleContext peopleContext = new PeopleContext();
            InteractionContext interactionContext = new InteractionContext();
            CoursesContext coursesContext = new CoursesContext();

            var MyUnitOfWork = new UnitOfWork(peopleContext, interactionContext, coursesContext);

            var student1 = new Student("Alex", "Stoica", "Retele");
            var student2 = new Student("Tudor", "Melnic", "Franceza");

            var profesor = new Profesor("Valeriu", "Mardare", "Franceza");

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
        }
    }
}
