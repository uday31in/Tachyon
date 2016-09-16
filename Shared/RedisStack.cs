using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class RedisStack
    {
        private ConnectionMultiplexer Connection;        

        public RedisStack(string redisConnectionMultiplexer)
        {
           
            Connection = ConnectionMultiplexer.Connect(redisConnectionMultiplexer);
        }
      
        public void Push(RedisKey stackName, RedisValue value)
        {
            Connection.GetDatabase().ListRightPush(stackName, value);
        }

        public RedisValue Pop(RedisKey stackName)
        {
            return Connection.GetDatabase().ListRightPop(stackName);

        }
        public long ListLength(RedisKey stackName)
        {
            return Connection.GetDatabase().ListLength(stackName);
        }
    }
}
