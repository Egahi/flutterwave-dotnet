using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class TransactionFee
    {
        [JsonProperty("charge_amount")]
        public decimal ChargeAmount { get; set; }
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        [JsonProperty("merchant_fee")]
        public decimal MerchantFee { get; set; }
        [JsonProperty("flutterwave_fee")]
        public decimal FlutterwaveFee { get; set; }
        [JsonProperty("stamp_duty_fee")]
        public decimal StampDutyFee { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
