using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class CourseRepository
    {
        public UnitOfWork unitOfWork;

        public CourseRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        void CreateCourse(DataLayer.Course course)
        {
            unitOfWork.CourseRepository.Add(course);
        }

        void RemoveProfesorByItsId(Guid Id)
        {
            var profesor = unitOfWork.ProfesorRepository.Entities.First(a => a.Id == Id);
            unitOfWork.ProfesorRepository.Remove(profesor);
            unitOfWork.Commit();
        }
    }
}
