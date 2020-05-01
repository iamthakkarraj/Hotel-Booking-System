using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {

    public interface IHotelRepository {

        List<Hotel> GetHotels();
        Hotel GetHotelById(int id);
        List<Hotel> GetHotelByCity(string city);
        List<Hotel> GetHotelByPincode(string pincode);
        bool AddHotel(Hotel hotel);
        bool DeleteHotel(int id);        

    }

}