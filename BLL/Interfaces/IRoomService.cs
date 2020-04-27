using Common.Models;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IRoomService {

        Boolean AddRoom(RoomModel room);
        Boolean UpdateRoom(RoomModel room);
        Boolean DeleteRoom(int id);
        List<RoomModel> GetRooms();
        List<RoomModel> SearchRoom(string city, string pincode, int? price, int? category);
        RoomModel GetRoomById(int id);        
        Boolean IsAvailable(int id);

    }

}