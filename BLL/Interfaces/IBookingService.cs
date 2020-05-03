using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IBookingService {
        
        List<BookingModel> GetBookings();
        List<BookingModel> GetBookings(Nullable<DateTime> date, int? roomId, int? hotelId);
        BookingModel GetBooking(int id);
        bool AddBooking(BookingModel booking);
        bool UpdateBooking(BookingModel booking);
        bool DeleteBooking(int id);

    }

}