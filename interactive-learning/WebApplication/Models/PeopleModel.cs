using System;
using DataLayer;
using BusinessLayer;

namespace Models
{
    public class PeopleModel
    {
        private readonly UnitOfWork _unitOfWork;

        public PeopleModel()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Student GetStudent(Guid guid)
        {
            return _unitOfWork.StudentRepository.GetStudentById(guid);
        }

        public Profesor GetProfesor(Guid guid)
        {
            return _unitOfWork.ProfesorRepository.GetProfesorById(guid);
        }
    }
}
