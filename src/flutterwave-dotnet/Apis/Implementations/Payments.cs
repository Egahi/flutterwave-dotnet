using Flutterwave.Net.Utilities;
using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class Payments : IPayments
    {
        private FlutterwaveApi _flutterwaveApi { get; }

        public Payments(FlutterwaveApi flutterwaveApi)
        {
            _flutterwaveApi = flutterwaveApi;
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
        /// <param name="splitPaymentRequests">
        /// List of parameters to split payment. It is called subaccounts on the offical documentation
        /// </param>
        /// <returns>A hosted link with the payment details</returns>
        public InitiatePaymentResponse InitiatePayment(string referenceNumber,
                                                       decimal amount,
                                                       string redirectUrl,
                                                       string customerName,
                                                       string customerEmail,
                                                       string customerPhoneNumber,
                                                       string paymentTitle,
                                                       string paymentDescription,
                                                       string brandLogoUrl,
                                                       Currency currency = Currency.NigerianNaira,
                                                       List<SplitPaymentRequest> splitPaymentRequests = null)
        {
            List<SplitPayment> splitPayments = null;

            if (splitPaymentRequests != null)
            {
                splitPayments = new List<SplitPayment>();

                foreach (var request in splitPaymentRequests)
                {
                    splitPayments.Add(new SplitPayment
                    {
                        SubAccountId = request.SubAccountId,
                        TransactionSplitRatio = request.TransactionSplitRatio,
                        TransactionChargeType = request.TransactionChargeType.GetValue(),
                        TransactionCharge = request.TransactionCharge
                    });
                }
            }

            var data = new InitiatePaymentRequest(referenceNumber,
                                                  amount,
                                                  currency.GetValue(),
                                                  redirectUrl,
                                                  customerName,
                                                  customerEmail,
                                                  customerPhoneNumber,
                                                  paymentTitle,
                                                  paymentDescription,
                                                  brandLogoUrl,
                                                  splitPayments);

            return _flutterwaveApi.Post<InitiatePaymentResponse>(Endpoints.PAYMENTS, data);
        }
    }
}
