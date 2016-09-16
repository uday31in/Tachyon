using System;
using System.Threading;
using System.Diagnostics;
using Shared;

namespace Watcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Config config = new Config(args);

            Console.WriteLine("Using ID: {2} Connection String: {0} MessageQueueName: {3} Delay: {1}ms ", Config.RedisConnectionMultiplexer, Config.delayInMilliseconds, Process.GetCurrentProcess().Id, Config.MessageQueueName);
            Console.WriteLine("Press \'q\' to quit the sample");


            RedisStack redis = new RedisStack(Config.RedisConnectionMultiplexer);

           
            while (true)
            {
                Console.WriteLine("{1} Current Message Queue: {0}", redis.ListLength(Config.MessageQueueName).ToString(), DateTime.Now);

                Thread.Sleep(Config.delayInMilliseconds);

            }
        }
    }
}
