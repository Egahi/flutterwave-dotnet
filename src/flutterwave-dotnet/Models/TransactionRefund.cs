using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Flutterwave.Net
{
    public class TransactionRefund
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("amount_refunded")]
        public decimal AmountRefunded { get; set; }
        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }
        [JsonProperty("settlement_id")]
        public string SettlementId { get; set; }
        [JsonProperty("meta")]
        public JObject Meta { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("account_id")]
        public int AccountId { get; set; }
        [JsonProperty("transaction_id")]
        public int TransactionId { get; set; }
    }
}
