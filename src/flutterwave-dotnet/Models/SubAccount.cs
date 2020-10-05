using Newtonsoft.Json;

namespace Flutterwave.Net.Models
{
    public class SubAccount
    {
        [JsonProperty("account_bank")]
        public string AccountBank { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }
    }
}