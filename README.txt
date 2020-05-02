✔ Layering
   |===>| DAL 	 (Data Access Layer)
	| BLL 	 (Buisness Logic Layer)
        | Common (ViewModels)
        | API	 (Application Programming Interface)

✔ Dependancy Injection
    |===>| BLL (Injecting Dependancy of Repository Classes From DAL)
	 | API (Injecting Dependancy of Service Classes From BLL)

✔ Model Mapping
   |===>| Using Model Mapper Service From BLL to Map Data Models With View Models

✔ Attribute Routing 

✔ Only JSON Response 

✔ CORS Enabled

✔ Basic Authentication Using Username And Password

==================
 DAL LAYER (Rooms)
==================
✔ IRoomRepository
✔ RoomRepository
   |===>| Add(room)
       ✔| Update(room)
       ✔| Remove(id)
       ✔| Get(id)
       ✔| GetRooms()
       ✔| GetRoomsQueryable()
       ✔| IsAvailable(id)
=======================
    BLL LAYER (Rooms)
=======================
	✔ IRoomService
	✔ RoomServicce
	   |===>| Add(room)
               ✔| Update(room)
	       ✔| Remove(id)
	       ✔| Get(id)
	       ✔| GetRooms()
	       ✔| SearchRoom(city, pincode, price, category)
	       ✔| IsAvailable(id)
================================
       API LAYER (Rooms)
================================
		✔ RoomController
		   |===>| Get()
		       ✔| Get(id)
  		       ✔| Get(city, pincode, price, category)
 		       ✔| Post(room)
		       ✔| Delete(id)
 		       ✔| IsAvailable(id)

==================
 DAL LAYER (Hotel)
==================
✔ IHotelRepository
✔ HotelRepository
   |===>| Add(hotel)
      ✔| Update(hotel)
      ✔| Remove(id)
      ✔| Get(id)
      ✔| GetHotels()
        | GetHotelsQueryable() !!
=======================
    BLL LAYER (Hotel)
=======================
	✔ IHotelService
	✔ HotelServicce
	   |===>| Add(Hotel)
	      ✔| Update(Hotel)
	      ✔| Remove(id)
	      ✔| Get(id)
	      ✔| GetHotels()
	        | SearchHotel(city, pincode) !!
================================
       API LAYER (Hotel)
================================
		✔ HotelController
		   |===>| Get()
		      ✔| Get(id)
		      ✔| Get(city,pincode) !!
		      ✔| Post(Hotel)
		      ✔| Delete(id)

=====================
 DAL LAYER (Booking)
=====================
✔ IBookingRepository
✔ BookingRepository
   |===>| Add(Booking)
       ✔| Update(Booking)
       ✔| Remove(id)
       ✔| Get(id)
       ✔| GetBookings()
=======================
  BLL LAYER (Booking)
=======================
	✔ IBookingService
	✔ BookingServicce
	   |===>| Add(Booking)
               ✔| UpdateBookingDate(id,date)
	       ✔| UpdateBookingStatus(id,status)
	       ✔| Remove(id)
	       ✔| Get(id)
	       ✔| GetBookings()
================================
      API LAYER (Booking)
================================
		✔ BookingController
		   |===>| Get()
		       ✔| Get(id)
		       ✔| Post(Booking)
	               ✔| Put(id,date)
		       ✔| put(id,status)
		       ✔| Delete(id)

==================
Status of bookings
==================
0. Optional (Default)
1. Definitive
2. Cancelled
3. Deleted 

==================
Cateogires of Room
==================
0. Basic
1. Categories 1	size <35 m2
2. Categories 2	size 36-50 m2
3. Categories 3	size 51-100 m2
