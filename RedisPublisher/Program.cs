using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var SingleHost = "";
            int DefaultPublishMessageCount = 10, numberMessages;
            var ChannelName = "ChannelName";
            // using ()
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            ISubscriber sub = redis.GetSubscriber();
            while (true)
            {                                
                Console.WriteLine("Input numbner of publishing messages...");
                Console.WriteLine("Enter numbner of publishing messages or q to quit");
                Int32.TryParse(Console.ReadLine(), out numberMessages);
                if (numberMessages > 0)
                {
                    for (var i = 1; i <= numberMessages; i++)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(30);
                            var now = DateTime.Now;
                            string message = ChannelName + now.ToLongTimeString() + "   " + now.Millisecond;
                            Console.WriteLine("Publishing '{0}' to '{1}'", message, ChannelName);
                            sub.Publish(ChannelName, message);
                        });
                    };
                }
                if (Console.ReadKey().KeyChar == 'q')
                {
                    break;
                }
            };
        }
    }
}
