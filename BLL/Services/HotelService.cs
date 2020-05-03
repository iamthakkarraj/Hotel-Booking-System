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
                
        public List<HotelModel> GetHotels() {
            List<Hotel> source = HotelRepository.GetQueryable().OrderBy(x => x.Name).ToList();
            List<HotelModel> destination = new List<HotelModel>();
            foreach (Hotel hotel in source) {
                destination.Add(ModelMapperService.Map<Hotel, HotelModel>(hotel));
            }
            return destination;
        }
        public List<HotelModel> GetHotels(string name, string city, string pincode) {
            List<HotelModel> destination = new List<HotelModel>();
            IQueryable<Hotel> query = HotelRepository.GetQueryable().OrderBy(x => x.Name);
            if (name != null)
                query = query.Where(x => x.Name.Contains(name) || x.Name.StartsWith(name) || x.Name.EndsWith(name));
            if (city != null)
                query = query.Where(x => x.City == city);
            if (pincode != null)
                query = query.Where(x => x.PinCode == pincode);            
            foreach (Hotel hotel in query.ToList()) {
                destination.Add(ModelMapperService.Map<Hotel, HotelModel>(hotel));
            }
            return destination;
        }
        public HotelModel GetHotelById(int id) {
            return ModelMapperService.Map<Hotel,HotelModel>(HotelRepository.GetHotelById(id));
        }                
        public bool AddHotel(HotelModel hotel) {
            return HotelRepository.AddHotel(ModelMapperService.Map<HotelModel, Hotel>(hotel));
        }
        public bool UpdateHotel(HotelModel hotel) {
            return HotelRepository.UpdateHotel(ModelMapperService.Map<HotelModel, Hotel>(hotel));
        }
        public bool DeleteHotel(int id) {
            return HotelRepository.DeleteHotel(id);
        }

    }

}