using Flutterwave.Net.Utilities;

namespace Flutterwave.Net
{
    public class Transactions : ITransactions
    {
        private FlutterwaveApi _flutterwaveApi { get; }

        public Transactions(FlutterwaveApi flutterwaveApi)
        {
            _flutterwaveApi = flutterwaveApi;
        }

        /// <summary>
        /// Get all transactions
        /// </summary>
        /// <returns></returns>
        public GetTransactionsResponse GetTransactions()
        {
            return _flutterwaveApi.Get<GetTransactionsResponse>(Endpoints.TRANSACTIONS);
        }

        /// <summary>
        /// Initiate Payment
        /// </summary>
        /// <param name="referenceNumber">A unique reference number for this payment</param>
        /// <param name="amount">Amount to be paid</param>
        /// <param name="redirectUrl">A url to redirect to after payment is made</param>
        /// <param name="customerName"></param>
        /// <param name="customerEmail"></param>
        /// <param name="customerPhoneNumber"></param>
        /// <param name="paymentTitle">A title for this payment</param>
        /// <param name="paymentDescription">A description for this payment</param>
        /// <param name="brandLogoUrl">A link to your brand's logo</param>
        /// <param name="currency">Currency of payment, default value is Naira - "NGN"</param>
        /// <returns></returns>
        public InitiatePaymentResponse InitiatePayment(string referenceNumber,
                                                       decimal amount,
                                                       string redirectUrl,
                                                       string customerName,
                                                       string customerEmail,
                                                       string customerPhoneNumber,
                                                       string paymentTitle,
                                                       string paymentDescription,
                                                       string brandLogoUrl,
                                                       Currency currency = Currency.Naira)
        {
            var request = new InitiatePaymentRequest(referenceNumber,
                                                     amount,
                                                     "NGN",
                                                     redirectUrl,
                                                     customerName,
                                                     customerEmail,
                                                     customerPhoneNumber,
                                                     paymentTitle,
                                                     paymentDescription,
                                                     brandLogoUrl);

            return _flutterwaveApi.Post<InitiatePaymentResponse>(Endpoints.PAYMENTS, request);
        }
    }
}
