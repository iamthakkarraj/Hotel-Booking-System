using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {

    public class IRedisConnection {

        static IRedisConnection() {
            IRedisConnection.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public ConnectionMultiplexer Connection {
            get {
                return lazyConnection.Value;
            }
        }

    }

}
