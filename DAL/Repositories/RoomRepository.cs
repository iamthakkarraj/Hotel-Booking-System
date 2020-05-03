using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IQueryable<Room> GetQueryable() {
            return DBContext.Rooms;
        }        
        public Room GetRoomById(int id) {
            return DBContext.Rooms.Where(x => x.RoomId == id).FirstOrDefault();
        }        
        public bool AddRoom(Room room) {
            try {
                DBContext.Rooms.Add(room);
                DBContext.SaveChanges();
                return true;
            }catch {
                return false;
            }
        }        
        public bool UpdateRoom(Room room) {
            try {
                DBContext.Entry(room).State = EntityState.Modified;
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }        
        public bool DeleteRoom(int id) {
            try {
                DBContext.Rooms.Remove(DBContext.Rooms.Where(x =>  x.RoomId == id).FirstOrDefault());
                DBContext.SaveChanges();
                return true;
            } catch (Exception e) {
                return false;
            }
        }                
        public bool IsAvailable(int id) {
            return (0 == DBContext.Bookings
                        .Where(x => x.RoomId == id)
                        .Where(x => x.Status != BookingRepository.STATUS_DELETED)
                        .Where(x => x.Status != BookingRepository.STATUS_CANCELLED)
                        .Count()) ? true : false;
        }

    }

}