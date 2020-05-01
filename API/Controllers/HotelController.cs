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

        public HotelController() {

        }

        public HotelController(IHotelService _HotelService) {
            HotelService = _HotelService;
        }

        [Route("api/Hotel/Get/")]
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotels()));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Hotel/Get/{id:int}")]
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotelById(id)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Hotel/Add/")]
        public IHttpActionResult Post(HotelModel hotel) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.AddHotel(hotel)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Hotel/Delete/{id:int}")]
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.DeleteHotel(id)));
            } catch {
                return InternalServerError();
            }
        }

    }

}