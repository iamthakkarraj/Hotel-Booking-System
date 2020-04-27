using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories {

    public class BookingRepository : IBookingRepository {

        private WebApiAssignmentEntities DBContext;

        public BookingRepository(WebApiAssignmentEntities _DBContext) {
            DBContext = _DBContext;
        }

        public bool AddBooking() {
            throw new NotImplementedException();
        } 

        public bool UpdateBooking() {
            throw new NotImplementedException();
        }

    }

}