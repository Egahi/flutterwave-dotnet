using Newtonsoft.Json;
using System;

namespace Flutterwave.Net
{
    public class Transaction
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }
        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }
        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("charged_amount")]
        public decimal ChargedAmount { get; set; }
        [JsonProperty("app_fee")]
        public string AppFee { get; set; }
        [JsonProperty("merchant_fee")]
        public decimal MerchantFee { get; set; }
        [JsonProperty("processor_response")]
        public string ProcessorResponse { get; set; }
        [JsonProperty("auth_model")]
        public string AuthModel { get; set; }
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("narration")]
        public string Narration { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("amount_settled")]
        public string AmountSettled { get; set; }
        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }
    }

    public class Account
    {
        [JsonProperty("nuban")]
        public string Nuban { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }
    }
}
