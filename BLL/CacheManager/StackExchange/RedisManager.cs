using BLL;
using BLL.CacheManager.StackExchange;
using BLL.StackExchange;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BLL.CacheManager.StackExchange
{

    /// <summary>
    /// This class provides communication abstraction with Redis caching server
    /// </summary>
    public class RedisManager :  RedisBase, IRedisManager
    {

        #region class variables

        /// <summary>
        /// Redis connection provider
        /// </summary>
        private IRedisConnection _redisConnection;

        /// <summary>
        /// Redis cache database reference
        /// </summary>
        private IDatabase _cacheDB;

        #endregion

        #region constructor

        /// <summary>
        /// Get connection frm redis connection provider 
        /// and initialize DB from connection
        /// </summary>
        public RedisManager()
        {
            _redisConnection = new IRedisConnection();
            _cacheDB = _redisConnection.Connection.GetDatabase();
        }

        #endregion

        #region key value pair helper

        /// <summary>
        /// Gets a single string value under specified keyName from redis server
        /// </summary>
        /// <param name="keyName">unique key</param>
        /// <returns>key value type of string</returns>
        public string Get(string keyName)
        {
            try
            {
                return _cacheDB.StringGet(keyName);
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Sets a single string value under specified keyName to redis server
        /// If the given key exist than the new value will be overriden
        /// </summary>
        /// <param name="keyName">unique key</param>
        /// <returns>true if success false if error</returns>
        public bool Set(string keyName, string value)
        {
            try
            {
                return _cacheDB.StringSet(keyName, value, TimeSpan.FromMinutes(5));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a single object of T type under specified keyName from redis server
        /// </summary>
        /// <param name="keyName">unique key</param>
        /// <returns>key value type of T</returns>
        public T Get<T>(string keyName)
        {
            try
            {
                return Deserialize<T>(_cacheDB.StringGet(keyName));
            }
            catch (Exception e)
            {
                return Activator.CreateInstance<T>();
            }
        }

        /// <summary>
        /// Sets a single object of T type under specified keyName to redis server
        /// If the given key exist than the new value will be overriden
        /// </summary>
        /// <param name="keyName">unique key</param>
        /// <returns>true if success false if error</returns>
        public bool Set<T>(string keyName, T value)
        {
            try
            {
                return _cacheDB.StringSet(keyName, JsonConvert.SerializeObject(value), TimeSpan.FromMinutes(5));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region hashset helpers

        /// <summary>
        /// Will store object of type T as a hashmap under specified key name
        /// If the given key exist than the new value will be overriden
        /// </summary>
        /// <typeparam name="T">type of param "data"</typeparam>
        /// <param name="key">unique key</param>
        /// <param name="data">Data object of type T</param>
        /// <returns>true if success false if error</returns>
        public bool StoreAsHasMap<T>(string key, T data)
        {
            try
            {
                _cacheDB.HashSet(GetEncodedKeyName<T>(key), ToHashSet<T>(data));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Will store list of type T as a hashmap under a unique key
        /// unique key will be generated from the value of specified property's name of object with type T
        /// If the given key exist than the new value will be overriden
        /// </summary>
        /// <typeparam name="T">type of param "data"</typeparam>
        /// <param name="key">unique key</param>
        /// <param name="data">list object of type T</param>
        /// <returns>true if success false if error</returns>
        public bool StoreAsHasMap<T>(IEnumerable<T> data, string keyProperty = "Id")
        {
            try
            {
                var hashList = new List<HashEntry>();
                foreach (var item in data)
                {
                    StoreAsHasMap<T>(Convert.ToString(item.GetType().GetProperty(keyProperty).GetValue(item)), item);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /// <summary>
        /// Will store list of type T as a hashmap under a unique key
        /// unique key will be generated from the array of all specified property's name of object with type T
        /// If the given key exist than the new value will be overriden
        /// </summary>
        /// <typeparam name="T">type of param "data"</typeparam>
        /// <param name="key">unique key</param>
        /// <param name="data">list object of type T</param>
        /// <returns>true if success false if error</returns>
        public bool StoreAsHasMap<T>(IEnumerable<T> data, params string[] keyProperty)
        {
            try
            {
                var hashList = new List<HashEntry>();
                foreach (var item in data)
                {
                    StoreAsHasMap<T>(Convert.ToString(item.GetType().GetProperty(GetUniquePostFixFromProperties(keyProperty)).GetValue(item)), item);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /// <summary>
        /// Will return an object of type T stored as hashmap under redis server having specfied key
        /// </summary>
        /// <typeparam name="T">type of param "data"</typeparam>
        /// <param name="key">unique key</param>
        /// <returns>data Object of type T if success default object of type T if error</returns>
        public T GetFromHash<T>(string key)
        {
            try
            {
                var hashEntries
                    = _cacheDB.HashGetAll(GetEncodedKeyName<T>(key));
                return FromHasSet<T>(hashEntries);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Will return a value of specific field from a hashmap stored under specified key
        /// </summary>
        /// <param name="key">unique key</param>
        /// <param name="hashFieldName">name of field stored in hashmap</param>
        /// <returns>value of hashmap field type object</returns>
        public object GetValueFromHash(string key, string hashFieldName)
        {
            try
            {
                var hashFieldValue
                    = _cacheDB.HashGet(key, hashFieldName);
                return hashFieldValue.HasValue ? hashFieldValue : default(object);
            }
            catch (Exception e)
            {
                return default(object);
            }
        }

        #endregion

        #region list helpers   

        /// <summary>
        /// Adds a set of values under a specifed key
        /// If the given key exist than the new value will be overriden
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <param name="collection">collestion of values</param>
        /// <returns>true if success false if error</returns>
        public bool AddRange(string key, IEnumerable<string> collection)
        {
            try
            {
                foreach (var item in collection)
                {
                    _cacheDB.ListLeftPush(key, item);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a list of values specified under a specific key
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <returns>true if success false if error</returns>
        public string[] GetList(string key)
        {
            try
            {
                //0 Refers to first element in the list
                //1 Referes to the last element in the list
                return (string[])_cacheDB.ListRange(key, 0, -1).Select(x => x.ToString());
            }
            catch (Exception e)
            {
                return default(string[]);
            }
        }

        /// <summary>
        /// Adds one element in the beginning of a list specified under a specific key
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <returns>true if success false if error</returns>
        public bool PushFirst(string key, string item)
        {
            try
            {
                _cacheDB.ListLeftPush(key, Serialize(item));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds one element in the end of a list specified under a specific key
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <returns>true if success false if error</returns>
        public bool PushLast(string key, string item)
        {
            try
            {
                _cacheDB.ListRightPush(key, Serialize(item));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region redis commond helpers     
        
        /// <summary>
        /// return all keys that matches to the search query
        /// </summary>
        /// <param name="value">matching string</param>
        /// <param name="mode">type of search</param>
        /// <returns>list of all mathching keys</returns>
        public string[] SearchKeys(string value, RedisKeySearch mode)
        {
            try
            {
                var parmaters = string.Empty;
                switch (mode)
                {
                    case RedisKeySearch.StartsWith:
                        parmaters = value + LIKE_OPERATOR;
                        break;
                    case RedisKeySearch.EndsWith:
                        parmaters = LIKE_OPERATOR + value;
                        break;
                    case RedisKeySearch.Contains:
                        parmaters = LIKE_OPERATOR + value + LIKE_OPERATOR;
                        break;
                    case RedisKeySearch.All:
                        parmaters = LIKE_OPERATOR;
                        break;
                }
                return (string[])_cacheDB.Execute(REDIS_COMMAND_KEYS, parmaters);
            }
            catch (Exception e)
            {
                return default(string[]);
            }
        }

        /// <summary>
        /// Removes given key from redis server
        /// </summary>
        /// <param name="keys">unique key</param>
        /// <returns>true if success false if error</returns>
        public bool RemoveKey(string key)
        {
            try
            {
                _cacheDB.Execute(REDIS_COMMAND_DEL, key);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes all given keys from redis server
        /// </summary>
        /// <param name="keys">list of all keys</param>
        /// <returns>true if success false if error</returns>
        public bool RemoveKeys(string[] keys)
        {
            try
            {
                _cacheDB.Execute(REDIS_COMMAND_DEL, keys);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// This will unlinke the given keys from server
        /// This command is very similar to DEL However the command performs the actual memory reclaiming in a different thread, 
        /// so it is not blocking, while DEL is. 
        /// UNLINK command just unlinks the keys from the keyspace. The actual removal will happen later asynchronously.
        /// For remove larger sets of keys prefer using Unlink over Del.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>true if success false if error</returns>
        public bool UnlinkKeys(string[] keys)
        {
            try
            {
                _cacheDB.Execute(REDIS_COMMAND_UNLINK, keys);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Remove all keys from server
        /// </summary>
        /// <returns>true if success false if error</returns>
        public bool Flush()
        {
            try
            {
                _cacheDB.Execute(REDIS_COMMAND_FLUSH_ALL);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
        
    }

}