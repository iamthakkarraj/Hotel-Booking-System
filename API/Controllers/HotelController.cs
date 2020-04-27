using BLL.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers {

    public class HotelController : ApiController {

        private IHotelService HotelService;

        public HotelController() {

        }

        public HotelController(IHotelService _HotelService) {
            HotelService = _HotelService;
        }

        // GET: api/Hotel
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotels()));
            } catch {
                return InternalServerError();
            }
        }

        // GET: api/Hotel/5
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotelById(id)));
            } catch {
                return InternalServerError();
            }
        }

        // POST: api/Hotel
        public IHttpActionResult Post(HotelModel hotel) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.AddHotel(hotel)));
            } catch {
                return InternalServerError();
            }
        }

        // DELETE: api/Hotel/5
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.DeleteHotel(id)));
            } catch {
                return InternalServerError();
            }
        }

    }

}