using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {

    public interface IBookingRepository {

        bool AddBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool RemoveBooking(int id);
        List<Booking> GetBookings();
        Booking GetBooking(int id);        

    }

}