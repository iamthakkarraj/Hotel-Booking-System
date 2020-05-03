using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers {

    [BasicAuthFilter]
    public class BookingController : ApiController {

        private readonly IBookingService BookingService;

        public BookingController(IBookingService _BookingService) {
            this.BookingService = _BookingService;
        }

        [HttpGet, Route("api/Booking")]
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.GetBookings()));
            } catch {
                return InternalServerError();
            }
        }

        [HttpGet, Route("api/Booking/{id}")]
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.GetBooking(id)));
            } catch {
                return InternalServerError();
            }
        }

        [HttpGet, Route("api/Booking/Search")]
        public IHttpActionResult Get(Nullable<DateTime> date = null, int? roomId = null, int? hotelId=null) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.GetBookings(date, roomId, hotelId)));
            } catch {
                return InternalServerError();
            }
        }

        [HttpPost, Route("api/Booking/Add")]
        public IHttpActionResult Post(BookingModel booking) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.AddBooking(booking)));
            } catch {
                return InternalServerError();
            }
        }

        [HttpPut, Route("api/Booking/Update/")]
        public IHttpActionResult Put(BookingModel booking){
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.UpdateBooking(booking)));
            } catch {
                return InternalServerError();
            }
        }
        
        [HttpDelete, Route("api/Booking/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.DeleteBooking(id)));
            } catch {
                return InternalServerError();
            }
        }

    }

}