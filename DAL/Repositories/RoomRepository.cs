using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories {

    public class RoomRepository : IRoomRepository {

        public const int CATEGORY_1 = 1;
        public const int CATEGORY_2 = 2;
        public const int CATEGORY_3 = 3;
        public const int CATEGORY_DEFAULT = 0;

        private readonly WebApiAssignmentEntities DBContext;
        public RoomRepository() {
            DBContext = new WebApiAssignmentEntities();
        }

        /// <summary>
        /// Add a new room
        /// </summary>
        /// <param name="room">Object of room</param>
        /// <returns>Boolean</returns>
        public bool AddRoom(Room room) {
            try {
                DBContext.Rooms.Add(room);
                DBContext.SaveChanges();
                return true;
            }catch {
                return false;
            }
        }

        /// <summary>
        /// Update the existing room
        /// </summary>
        /// <param name="room">Object of room</param>
        /// <returns>Boolean</returns>
        public bool UpdateRoom(Room room) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified room
        /// </summary>
        /// <param name="id">Id of the room</param>
        /// <returns>Boolean</returns>
        public bool DeleteRoom(int id) {
            try {
                DBContext.Rooms.Remove(DBContext.Rooms.Where(x =>  x.RoomId == id).FirstOrDefault());
                DBContext.SaveChanges();
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        /// <summary>
        /// Get room by id
        /// </summary>
        /// <param name="id">Id of the room</param>
        /// <returns>Room</returns>
        public Room GetRoomById(int id) {            
            return DBContext.Rooms.Where(x => x.RoomId == id).FirstOrDefault();
        }
        
        /// <summary>
        /// Returns a list of room matching to the searching parameters
        /// in case of null parameters rooms will be sorted by price low to high
        /// </summary>
        /// <param name="city">Name of city</param>
        /// <param name="pincode">Pincode</param>
        /// <param name="price">Price</param>
        /// <param name="category">Category</param>
        /// <returns>List<Room></returns>
        public IQueryable<Room> GetRoomsQueryable() {
            return DBContext.Rooms;
        }

        /// <summary>
        /// Check if room is available or not
        /// </summary>
        /// <param name="id">id of the room</param>
        /// <returns>Boolean</returns>
        public bool IsAvailable(int id) {            
            return (0 == DBContext.Bookings                    
                        .Where(x => x.RoomId == id)
                        .Where(x => x.Status != BookingRepository.STATUS_DELETED)
                        .Where(x => x.Status != BookingRepository.STATUS_CANCELLED)
                        .Count()) ? true : false;
        }   

    }

}