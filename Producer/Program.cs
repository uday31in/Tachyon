using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Threading;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Shared;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config(args);
           

            Console.WriteLine("Using ID: {2} Connection String: {0} MessageQueueName: {3} Delay: {1}ms ", Config.RedisConnectionMultiplexer, Config.delayInMilliseconds, Process.GetCurrentProcess().Id, Config.MessageQueueName);
            Console.WriteLine("Press \'q\' to quit the sample");

            RedisStack redis = new RedisStack(Config.RedisConnectionMultiplexer);

            int counter = 0;

            while (true)
            {
                Console.WriteLine(String.Format("{0}-{1}-{2}-{3}", counter, DateTime.Now, Process.GetCurrentProcess().MachineName, Process.GetCurrentProcess().Id));

                redis.Push(Config.MessageQueueName, (String.Format("{0}-{1}-{2}-{3}", counter++, DateTime.Now, Process.GetCurrentProcess().MachineName, Process.GetCurrentProcess().Id)));

                Thread.Sleep(Config.delayInMilliseconds);

            }

        }

    }
}
