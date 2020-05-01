using BLL.Interfaces;
using Common.Models;
using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {

    public class BookingService : IBookingService {

        private readonly IBookingRepository BookingRepository;

        public BookingService(IBookingRepository _BookingRepository) {
            this.BookingRepository = _BookingRepository;
        }

        public bool AddBooking(BookingModel booking) {
            return BookingRepository.AddBooking(ModelMapperService.Map<BookingModel,Booking>(booking));
        }

        public BookingModel GetBooking(int id) {
            return ModelMapperService.Map<Booking, BookingModel>(BookingRepository.GetBooking(id));
        }

        public List<BookingModel> GetBookings() {
            List<Booking> source = BookingRepository.GetBookings();
            List<BookingModel> destination = new List<BookingModel>();
            foreach(Booking booking in source) {
                destination.Add(ModelMapperService.Map<Booking, BookingModel>(booking));
            }
            return destination;
        }

        public bool RemoveBooking(int id) {
            return BookingRepository.RemoveBooking(id);
        }

        public bool UpdateBookingDate(int id,DateTime bookingDate) {
            Booking booking = BookingRepository.GetBooking(id);
            booking.BookingDate = bookingDate;
            return BookingRepository.UpdateBooking(booking);
        }

        public bool UpdateBookingStatus(int id, int statusId) {
            Booking booking = BookingRepository.GetBooking(id);
            booking.Status = statusId;
            return BookingRepository.UpdateBooking(booking);
        }

    }

}