using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatcherWeb
{
    public class WatcherModel
    {
        [JsonProperty("QueueLength")]
        public long QueueLength { get; set; }

        [JsonProperty("QueueName")]
        public string QueueName { get; set; }

        [JsonProperty("Publisher")]
        public string Publisher { get; set; }
    }
}