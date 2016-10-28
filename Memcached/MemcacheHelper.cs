using System;
using Memcached.ClientLibrary;

namespace Memcached
{
    public static class MemcacheHelper
    {
        private static MemcachedClient mc;

        static MemcacheHelper()
        {
            String[] serverlist = { "127.0.0.1:11211" };

            // initialize the pool for memcache servers
            SockIOPool pool = SockIOPool.GetInstance("test");
            pool.SetServers(serverlist);
            pool.Initialize();
            mc = new MemcachedClient();
            mc.PoolName = "test";
            mc.EnableCompression = false;
            
        }

        public static bool Set(string key, object value,DateTime expiry){
            return mc.Set(key, value, expiry);
        }

        public static bool Set(string key, object value)
        {
            return mc.Set(key, value);
        }
        public static object Get(string key)
        {
            return mc.Get(key);
        }
    }
}