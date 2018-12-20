using System;
using DataLayer;
using BusinessLayer;

namespace Models
{
    public class CoursesModel
    {
        private readonly UnitOfWork _unitOfWork;

        public CoursesModel()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Course GetCourse(Guid guid)
        {
            return _unitOfWork.CourseRepository.GetCourseById(guid);
        }

        public Room GetRoom(Guid guid)
        {
            return _unitOfWork.RoomRepository.GetRoomById(guid);
        }
    }
}
