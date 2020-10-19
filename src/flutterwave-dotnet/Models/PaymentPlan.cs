using Newtonsoft.Json;
using System;

namespace Flutterwave.Net
{
    public class PaymentPlan
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        
        [JsonProperty("interval")]
        public string Interval { get; set; }
         
        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("status")]
        public string  Status{ get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("plan_token")]
        public string PlanToken { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } 
    }
}