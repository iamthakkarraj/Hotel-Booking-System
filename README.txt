
[Find The Documentation Here](https://iamthakkarraj.github.io/WebApiAssignment/)

✔ Layering (DAL, BLL, Common, API)    
✔ Dependancy Injection    
✔ Model Mapping   
✔ Attribute Routing 
✔ Only JSON Response 
✔ CORS Enabled
✔ Basic Authentication Using Username And Password
✔ Swagger API Implementation
✔ Authentication Support in SwaggerUI

==================
Functions In Hotel
==================
    ◾ GetList
    ◾ Search (name, city, pincode)    
    ◾ GetById (id)
    ◾ Add (hotelModel)
    ◾ Update (hotelModel)
    ◾ Delete (id)
    
=================
Functions In Room
=================
    ◾ GetList
    ◾ Search (price, category, city ,pincode)    
    ◾ GetById (id)
    ◾ Add (roomModel)
    ◾ Update (roomModel)
    ◾ Delete (id)
    
====================
Functions In Booking
====================
    ◾ GetList
    ◾ Search (roomId, hotelId, date)    
    ◾ GetById (id)
    ◾ Add (bookingModel)
    ◾ Update (bookingModel)
    ◾ Delete (id)       


(Status of bookings)
==================
id | Value
==================
0  | Optional (Default)
1  | Definitive
2  | Cancelled
3  | Deleted 

(Cateogires of Room)
==================
id | Value
==================
0  | Basic (Deafult)
1  | Categories 1 (size <35 m2)
2  | Categories 2 (size 36-50 m2)
3  | Categories 3 (size 51-100 m2)

==================
Layering Structure 
==================

=================
 DAL LAYER (Rooms)
==================
✔ IRoomRepository
✔ RoomRepository
   |===> |      
       ✔| GetQueryable()
       ✔| Add(room)
       ✔| Update(room)
       ✔| Delete(id)       
       ✔| IsAvailable(id)
=======================
    BLL LAYER (Rooms)
=======================
	✔ IRoomService
	✔ RoomServicce
	   |===> |          	       
	       ✔| GetRooms()
	       ✔| SearchRoom(city, pincode, price, category)
               ✔| Get(id)	       
               ✔| Add(room)
               ✔| Update(room)
	       ✔| Remove(id)
               ✔| IsAvailable(id)
================================
       API LAYER (Rooms)
================================
		✔ RoomController
		   |===> |
                       ✔| Get()
		       ✔| Get(id)
  		       ✔| Get(city, pincode, price, category)
 		       ✔| Post(room)
                       ✔| Put(room)
		       ✔| Delete(id)
 		       ✔| IsAvailable(id)

==================
 DAL LAYER (Hotel)
==================
✔ IHotelRepository
✔ HotelRepository
   |===> |
       ✔| GetQueryable()
       ✔| Add(room)
       ✔| Update(room)
       ✔| Delete(id)     
=======================
    BLL LAYER (Hotel)
=======================
	✔ IHotelService
	✔ HotelServicce
	   |===>|          
	      ✔| Get(id)
	      ✔| GetHotels()
	      ✔| SearchHotel(name, city, pincode)
              ✔| Add(hotelModel)
	      ✔| Update(hotelModel)
	      ✔| Delete(id)
================================
       API LAYER (Hotel)
================================
		✔ HotelController
		   |===>| 
                      ✔| Get()
		      ✔| Get(id)
		      ✔| Get(name, city, pincode)
		      ✔| Post(hotelModel)
                      ✔| Put(hotelModel)
		      ✔| Delete(id)

=====================
 DAL LAYER (Booking)
=====================
✔ IBookingRepository
✔ BookingRepository
   |===> |
       ✔| GetQueryable()
       ✔| Add(booking)
       ✔| Update(booking)
       ✔| Delete(id)     
=======================
  BLL LAYER (Booking)
=======================
	✔ IBookingService
	✔ BookingServicce
	   |===> |
	       ✔| Get(id)
	       ✔| GetBookings()           
               ✔| Search(date, hotelId, roomId)           	       
               ✔| Add(bookingModel)
               ✔| Update(bookingModel)
	       ✔| Delete(id)
================================
      API LAYER (Booking)
================================
		✔ BookingController
		   |===>|
                      ✔| Get()
		      ✔| Get(id)
                      ✔| Get(date, hotelId, roomId)
		      ✔| Post(bookingModel)
	              ✔| Put(bookingModel)
		      ✔| Delete(id)
