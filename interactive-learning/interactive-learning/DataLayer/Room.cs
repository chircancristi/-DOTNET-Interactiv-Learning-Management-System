using System;
namespace interactive_learning.DataLayer
{
    public class Room
    {

        public Guid Id { get; private set; }
        public Guid CourseId { get; private set; }

        public Room (Guid Id, Guid CourseId) {
            this.Id = Id;
            this.CourseId = CourseId;
        }
    }
}
