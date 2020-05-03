using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {

    public interface IRoomRepository {

        IQueryable<Room> GetQueryable();
        Room GetRoomById(int id);
        bool AddRoom(Room room);
        bool UpdateRoom(Room room);
        bool DeleteRoom(int id);        
        bool IsAvailable(int id); 

    }

}