using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class CreatePaymentPlanRequest
    {
        public CreatePaymentPlanRequest(decimal amount,
                                        string name,
                                        string interval,
                                        decimal duration)
        {
            Amount = amount;
            Name = name;
            Interval = interval;
            Duration = duration;
        }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
         
        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("duration")]
        public decimal Duration { get; set; } 
    }
}