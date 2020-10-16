using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class UpdatePaymentPlanRequest
    {
        public UpdatePaymentPlanRequest(string name,
                                        string status)
        {
            Name = name;
            Status = status;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}