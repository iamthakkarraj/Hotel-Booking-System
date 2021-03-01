using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CacheManager {

    public class RedisManager {

        IRedisConnection _redisConnection;
        IDatabase _cacheDB;

        public RedisManager() {
            _redisConnection = new IRedisConnection();
            _cacheDB = _redisConnection.Connection.GetDatabase();
        }

        public bool Set(string keyName, string value) {
            try{
                return _cacheDB.StringSet(keyName, value, TimeSpan.FromMinutes(5));
            }catch (Exception e) {
                return false;
            }
        }

        public string Get(string keyName) {
            try {
                return _cacheDB.StringGet(keyName);
            }catch(Exception e) {
                return string.Empty;
            }            
        }

    }

}
