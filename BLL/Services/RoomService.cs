using BLL.Interfaces;
using Common.Models;
using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {

    public class RoomService : IRoomService {

        private readonly IRoomRepository RoomRepository;

        public RoomService(IRoomRepository _RoomRepository) {
            RoomRepository = _RoomRepository;
        }

        public bool AddRoom(RoomModel room) {
            return RoomRepository.AddRoom(ModelMapperService.Map<RoomModel, Room>(room));
        }

        public bool DeleteRoom(int id) {
            return RoomRepository.DeleteRoom(id);
        }

        public bool UpdateRoom(RoomModel room) {
            throw new NotImplementedException();
        }

        public List<RoomModel> GetRooms() {
            List<Room> source = RoomRepository.GetRoomsQueryable().OrderBy(x => x.Price).ToList();
            List<RoomModel> destination = new List<RoomModel>();
            foreach (Room room in source) {
                destination.Add(ModelMapperService.Map<Room, RoomModel>(room));
            }
            return destination;
        }

        public RoomModel GetRoomById(int id) {
            return ModelMapperService.Map<Room, RoomModel>(RoomRepository.GetRoomById(id));
        }        

        public bool IsAvailable(int id) {
            return RoomRepository.IsAvailable(id);
        }

        public List<RoomModel> SearchRoom(string city, string pincode, int? price, int? category) {
            List<RoomModel> destination = new List<RoomModel>();
            IQueryable<Room> query = RoomRepository.GetRoomsQueryable().OrderBy(x => x.Price);            
            if (city != null) 
                query = query.Where(x => x.Hotel.City == city);
            if (pincode != null) 
                query = query.Where(x => x.Hotel.PinCode == pincode);
            if (price != null) 
                query = query.Where(x => x.Price == price);
            if (category != null) 
                query = query.Where(x => x.Category == category);                        
            foreach(Room room in query.ToList()) {
                destination.Add(ModelMapperService.Map<Room, RoomModel>(room));
            }
            return destination;
        }
        
    }

}