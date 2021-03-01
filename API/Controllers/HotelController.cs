using BLL.Interfaces;
using Common.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers {

    [BasicAuthFilter]
    public class HotelController : ApiController {

        private readonly IHotelService HotelService;
        
        public HotelController(IHotelService _HotelService) {
            HotelService = _HotelService;
        }

        [HttpGet, Route("api/Hotel/")]
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotels()));
            } catch(Exception e) {
                return InternalServerError();
            }
        }

        [HttpGet, Route("api/Hotel/{id}")]
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotelById(id)));
            } catch (Exception e) {
                return InternalServerError();
            }
        }

        [HttpGet, Route("api/Hotel/Search")]
        public IHttpActionResult Get(string name=null, string city=null, string pincode=null) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.GetHotels(name, city, pincode)));
            } catch (Exception e) {
                return InternalServerError();
            }
        }

        [HttpPost, Route("api/Hotel/Add/")]
        public IHttpActionResult Post(HotelModel hotel) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.AddHotel(hotel)));
            } catch (Exception e) {
                return InternalServerError();
            }
        }
        
        [HttpPut, Route("api/Hotel/Update/")]
        public IHttpActionResult Put(HotelModel hotel) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.UpdateHotel(hotel)));
            } catch (Exception e) {
                return InternalServerError();
            }
        }

        [HttpDelete, Route("api/Hotel/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, HotelService.DeleteHotel(id)));
            } catch (Exception e) {
                return InternalServerError();
            }
        }

    }

}