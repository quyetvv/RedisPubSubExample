using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var SingleHost = "";
                var PublishMessageCount = 3;
                var ChannelName = "ChannelName";
                // using ()
                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
                ISubscriber sub = redis.GetSubscriber();

                sub.Subscribe(ChannelName, (channel, message) =>
                {
                    Console.WriteLine((string)message);
                });

                if (Console.ReadKey().KeyChar == 'q')
                {

                }
            }
        }
    }
}
