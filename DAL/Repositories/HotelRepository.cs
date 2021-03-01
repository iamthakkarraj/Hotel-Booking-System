using DAL.CacheManager;
using DAL.Database;
using DAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories {

    public class HotelRepository : IHotelRepository {

        private readonly WebApiAssignmentEntities _DBContext;
        private readonly RedisManager _redisManager;
        public const string CACHE_KEY_PREFIX = "Hotel_";

        public HotelRepository() {
            _DBContext = new WebApiAssignmentEntities();
            _redisManager = new RedisManager();
        }

        public IQueryable<Hotel> GetQueryable() {
            var cachedData = this._redisManager.Get(CACHE_KEY_PREFIX + 0);
            if (string.IsNullOrWhiteSpace(cachedData)) {
                var result = _DBContext.Hotels;
                this._redisManager.Set(CACHE_KEY_PREFIX + 0, JsonConvert.SerializeObject(result, Formatting.Indented,
                            new JsonSerializerSettings {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }).ToString());
                return result;
            } else {
                return JsonConvert.DeserializeObject<IQueryable<Hotel>>(cachedData.ReadToEnd());
            }
        }

        public Hotel GetHotelById(int id) {
            return _DBContext.Hotels
                    .Where(x => x.HotelId == id)
                    .FirstOrDefault();
        }

        public bool AddHotel(Hotel hotel) {
            try {
                _DBContext.Hotels.Add(hotel);
                _DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool DeleteHotel(int id) {
            try {
                _DBContext.Hotels
                    .Remove(
                        _DBContext.Hotels
                        .Where(x => x.HotelId == id)
                        .FirstOrDefault());
                _DBContext.SaveChanges();
                return true;
            } catch (Exception e) {
                return false;
            }
        }
        public bool UpdateHotel(Hotel hotel) {
            try {
                _DBContext.Entry(hotel).State = EntityState.Modified;
                _DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

    }

}