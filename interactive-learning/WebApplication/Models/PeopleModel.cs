using System;
using DataLayer;
using BusinessLayer;
using System.Collections.Generic;

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

        public void AddStudent(Student student)
        {
            _unitOfWork.StudentRepository.Add(student);
            _unitOfWork.Commit();
        }

        public void AddProfesor(Profesor profesor)
        {
            _unitOfWork.ProfesorRepository.Add(profesor);
            _unitOfWork.Commit();
        }

        public List<Profesor> GetAllProfessors()
        {
            return _unitOfWork.ProfesorRepository.GetAllProfessors();
        }

        public List<Student> GetAllStudents()
        {
            return _unitOfWork.StudentRepository.GetAllStudents();
        }
    }
}
