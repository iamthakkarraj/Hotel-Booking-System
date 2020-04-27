using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IHotelService {

        Boolean AddHotel(HotelModel hotel);
        Boolean DeleteHotel(int id);
        List<HotelModel> GetHotels();
        HotelModel GetHotelById(int id);
        List<HotelModel> GetHotelByCity(string city);
        List<HotelModel> GetHotelByPincode(string pincode);        

    }

}