using System;
using System.Linq;

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

        void RemoveCourseByItsId(Guid Id)
        {
            var course = unitOfWork.CourseRepository.Entities.First(a => a.Id == Id);
            unitOfWork.CourseRepository.Remove(course);
            unitOfWork.Commit();
        }
    }
}
