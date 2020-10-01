using Newtonsoft.Json;
using System;

namespace Flutterwave.Net
{
    public class SubAccount
    {
        public int Id { get; set; }
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        [JsonProperty("account_bank")]
        public string BankCode { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("split_type")]
        public string SplitType { get; set; }
        [JsonProperty("split_value")]
        public decimal SplitValue { get; set; }
        [JsonProperty("subaccount_id")]
        public string SubAccountId { get; set; }
        [JsonProperty("bank_name")]
        public string BankName { get; set; }
    }
}
