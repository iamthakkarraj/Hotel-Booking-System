using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models {
        
    public class RoomModel {
        
        public int RoomId { get; set; }
        public Nullable<int> HotelId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public int UploadedBy { get; set; }

    }

    public static class RoomCategories {

        public static readonly string CATEGORY_1 = "size <35 m2";
        public static readonly string CATEGORY_2 = "size 36-50 m2";
        public static readonly string CATEGORY_3 = "size 51-100 m2";
        public static readonly string CATEGORY_DEFAULT = "Basic";
        
        /// <summary>
        /// Returns Category of Room By Category Id.
        /// Returns Default Category When 0 Is Passed As An Id.
        /// </summary>
        /// <param name="id">Id of The Category</param>
        /// <returns>Returns Category</returns>
        public static string GetRoomCatgory(int id) {
            switch (id) {
                case 1:
                    return CATEGORY_1;
                case 2:
                    return CATEGORY_2;
                case 3:
                    return CATEGORY_3;
                default:
                    return CATEGORY_DEFAULT;
            }
        }       

    }

}
