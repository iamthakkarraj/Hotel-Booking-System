using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {

    public interface IHotelRepository {
        
        IQueryable<Hotel> GetQueryable();
        Hotel GetHotelById(int id);        
        bool AddHotel(Hotel hotel);
        bool UpdateHotel(Hotel hotel);
        bool DeleteHotel(int id);        

    }

}