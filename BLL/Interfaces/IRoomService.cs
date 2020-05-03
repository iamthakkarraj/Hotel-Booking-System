using Common.Models;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IRoomService {
        
        List<RoomModel> GetRooms();
        List<RoomModel> GetRooms(string city, string pincode, int? price, int? category);
        RoomModel GetRoomById(int id);
        bool AddRoom(RoomModel room);
        bool UpdateRoom(RoomModel room);
        bool DeleteRoom(int id);
        bool IsAvailable(int id);

    }

}