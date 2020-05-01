using BLL.Interfaces;
using Common.Models;
using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {

    public class HotelService : IHotelService {

        readonly IHotelRepository HotelRepository;

        public HotelService(IHotelRepository _HotelRepository) {
            HotelRepository = _HotelRepository;
        }

        public bool AddHotel(HotelModel hotel) {
            return HotelRepository.AddHotel(ModelMapperService.Map<HotelModel, Hotel>(hotel));
        }

        public bool DeleteHotel(int id) {
            return HotelRepository.DeleteHotel(id);
        }

        public List<HotelModel> GetHotels() {

            List<Hotel> source = HotelRepository.GetHotels();
            List<HotelModel> destination = new List<HotelModel>();

            foreach (Hotel hotel in source) {
                destination.Add(ModelMapperService.Map<Hotel, HotelModel>(hotel));
            }

            return destination;

        }

        public HotelModel GetHotelById(int id) {
            return ModelMapperService.Map<Hotel,HotelModel>(HotelRepository.GetHotelById(id));
        }

        public List<HotelModel> GetHotelByCity(string city) {
            List<Hotel> source = HotelRepository.GetHotelByCity(city);
            List<HotelModel> destination = new List<HotelModel>();

            foreach (Hotel hotel in source) {
                destination.Add(ModelMapperService.Map<Hotel, HotelModel>(hotel));
            }

            return destination;
        }        

        public List<HotelModel> GetHotelByPincode(string pincode) {
            List<Hotel> source = HotelRepository.GetHotelByPincode(pincode);
            List<HotelModel> destination = new List<HotelModel>();

            foreach (Hotel hotel in source) {
                destination.Add(ModelMapperService.Map<Hotel, HotelModel>(hotel));
            }

            return destination;
        }
        
    }

}