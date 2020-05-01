using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers {

    public class BookingController : ApiController {

        private readonly IBookingService BookingService;

        public BookingController(IBookingService _BookingService) {
            this.BookingService = _BookingService;
        }

        [Route("api/Booking/Get/")]
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.GetBookings()));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Booking/Get/{int:id}")]
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.GetBooking(id)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Booking/Add/")]
        public IHttpActionResult Post(BookingModel booking) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.AddBooking(booking)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Booking/{id:int}/setDate/{datetime:bookingDate}")]
        public IHttpActionResult Put(int id, DateTime bookingDate){
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.UpdateBookingDate(id, bookingDate)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Booking/{id:int}/setStatus/{int:statusId}")]
        public IHttpActionResult Put(int id, int statusId) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.UpdateBookingStatus(id, statusId)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Booking/Delete/{id:int}")]
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, BookingService.RemoveBooking(id)));
            } catch {
                return InternalServerError();
            }
        }

    }

}