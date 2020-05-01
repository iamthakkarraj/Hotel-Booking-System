using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models {

    public class BookingModel {
        
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int Status { get; set; }

    }

    public static class BookingStatus {

        public static readonly string STATUS_DEFAULT= "Optional";
        public static readonly string STAUTS_DEFINITIVE = "Definitive";
        public static readonly string STATUS_CANCELLED = "Cancelled";
        public static readonly string STATUS_DELETED = "Delted";

        /// <summary>
        /// Returns Status Of the Room
        /// Returns Deafult Status When 0 Is Passed As An ID.
        /// </summary>
        /// <param name="id">Id of The Status </param>
        /// <returns>Status of The Room</returns>
        public static string GetBookingStatus(int id) {
            switch (id) {
                case 1:
                    return STAUTS_DEFINITIVE;
                case 2:
                    return STATUS_CANCELLED;
                case 3:
                    return STATUS_DELETED;
                default:
                    return STATUS_DEFAULT;
            }
        }

    }

}