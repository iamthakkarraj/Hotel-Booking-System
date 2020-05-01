using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories {

    public class BookingRepository : IBookingRepository {

        public const int STATUS_DEFAULT = 0;
        public const int STAUTS_DEFINITIVE = 1;
        public const int STATUS_CANCELLED = 2;
        public const int STATUS_DELETED = 3;

        private readonly WebApiAssignmentEntities DBContext;

        public BookingRepository(WebApiAssignmentEntities _DBContext) {
            DBContext = _DBContext;
        }

        public bool AddBooking(Booking booking) {
            try {
                DBContext.Bookings.Add(booking);
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool UpdateBooking(Booking booking) {
            try {
                DBContext.Entry(booking).State = EntityState.Modified;
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool RemoveBooking(int id) {
            try {
                DBContext.Bookings.Attach(DBContext.Bookings.Where(x => x.BookingId == id).FirstOrDefault()).Status = STATUS_DELETED;
                DBContext.SaveChanges();
                return true;
            }catch(Exception e) {
                return false;
            }
        }

        public Booking GetBooking(int id) {
            return DBContext.Bookings.Where(x => x.BookingId == id).Where(x => x.Status != STATUS_DELETED).FirstOrDefault();
        }

        public List<Booking> GetBookings() {
            return DBContext.Bookings.OrderBy(x => x.BookingDate).Where(x => x.Status != STATUS_DELETED).ToList();
        }

        public bool SaveChanges() {
            try { DBContext.SaveChanges(); return true; } catch { return false; }
        }

    }

}