using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {

    public interface IBookingRepository {

        IQueryable<Booking> GetQueryable();
        Booking GetBooking(int id);
        bool AddBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int id);           

    }

}