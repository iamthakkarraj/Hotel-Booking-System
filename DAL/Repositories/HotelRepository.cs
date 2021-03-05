using DAL.Database;
using DAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories {

    public class HotelRepository : IHotelRepository {

        private readonly WebApiAssignmentEntities _DBContext;
        

        public HotelRepository() {
            _DBContext = new WebApiAssignmentEntities();
            
        }

        public IQueryable<Hotel> GetQueryable() {
            return _DBContext.Hotels;
        }

        public Hotel GetHotelById(int id) {
            return _DBContext.Hotels
                    .Where(x => x.HotelId == id)
                    .FirstOrDefault();
        }

        public bool AddHotel(Hotel hotel) {
            try {
                _DBContext.Hotels.Add(hotel);
                _DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool DeleteHotel(int id) {
            try {
                _DBContext.Hotels
                    .Remove(
                        _DBContext.Hotels
                        .Where(x => x.HotelId == id)
                        .FirstOrDefault());
                _DBContext.SaveChanges();
                return true;
            } catch (Exception e) {
                return false;
            }
        }
        public bool UpdateHotel(Hotel hotel) {
            try {
                _DBContext.Entry(hotel).State = EntityState.Modified;
                _DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

    }

}