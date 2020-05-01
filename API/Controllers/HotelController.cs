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

        private readonly IHotelService HotelService;
        
        public HotelController(IHotelService _HotelService) {
            HotelService = _HotelService;
        }

        [HttpGet, Route("api/Hotel/")]
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotels()));
            } catch {
                return InternalServerError();
            }
        }

        [HttpGet, Route("api/Hotel/{id}")]
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotelById(id)));
            } catch {
                return InternalServerError();
            }
        }

        [HttpPost, Route("api/Hotel/Add/")]
        public IHttpActionResult Post(HotelModel hotel) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.AddHotel(hotel)));
            } catch {
                return InternalServerError();
            }
        }

        [HttpDelete, Route("api/Hotel/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.DeleteHotel(id)));
            } catch {
                return InternalServerError();
            }
        }

    }

}