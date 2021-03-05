using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CacheManager.StackExchange
{

    public class RedisBase
    {

        #region class variables

        /// <summary>
        /// Seprator to seprator redis key value from it's prefix
        /// </summary>
        public char ENCODING_SEPRATOR = ':';

        /// <summary>
        /// Operator to search keys in redis through redis commands
        /// </summary>
        public string LIKE_OPERATOR = "*";

        /// <summary>
        /// Redis command to search keys created in server
        /// </summary>
        public string REDIS_COMMAND_KEYS = "keys";

        /// <summary>
        /// Redis command to get multiple key's values
        /// </summary>
        public string REDIS_COMMAND_MGET = "mget";

        /// <summary>
        /// Redis command to delete keys from server
        /// </summary>
        public string REDIS_COMMAND_DEL = "del";

        /// <summary>
        /// redis command to unlink keys from server
        /// </summary>
        public string REDIS_COMMAND_UNLINK = "unlink";

        /// <summary>
        /// Redios command to remove all keys from server
        /// </summary>
        public string REDIS_COMMAND_FLUSH_ALL = "flushall";
        #endregion

        #region enums

        /// <summary>
        /// Different modes of redis search key command
        /// </summary>
        public enum RedisKeySearch
        {
            /// <summary>
            /// Keys that starts with the give text e.g. {value}*
            /// </summary>
            StartsWith = 0,
            /// <summary>
            /// Keys that ends with given text e.g. *{value}
            /// </summary>
            EndsWith = 1,
            /// <summary>
            /// keys that contains given text e.g. *{value}*
            /// </summary>
            Contains = 2,
            /// <summary>
            /// all keys e.g. *
            /// </summary>
            All = 3
        }

        #endregion

        #region private methods

        /// <summary>
        /// Serialize the object of type T
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="data">source object</param>
        /// <returns>Serialized string of object</returns>
        protected string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Deserialize the object of type T
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="data">source string</param>
        /// <returns>Deserialized object</returns>
        protected T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Converts the source object of type T into a hashset
        /// </summary>
        /// <typeparam name="T">type of object</typeparam>
        /// <param name="data">data</param>
        /// <returns>List of hashentry</returns>
        protected HashEntry[] ToHashSet<T>(T data)
        {
            var hashList = new List<HashEntry>();
            foreach (var property in data.GetType().GetProperties())
            {
                hashList.Add(new HashEntry(property.Name, Convert.ToString(property.GetValue(data))));
            }
            return hashList.ToArray();
        }

        /// <summary>
        /// Converts the given hashset into object of type T
        /// </summary>
        /// <typeparam name="T">type of object</typeparam>
        /// <param name="hashEntries">list of hashentry</param>
        /// <returns>object of type T</returns>
        protected T FromHasSet<T>(HashEntry[] hashEntries)
        {

            PropertyInfo[] properties = typeof(T).GetProperties();
            var obj = Activator.CreateInstance(typeof(T));

            foreach (var property in properties)
            {
                HashEntry entry
                    = hashEntries.FirstOrDefault(
                            g => g.Name.ToString().Equals(property.Name));

                if (entry.Equals(new HashEntry())) continue;

                if (entry.Value.HasValue)
                {
                    property.SetValue(obj,
                        Convert.ChangeType(
                            Convert.ToString(entry.Value),
                            property.PropertyType));
                }
            }

            return (T)obj;

        }

        /// <summary>
        /// Creates a class name prefix for key value
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="key">key name</param>
        /// <returns>key name prefixed with class name</returns>
        protected string GetEncodedKeyName<T>(string key)
        {
            return string.Concat(typeof(T).Name, ENCODING_SEPRATOR, key);
        }

        /// <summary>
        /// returns a unique prefix for key names from list of uniqe identifiers
        /// </summary>
        /// <param name="keyProperty">list of all identifiers that will be used as a prefix for a key name sperated with ENOCODING_SEPRATOR</param>
        /// <returns>unique prefix for the key</returns>
        protected string GetUniquePostFixFromProperties(string[] keyProperty)
        {
            if (keyProperty.Length > 1)
            {
                return string.Join(ENCODING_SEPRATOR.ToString(), keyProperty);
            }
            else if (keyProperty.Length == 1)
            {
                return keyProperty[0];
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

    }

}
