using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IHotelService {
        
        List<HotelModel> GetHotels();
        List<HotelModel> GetHotels(string name, string city, string pincode);
        HotelModel GetHotelById(int id);        
        bool AddHotel(HotelModel hotel);
        bool DeleteHotel(int id);
        bool UpdateHotel(HotelModel hotel);

    }

}