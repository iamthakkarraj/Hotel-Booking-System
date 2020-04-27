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

        IRoomService RoomService;

        public RoomController(IRoomService _RoomService) {
            RoomService = _RoomService;
        }

        // GET: api/Room
        public IHttpActionResult Get() {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.GetRooms());
            } catch {
                return InternalServerError();
            }
        }

        // GET: api/Room/5
        public IHttpActionResult Get(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.GetRoomById(id)));
            } catch {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(string city, string pincode, int? price, int? category) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.SearchRoom(city, pincode, price, category)));
            } catch {
                return InternalServerError();
            }
        }

        public IHttpActionResult GetAvailibility(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.IsAvailable(id)));
            } catch {
                return InternalServerError();
            }
        }

        // POST: api/Room
        public IHttpActionResult Post(RoomModel room) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.AddRoom(room)));
            } catch {
                return InternalServerError();
            }
        }

        // DELETE: api/Room/5
        public IHttpActionResult Delete(int id) {
            try {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, RoomService.DeleteRoom(id)));
            } catch {
                return InternalServerError();
            }
        }

    }

}