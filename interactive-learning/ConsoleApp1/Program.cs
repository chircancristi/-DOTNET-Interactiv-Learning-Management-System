using System.Collections.Generic;
using DataLayer;
using BusinessLayer;

namespace Executable
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            PeopleContext peopleContext = new PeopleContext();
            var MyUnitOfWork = new UnitOfWork(peopleContext);

            var student1 = new Student("Dani", "Alves", "Retele");
            var student2 = new Student("Kendji", "Girac", "Muzica");
            var listOfStudents = new List<Student>
            {
                student1,
                student2
            };

            var profesor = new Profesor("Alfa", "Omega", "detoate", listOfStudents);

            MyUnitOfWork.StudentRepository.Add(student1);
            MyUnitOfWork.StudentRepository.Add(student2);

            MyUnitOfWork.ProfesorRepository.Add(profesor);

            MyUnitOfWork.Commit();
        }
    }
}
