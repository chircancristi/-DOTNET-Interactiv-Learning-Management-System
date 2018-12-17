using System;
using System.Linq;

namespace BusinessLayer
{
    class RoomRepository
    {
        public UnitOfWork unitOfWork;

        public RoomRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        void CreateRoom(DataLayer.Room room)
        {
            unitOfWork.RoomRepository.Add(room);
        }

        void RemoveRoomByItsId(Guid Id)
        {
            var room = unitOfWork.RoomRepository.Entities.First(a => a.Id == Id);
            unitOfWork.RoomRepository.Remove(room);
            unitOfWork.Commit();
        }
    }
}
