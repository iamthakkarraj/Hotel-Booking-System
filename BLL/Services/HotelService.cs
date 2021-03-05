using BLL.Interfaces;
using Common.Models;
using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.CacheManager;
using Newtonsoft.Json;
using BLL.StackExchange;

namespace BLL.Services {

    public class HotelService : IHotelService {

        readonly IHotelRepository HotelRepository;
        private readonly RedisManager _redisManager;
        public const string CACHE_KEY_PREFIX = "Hotel_";

        public HotelService(IHotelRepository _HotelRepository) {
            HotelRepository = _HotelRepository;
            _redisManager = new RedisManager();
        }
                
        public List<HotelModel> GetHotels() {
            var cachedData = this._redisManager.Get<List<HotelModel>>(CACHE_KEY_PREFIX + 0);

            if (cachedData == null || !cachedData.Any())
            {
                List<Hotel> source = HotelRepository.GetQueryable().OrderBy(x => x.Name).ToList();
                List<HotelModel> destination = new List<HotelModel>();
                foreach (Hotel hotel in source)
                {
                    destination.Add(ModelMapperService.Map<Hotel, HotelModel>(hotel));
                }
                this._redisManager.AddRange<HotelModel>("Hotels", destination);
                this._redisManager.StoreAsHasMap<HotelModel>(destination, "HotelId");
                this._redisManager.Set<List<HotelModel>>(CACHE_KEY_PREFIX + 0, destination);
                return destination;                
            }
            else
            {
                return cachedData;
            }
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

            var cachedData = this._redisManager.GetFromHash<HotelModel>(id.ToString());

            if (cachedData != null && cachedData.HotelId > 0)
            {
                return cachedData;
            }
            else { 
                var data = ModelMapperService.Map<Hotel, HotelModel>(HotelRepository.GetHotelById(id));
                this._redisManager.StoreAsHasMap<HotelModel>(id.ToString(), data);
                return data;
            }

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