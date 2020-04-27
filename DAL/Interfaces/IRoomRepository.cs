using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {

    public interface IRoomRepository {
                                
        Boolean AddRoom(Room room);
        Boolean UpdateRoom(Room room);
        Boolean DeleteRoom(int id);
        List<Room> GetRooms();
        List<Room> SearchRoom(string city, string pincode, int? price, int? category);
        Room GetRoomById(int id);        
        Boolean IsAvailable(int id);

    }

}