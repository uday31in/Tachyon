using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Shared
{
    public class Config
    {
        public static string RedisConnectionMultiplexer;
        public static int delayInMilliseconds = 0;
        public static string MessageQueueName;

        Dictionary<string, string> switchMappings = new Dictionary<string, string>
            {
                {"-c", "RedisConnectionMultiplexer" },
                {"-d", "delayInMilliseconds" },
                {"-q", "MessageQueueName" },
            };

        public Config(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                     .AddJsonFile("appsettings.json",optional:true)                                    
                                     .AddEnvironmentVariables("Tachyon_")
                                     .AddCommandLine(args, switchMappings)
                                     .Build();

            RedisConnectionMultiplexer = configuration["RedisConnectionMultiplexer"];
            delayInMilliseconds = Int32.Parse(configuration["delayInMilliseconds"]);
            MessageQueueName = configuration["MessageQueueName"];


        }

    }
}
