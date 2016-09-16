using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Linq;
using StackExchange.Redis;
using System.Configuration;

namespace WatcherWeb
{
    public class Monintor
    {
        // Singleton instance
        private readonly static Lazy<Monintor> _instance = new Lazy<Monintor>(() => new Monintor(GlobalHost.ConnectionManager.GetHubContext<Tachyon>().Clients));
        static ConnectionMultiplexer Connection;

        private static string RedisConnectionMultiplexer = ConfigurationManager.AppSettings["RedisConnectionMultiplexer"];
        private static int delayInMilliseconds = Int32.Parse( ConfigurationManager.AppSettings["delayInMilliseconds"]);
        private static string MessageQueueName = ConfigurationManager.AppSettings["MessageQueueName"];
  

        private readonly Timer _timer;
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(delayInMilliseconds);
        private readonly object _updateClientLock = new object();

       

        private Monintor(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;

            _timer = new Timer(UpdateMonitor, null, _updateInterval, _updateInterval);
            Connection = ConnectionMultiplexer.Connect(RedisConnectionMultiplexer);

        }

        public static Monintor Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        private void UpdateMonitor(object state)
        {
            lock (_updateClientLock)
            {

                BroadcastMonitorCount();

            }
        }

        public void BroadcastMonitorCount()
        {

            if(!Connection.GetDatabase().KeyExists(MessageQueueName))
            {


            }

            long  CurrentQueue = Connection.GetDatabase().ListLength(MessageQueueName);
            WatcherModel w = new WatcherModel();
            w.QueueLength = CurrentQueue;
            w.QueueName = MessageQueueName;
            w.Publisher = "P1";
            //Clients.All.addNewMessageToPage("uday", string.Concat(Enumerable.Repeat("*", length++)));
            Clients.All.updateQueueStatus(w);
        }

    }
}