﻿using System;
using System.Linq;

namespace BusinessLayer
{
    public class StudentRepository
    {
        public UnitOfWork unitOfWork;

        public StudentRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        void CreateProfesor(DataLayer.Profesor profesor)
        {
            unitOfWork.ProfesorRepository.Add(profesor);
        }

        void RemoveProfesorByItsId(Guid Id)
        {
            var profesor = unitOfWork.ProfesorRepository.Entities.First(a => a.Id == Id);
            unitOfWork.ProfesorRepository.Remove(profesor);
            unitOfWork.Commit();
        }
    }
}
