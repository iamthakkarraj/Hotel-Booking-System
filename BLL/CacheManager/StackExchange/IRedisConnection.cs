using StackExchange.Redis;
using System;

namespace BLL.StackExchange {

    public class IRedisConnection {

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        static IRedisConnection()
        {
            IRedisConnection.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }

        public ConnectionMultiplexer Connection {
            get {
                return lazyConnection.Value;
            }
        }

    }

}