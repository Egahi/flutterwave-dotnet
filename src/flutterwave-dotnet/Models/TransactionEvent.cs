using Newtonsoft.Json;
using System;

namespace Flutterwave.Net
{
    public class TransactionEvent
    {
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("actor")]
        public string Actor { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("context")]
        public string Context { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
