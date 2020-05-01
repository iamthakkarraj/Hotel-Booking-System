using BLL.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers {
    public class RoomController : ApiController {

        private readonly IRoomService RoomService;

        public RoomController(IRoomService _RoomService) {
            RoomService = _RoomService;
        }
        
        [Route("api/Room/")]
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.GetRooms()));
            } catch {
                return InternalServerError();
            }
        }
        
        [Route("api/Room/{id:int}")]
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.GetRoomById(id)));
            } catch {
                return InternalServerError();
            }
        }
        
        [Route("api/Room/{city:string}/{pincode:string}/{price:?int}/category:?int")]
        public IHttpActionResult Get(string city, string pincode, int? price, int? category) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.SearchRoom(city, pincode, price, category)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Room/{id:int}/IsAvailable")]
        public IHttpActionResult GetAvailibility(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.IsAvailable(id)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Room/Add")]
        public IHttpActionResult Post(RoomModel room) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.AddRoom(room)));
            } catch {
                return InternalServerError();
            }
        }

        [Route("api/Room/Delete/{id:int}")]
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.DeleteRoom(id)));
            } catch {
                return InternalServerError();
            }
        }

    }

}