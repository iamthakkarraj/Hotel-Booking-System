using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.CacheManager.StackExchange.RedisBase;

namespace BLL.CacheManager.StackExchange
{

    /// <summary>
    /// This class provides communication abstraction with Redis caching server
    /// </summary>
    interface IRedisManager
    {

        /// <summary>
        /// Gets a single string value under specified keyName from redis server
        /// </summary>
        /// <param name="keyName">unique key</param>
        /// <returns>key value type of string</returns>
        string Get(string keyName);

        /// <summary>
        /// Sets a single string value under specified keyName to redis server
        /// </summary>
        /// <param name="keyName">unique key</param>
        /// <returns>true if success false if error</returns>
        bool Set(string keyName, string value);

        /// <summary>
        /// Gets a single object of T type under specified keyName from redis server
        /// </summary>
        /// <param name="keyName">unique key</param>
        /// <returns>key value type of T</returns>
        T Get<T>(string keyName);

        /// <summary>
        /// Sets a single object of T type under specified keyName to redis server
        /// </summary>
        /// <param name="keyName">unique key</param>
        /// <returns>true if success false if error</returns>
        bool Set<T>(string keyName, T value);

        /// <summary>
        /// Will store object of type T as a hashmap under specified key name
        /// </summary>
        /// <typeparam name="T">type of param "data"</typeparam>
        /// <param name="key">unique key</param>
        /// <param name="data">Data object of type T</param>
        /// <returns>true if success false if error</returns>
        bool StoreAsHasMap<T>(string key, T data);

        /// <summary>
        /// Will store list of type T as a hashmap under a unique key
        /// unique key will be generated from the value of specified property's name of object with type T
        /// </summary>
        /// <typeparam name="T">type of param "data"</typeparam>
        /// <param name="key">unique key</param>
        /// <param name="data">list object of type T</param>
        /// <returns>true if success false if error</returns>
        bool StoreAsHasMap<T>(IEnumerable<T> data, string keyProperty = "Id");

        /// <summary>
        /// Will store list of type T as a hashmap under a unique key
        /// unique key will be generated from the array of all specified property's name of object with type T
        /// </summary>
        /// <typeparam name="T">type of param "data"</typeparam>
        /// <param name="key">unique key</param>
        /// <param name="data">list object of type T</param>
        /// <returns>true if success false if error</returns>
        bool StoreAsHasMap<T>(IEnumerable<T> data, params string[] keyProperty);

        /// <summary>
        /// Will return an object of type T stored as hashmap under redis server having specfied key
        /// </summary>
        /// <typeparam name="T">type of param "data"</typeparam>
        /// <param name="key">unique key</param>
        /// <returns>data Object of type T if success default object of type T if error</returns>
        T GetFromHash<T>(string key);

        /// <summary>
        /// Will return a value of specific field from a hashmap stored under specified key
        /// </summary>
        /// <param name="key">unique key</param>
        /// <param name="hashFieldName">name of field stored in hashmap</param>
        /// <returns>value of hashmap field type object</returns>
        object GetValueFromHash(string key, string hashFieldName);

        /// <summary>
        /// Adds a set of values under a specifed key
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <param name="collection">collestion of values</param>
        /// <returns>true if success false if error</returns>
        bool AddRange(string key, IEnumerable<string> collection);

        /// <summary>
        /// Adds one element in the beginning of a list specified under a specific key
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <returns>true if success false if error</returns>
        bool PushFirst(string key, string item);

        /// <summary>
        /// Adds one element in the end of a list specified under a specific key
        /// </summary>
        /// <param name="key">Unique key</param>
        /// <returns>true if success false if error</returns>
        bool PushLast(string key, string item);

        /// <summary>
        /// return all keys that matches to the search query
        /// </summary>
        /// <param name="value">matching string</param>
        /// <param name="mode">type of search</param>
        /// <returns>list of all mathching keys</returns>
        string[] SearchKeys(string value, RedisKeySearch mode);

        /// <summary>
        /// Removes given key from redis server
        /// </summary>
        /// <param name="keys">unique key</param>
        /// <returns>true if success false if error</returns>
        bool RemoveKey(string key);

        /// <summary>
        /// Removes all given keys from redis server
        /// </summary>
        /// <param name="keys">list of all keys</param>
        /// <returns>true if success false if error</returns>
        bool RemoveKeys(string[] keys);

        /// <summary>
        /// This will unlinke the given keys from server
        /// This command is very similar to DEL However the command performs the actual memory reclaiming in a different thread, 
        /// so it is not blocking, while DEL is. 
        /// UNLINK command just unlinks the keys from the keyspace. The actual removal will happen later asynchronously.
        /// For remove larger sets of keys prefer using Unlink over Del.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>true if success false if error</returns>
        bool UnlinkKeys(string[] keys);

        /// <summary>
        /// Remove all keys from server
        /// </summary>
        /// <returns>true if success false if error</returns>
        bool Flush();

    }

}