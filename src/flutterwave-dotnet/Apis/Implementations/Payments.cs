using System.Collections.Generic;
using Flutterwave.Net.Utilities;

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
        /// Cancel an existing payment plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// The unique id of the Payment Plan you want to cancel, it is returned in the 
        /// Get Payment Plan call as data.id
        /// </param>
        /// <returns>Success message</returns>
        public PaymentPlanResponse CancelPaymentPlan(int paymentPlanId)
        {
            return _flutterwaveApi.Put<PaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}/cancel");
        }

        /// <summary>
        /// Create a payment plan
        /// </summary>
        /// <param name="amount">
        /// This is the amount to charge all customers subscribed to this plan
        /// </param>
        /// <param name="name">
        /// This is the name of the payment plan, it will appear on the subscription reminder emails
        /// </param>
        /// <param name="interval">
        /// This will determine the frequency of the charges for this plan
        /// </param>
        /// <param name="duration">
        /// This is the frequency, it is numeric, e.g. if set to 5 and intervals is set to monthly 
        /// you would be charged 5 months, and then the subscription stops
        /// </param>
        /// <returns>The newly created payment plan details</returns>
        public PaymentPlanResponse CreatePaymentPlan(decimal amount,
                                                     string name,
                                                     Interval interval,
                                                     int duration)
        {
            var data = new CreatePaymentPlanRequest(amount,
                                                    name,
                                                    interval.GetValue(),
                                                    duration);

            return _flutterwaveApi.Post<PaymentPlanResponse>(Endpoints.PAYMENT_PLANS, data);
        }

        /// <summary>
        /// Get a single payment plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// Unique payment plan Id, it is returned in the Get Payment Plans call as data.id
        /// </param>
        /// <returns>A payment plan</returns>
        public PaymentPlanResponse GetPaymentPlan(int paymentPlanId)
        {
            return _flutterwaveApi.Get<PaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}");
        }

        /// <summary> 
        /// Get all payment plans 
        /// </summary>
        /// <param name="amount">
        /// This is the exact amount set when creating the payment plan
        /// </param>
        /// <param name="from">
        /// This is the specified date to start the list from. YYYY-MM-DD
        /// </param>
        /// <param name="to">
        /// This is the specified end period for the search. YYYY-MM-DD 
        /// </param>
        /// <param name="page">
        /// This is the page number to retrieve
        /// </param>
        /// <param name="currency">
        /// This is the currency the payment plan amount is charged in
        /// </param>
        /// <param name="interval">
        /// This is how often the payment plan is set to execute
        /// </param>
        /// <param name="status">
        /// This is the status of the payment plan
        /// </param>
        /// <returns>A list of payment plans</returns>
        public GetPaymentPlansResponse GetPaymentPlans(decimal amount = 0, 
                                                       string from = null, 
                                                       string to = null, 
                                                       int page = 1, 
                                                       Currency currency = Currency.NigerianNaira, 
                                                       string interval = null, 
                                                       string status = null)
        {

            if (page <= 0) 
                page = 1;

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "currency", currency.GetValue() }
            };

            if (amount > 0)
                queryParameters.Add("amount", amount.ToString());

            if (!string.IsNullOrEmpty(from))
                queryParameters.Add("from", from);

            if (!string.IsNullOrEmpty(to))
                queryParameters.Add("to", to);

            if (!string.IsNullOrEmpty(interval))
                queryParameters.Add("interval", interval);

            if (!string.IsNullOrEmpty(status))
                queryParameters.Add("status", status);

            return _flutterwaveApi.Get<GetPaymentPlansResponse>(Endpoints.PAYMENT_PLANS, queryParameters);
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
        /// List of parameters to split payment. It is called subaccounts on the offical 
        /// documentation
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

        /// <summary>
        /// Update an existing payment plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// The unique id of the payment plan you want to delete, it is returned in the Get Payment Plan call as data.id
        /// </param>
        /// <param name="name">The new name of the payment plan</param>
        /// <param name="status">The new status of the payment plan</param>        
        /// <returns>The updated payment plan details</returns>
        public PaymentPlanResponse UpdatePaymentPlan(int paymentPlanId,
                                                     string name,
                                                     PaymentPlanStatus status)
        {
            var data = new UpdatePaymentPlanRequest(name, status.GetValue());

            return _flutterwaveApi.Put<PaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}", data);
        }
    }
}
