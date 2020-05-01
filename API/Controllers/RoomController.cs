using BLL.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers {

    [BasicAuthentication]
    public class RoomController : ApiController {

        private readonly IRoomService RoomService;

        public RoomController(IRoomService _RoomService) {
            RoomService = _RoomService;
        }
        
        [HttpGet, Route("api/Room/")]
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.GetRooms()));
            } catch {
                return InternalServerError();
            }
        }
        
        [HttpGet, Route("api/Room/{id}")]
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.GetRoomById(id)));
            } catch {
                return InternalServerError();
            }
        }
        
        [HttpGet, Route("api/Room/Search")]
        public IHttpActionResult Get(int? price = null, int? category = null, string city = null, string pincode = null) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.SearchRoom(city, pincode, price, category)));
            } catch {
                return InternalServerError();
            }
        }

        [HttpGet, Route("api/Room/IsAvailable/{id}")]
        public IHttpActionResult GetAvailibility(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.IsAvailable(id)));
            } catch {
                return InternalServerError();
            }
        }

        [HttpPost, Route("api/Room/Add")]
        public IHttpActionResult Post(RoomModel room) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.AddRoom(room)));
            } catch {
                return InternalServerError();
            }
        }

        [HttpDelete, Route("api/Room/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.DeleteRoom(id)));
            } catch {
                return InternalServerError();
            }
        }

    }

}