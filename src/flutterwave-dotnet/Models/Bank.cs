using Newtonsoft.Json;
using System;

namespace Flutterwave.Net
{
    public class Bank
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        
    }
}
