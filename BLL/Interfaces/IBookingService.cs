using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IBookingService {

        bool AddBooking(BookingModel booking);
        bool UpdateBookingDate(int id, DateTime bookingDate);
        bool UpdateBookingStatus(int id,int statusId);
        bool RemoveBooking(int id);
        List<BookingModel> GetBookings();
        BookingModel GetBooking(int id);

    }

}
