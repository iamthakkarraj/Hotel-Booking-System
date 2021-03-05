using BLL.CacheManager.ServiceStack;
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
        private readonly RedisManager _redisManager;

        public BookingService(IBookingRepository _BookingRepository) {
            this.BookingRepository = _BookingRepository;
            _redisManager = new RedisManager();
        }
        
        public List<BookingModel> GetBookings() {            
            var cachedData = this._redisManager.GetList<BookingModel>().ToList();
            if (cachedData == null || !cachedData.Any())
            {
                List<Booking> source = BookingRepository.GetQueryable().OrderBy(x => x.BookingDate).ToList();
                List<BookingModel> destination = new List<BookingModel>();
                foreach (Booking booking in source)
                {
                    destination.Add(ModelMapperService.Map<Booking, BookingModel>(booking));
                }
                this._redisManager.SetList<BookingModel>(destination);  
                return destination;
            }
            else
            {
                return cachedData;
            }
        }
        public List<BookingModel> GetBookings(Nullable<DateTime> date, int? roomId, int? hotelId) {
            List<BookingModel> destination = new List<BookingModel>();
            IQueryable<Booking> query = BookingRepository.GetQueryable().OrderBy(x => x.BookingDate);
            if (roomId != null)
                query = query.Where(x => x.RoomId == roomId);
            if (hotelId != null)
                query = query.Where(x => x.Room.HotelId == hotelId);
            if (date != null)
                query = query.Where(x => x.BookingDate == date);            
            foreach (Booking booking in query.ToList()) {
                destination.Add(ModelMapperService.Map<Booking, BookingModel>(booking));
            }
            return destination;
        }
        public BookingModel GetBooking(int id) {
            return ModelMapperService.Map<Booking, BookingModel>(BookingRepository.GetBooking(id));
        }
        public bool AddBooking(BookingModel booking) {
            return BookingRepository.AddBooking(ModelMapperService.Map<BookingModel,Booking>(booking));
        }
        public bool UpdateBooking(BookingModel booking) {
            return BookingRepository.UpdateBooking(ModelMapperService.Map<BookingModel, Booking>(booking));
        }
        public bool DeleteBooking(int id) {
            return BookingRepository.DeleteBooking(id);
        }

    }

}