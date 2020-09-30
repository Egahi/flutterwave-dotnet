using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class VerifyBankAccountRequest
    {
        public VerifyBankAccountRequest(string accountNumber, string bankCode)
        {
            AccountNumber = accountNumber;
            BankCode = bankCode;
        }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        [JsonProperty("account_bank")]
        public string BankCode { get; set; }
    }
}
