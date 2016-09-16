using System;
using System.Threading;
using Shared;
using System.Diagnostics;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config(args);
            

            Console.WriteLine("Using ID: {2} Connection String: {0} MessageQueueName: {3} Delay: {1}ms ", Config.RedisConnectionMultiplexer, Config.delayInMilliseconds, Process.GetCurrentProcess().Id, Config.MessageQueueName);
            Console.WriteLine("Press \'q\' to quit the sample");

            RedisStack redis = new RedisStack(Config.RedisConnectionMultiplexer);

            while (true)
            {
                var item = redis.Pop(Config.MessageQueueName);
                Console.WriteLine(item.ToString());

                Thread.Sleep(Config.delayInMilliseconds);

            }
            
        }
    }	
}
