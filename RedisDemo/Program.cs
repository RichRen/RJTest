using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisDemo.Common;
using ServiceStack.Redis;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 封装调用
            //HashOperator operate = new HashOperator();

            //operate.Set("rj", "renjing", "任静");

            //var rj = operate.Get<string>("rj", "renjing");
            #endregion

            IRedisClient redisClient = RedisManager.GetClient();

            string renjing = "renjing";
            redisClient.Set("renjing", renjing);

            string getV = redisClient.Get<string>("renjing");

            Console.Read();
        }
    }

    public class Person
    {
        public int Id { get; set; }

        public int Name { get; set; }
    }
}
