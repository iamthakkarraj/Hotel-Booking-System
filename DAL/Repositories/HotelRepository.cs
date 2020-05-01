using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories {

    public class HotelRepository : IHotelRepository {

        private readonly WebApiAssignmentEntities DBContext;

        public HotelRepository() {
            DBContext = new WebApiAssignmentEntities();
        }

        /// <summary>
        /// Add hotel by id
        /// </summary>
        /// <param name="hotel">Object of hotel</param>
        /// <returns>boolean</returns>
        public bool AddHotel(Hotel hotel) {
            try {
                DBContext.Hotels.Add(hotel);
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Delete hotel by id
        /// </summary>
        /// <param name="id">Unique id of hotel</param>
        /// <returns>boolean</returns>
        public bool DeleteHotel(int id) {
            try {
                DBContext.Hotels.Remove(DBContext.Hotels.Where(x => x.HotelId == id).FirstOrDefault());
                DBContext.SaveChanges();
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        /// <summary>
        /// Returns the list of hotel ordered by hotel name
        /// </summary>
        /// <returns>List<Hotel></returns>
        public List<Hotel> GetHotels() {
            return DBContext.Hotels.OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Get hotel by primary key
        /// </summary>
        /// <param name="id">Unique id of each hotel</param>
        /// <returns>Hotel</returns>
        public Hotel GetHotelById(int id) {
            return DBContext.Hotels.Where(x => x.HotelId == id).FirstOrDefault();
        }

        /// <summary>
        /// Get hotel by city name
        /// </summary>
        /// <param name="city">Name of city</param>
        /// <returns>List<Hotel></returns>
        public List<Hotel> GetHotelByCity(string city) {
            return DBContext.Hotels.Where(x => x.City == city).ToList();            
        }        

        /// <summary>
        /// Get hotel by pincode
        /// </summary>
        /// <param name="pincode">Pincode</param>
        /// <returns>List<Hotel></returns>
        public List<Hotel> GetHotelByPincode(string pincode) {
            return DBContext.Hotels.Where(x => x.PinCode == pincode).ToList();
        }
        
    }

}