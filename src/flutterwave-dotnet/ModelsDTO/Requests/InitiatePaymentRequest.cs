using Newtonsoft.Json;

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
                                      string brandLogoUrl)
        {
            TxRef = referenceNumber;
            Amount = amount;
            Currency = currency;
            RedirectUrl = redirectUrl;
            Customer = new Customer(customerName, customerEmail, customerPhoneNumber);
            Customizations = new Customizations(paymentTitle, paymentDescription, brandLogoUrl);
        }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
        [JsonProperty("payment_options")]
        public string PaymentOptions { get; set; }

        public Customer Customer { get; set; }
        public Customizations Customizations { get; set; }
    }
}
