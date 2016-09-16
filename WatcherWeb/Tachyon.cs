using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WatcherWeb
{
    public class Tachyon : Hub
    {
        private readonly Monintor _monitor;

        public Tachyon(Monintor stockTicker)
        {
            _monitor = stockTicker;
        }

        public Tachyon() : this(Monintor.Instance) { }

      
        
        public void Hello()
        {
            Clients.All.hello();

        }

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            //Clients.All.addNewMessageToPage(name, message);

            _monitor.BroadcastMonitorCount();
        }
    }
}