using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories {

    public class HotelRepository : IHotelRepository {

        private readonly WebApiAssignmentEntities DBContext;

        public HotelRepository() {
            DBContext = new WebApiAssignmentEntities();
        }

        public IQueryable<Hotel> GetQueryable() {
            return DBContext.Hotels;
        }        
        public Hotel GetHotelById(int id) {
            return DBContext.Hotels.Where(x => x.HotelId == id).FirstOrDefault();
        }        
        public bool AddHotel(Hotel hotel) {
            try {
                DBContext.Hotels.Add(hotel);
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }        
        public bool DeleteHotel(int id) {
            try {
                DBContext.Hotels.Remove(DBContext.Hotels.Where(x => x.HotelId == id).FirstOrDefault());
                DBContext.SaveChanges();
                return true;
            } catch (Exception e) {
                return false;
            }
        }                
        public bool UpdateHotel(Hotel hotel) {
            try {
                DBContext.Entry(hotel).State = EntityState.Modified;
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

    }

}