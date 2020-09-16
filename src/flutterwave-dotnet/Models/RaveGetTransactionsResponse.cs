using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class RaveGetTransactionsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Meta Meta { get; set; }
        public List<DataItem> Data { get; set; }
    }

    public class Meta
    {
        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int Total { get; set; }
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }

    public class DataItem
    {
        public int Id { get; set; }
        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }
        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }
        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        [JsonProperty("charged_amount")]
        public decimal ChargedAmount { get; set; }
        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }
        [JsonProperty("merchant_fee")]
        public decimal MerchantFee { get; set; }
        [JsonProperty("processor_response")]
        public string ProcessorResponse { get; set; }
        [JsonProperty("auth_model")]
        public string AuthModel { get; set; }
        public string Ip { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("amount_settled")]
        public decimal AmountSettled { get; set; }
        public Customer Customer { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }
        public DataMeta Meta { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public class DataMeta
    {
        public string OriginatorAccountNumber { get; set; }
        public string OriginatorName { get; set; }
        public string BankName { get; set; }
    }
}
