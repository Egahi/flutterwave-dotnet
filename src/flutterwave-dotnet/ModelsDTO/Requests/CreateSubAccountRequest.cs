using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class CreateSubAccountRequest
    {
        public CreateSubAccountRequest(string bankCode,
                                       string accountNumber,
                                       string businessName,
                                       string businessEmail,
                                       string country,
                                       string splitType,
                                       double splitValue,
                                       string businessContact,
                                       string businessContactMobile,
                                       string businessMobile)
        {
            BankCode = bankCode;
            AccountNumber = accountNumber;
            BusinessName = businessName;
            BusinessEmail = businessEmail;
            Country = country;
            SplitType = splitType;
            SplitValue = splitValue;
            BusinessContact = businessContact;
            BusinessContactMobile = businessContactMobile;
            BusinessMobile = businessMobile;
        }

        [JsonProperty("account_bank")]
        public string BankCode { get; set; }
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }
        [JsonProperty("business_email")]
        public string BusinessEmail { get; set; }
        [JsonProperty("business_contact")]
        public string BusinessContact { get; set; }
        [JsonProperty("business_contact_mobile")]
        public string BusinessContactMobile { get; set; }
        [JsonProperty("business_mobile")]
        public string BusinessMobile { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("split_type")]
        public string SplitType { get; set; }
        [JsonProperty("split_value")]
        public double SplitValue { get; set; }
    }
}
