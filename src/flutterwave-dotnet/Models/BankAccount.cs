using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class BankAccount
    {
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
    }
}
