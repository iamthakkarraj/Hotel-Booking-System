using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CacheManager.ServiceStack
{
    public class RedisManager
    {

        RedisManagerPool _redisManager;

        public RedisManager()
        {
            _redisManager = new RedisManagerPool("localhost");
        }

        public bool SetList<T>(IEnumerable<T> list)
        {
            try
            {
                using (var client = _redisManager.GetClient())
                {
                    var redisTypedClient = client.As<T>();
                    if (redisTypedClient != null)
                    {
                        redisTypedClient.StoreAll(list);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<T> GetList<T>()
        {
            try
            {
                using (var client = _redisManager.GetClient())
                {
                    var redisTypedClient = client.As<T>();
                    var list = redisTypedClient.GetAll();
                    return list;
                }
            }
            catch (Exception e)
            {
                return Activator.CreateInstance<IEnumerable<T>>();
            }
        }

        public T GetItem<T>(int id)
        {
            try
            {
                using (var client = _redisManager.GetClient())
                {
                    var redisTypedClient = client.As<T>();
                    var item = redisTypedClient.GetById(id);
                    return item;
                }
            }
            catch (Exception e)
            {
                return Activator.CreateInstance<T>();
            }
        }

        public bool SetItem<T>(T item)
        {
            try
            {
                using (var client = _redisManager.GetClient())
                {
                    var redisTypedClient = client.As<T>();
                    redisTypedClient.AddToRecentsList(item);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }

}