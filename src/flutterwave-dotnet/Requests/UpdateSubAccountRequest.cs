using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class UpdateSubAccountRequest
    {
        public UpdateSubAccountRequest(string businessName,
                                       string businessEmail,
                                       string bankCode,
                                       string accountNumber,                                       
                                       string splitType,
                                       double splitValue)
        {
            BusinessName = businessName;
            BusinessEmail = businessEmail;
            BankCode = bankCode;
            AccountNumber = accountNumber;            
            SplitType = splitType;
            SplitValue = splitValue;
        }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }
        [JsonProperty("business_email")]
        public string BusinessEmail { get; set; }
        [JsonProperty("account_bank")]
        public string BankCode { get; set; }
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        [JsonProperty("split_type")]
        public string SplitType { get; set; }
        [JsonProperty("split_value")]
        public double SplitValue { get; set; }
    }
}
