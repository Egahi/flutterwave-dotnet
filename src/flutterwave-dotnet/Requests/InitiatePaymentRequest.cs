using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flutterwave.Net
{
    class InitiatePaymentRequest
    {
        public InitiatePaymentRequest(string referenceNumber,
                                      decimal amount,
                                      string currency,
                                      string redirectUrl,
                                      string customerName,
                                      string customerEmail,
                                      string customerPhoneNumber,
                                      string paymentTitle,
                                      string paymentDescription,
                                      string brandLogoUrl,
                                      List<SplitPayment> splitPayments = null)
        {
            TxRef = referenceNumber;
            Amount = amount;
            Currency = currency;
            RedirectUrl = redirectUrl;
            Customer = new Customer(customerName, customerEmail, customerPhoneNumber);
            Customizations = new Customizations(paymentTitle, paymentDescription, brandLogoUrl);
            SplitPayments = splitPayments;
        }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
        [JsonProperty("payment_options")]
        public string PaymentOptions { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("subaccounts")]
        public List<SplitPayment> SplitPayments { get; set; }
        [JsonProperty("customizations")]
        public Customizations Customizations { get; set; }
    }
}
