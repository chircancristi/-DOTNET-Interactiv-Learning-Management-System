using System;
using DataLayer;
using BusinessLayer;
using System.Collections.Generic;

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

        public List<Student> GetStudentsByCourse(Guid courseId)
        {
           var relationships = _unitOfWork.StudentCourseRelationshipRepository.GetRelationshipsByCourse(courseId);
           var result = new List<Student>();
           foreach (StudentCourseRelationship relationship in relationships)
           {
                result.Add(_unitOfWork.StudentRepository.GetStudentById(relationship.StudentId));
           }
           return result;
        }

        public List<Student> GetStudentsByRoomId(Guid roomId)
        {
            var relationships = _unitOfWork.StudentRoomRelationshipRepository.GetRelationshipsByRoomId(roomId);

            var result = new List<Student>();
            foreach (StudentRoomRelationship relationship in relationships)
            {
                result.Add(_unitOfWork.StudentRepository.GetStudentById(relationship.StudentId));
            }
            return result;
        }

        public List<Room> GetAllRoomsByCourseId(Guid courseId)
        {
            return _unitOfWork.RoomRepository.GetRoomsByCourseId(courseId);
        }

        public void AddRoom(Room room)
        {
            _unitOfWork.RoomRepository.Add(room);
            _unitOfWork.Commit();
        }

        public void AddCourse(Course course)
        {
            _unitOfWork.CourseRepository.Add(course);
            _unitOfWork.Commit();
        }
        public void CloseRoom(Guid Id)
        {
            _unitOfWork.RoomRepository.CloseRoom(Id);
            _unitOfWork.Commit();
        }

        public List<Course> GetAllCourses()
        {
            return _unitOfWork.CourseRepository.GetAllCourses();
        }

        public List<Room> GetAllRooms()
        {
            return _unitOfWork.RoomRepository.GetAllRooms();
        }
    }
}
