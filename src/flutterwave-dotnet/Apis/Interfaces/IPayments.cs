using System.Collections.Generic;

namespace Flutterwave.Net
{
    public interface IPayments
    {
        /// <summary>
         /// Cancel an existing payment plan
         /// </summary>
         /// <param name="paymentPlanId">
         /// The unique id of the Payment Plan you want to cancel, it is returned in the Get Payment Plan call as data.id
         /// </param>
         /// <returns>Success message</returns>
        public PaymentPlanResponse CancelPaymentPlan(int paymentPlanId);

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
                                                     int duration);

        /// <summary>
        /// Get a single payment plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// Unique payment plan Id, it is returned in the Get Payment Plans call as data.id
        /// </param>
        /// <returns>A payment plan</returns>
        public PaymentPlanResponse GetPaymentPlan(int paymentPlanId);

        /// <summary>
        /// Get all payment plans
        /// </summary>
        /// <returns>A list of payment plans</returns>
        public GetPaymentPlansResponse GetPaymentPlans();

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
                                                       List<SplitPaymentRequest> splitPaymentRequests = null);

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
                                                     Status status);
    }
}
