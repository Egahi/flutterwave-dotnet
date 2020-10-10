using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class SplitPayment
    {
        [JsonProperty("id")]
        public string SubAccountId { get; set; }
        [JsonProperty("transaction_split_ratio")]
        public int TransactionSplitRatio { get; set; }
        [JsonProperty("transaction_charge_type")]
        public string TransactionChargeType { get; set; }
        [JsonProperty("transaction_charge")]
        public decimal TransactionCharge { get; set; }
    }
}
