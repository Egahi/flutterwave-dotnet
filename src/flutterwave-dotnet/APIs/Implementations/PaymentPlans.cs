using Flutterwave.Net.Utilities;

namespace Flutterwave.Net
{
    public class PaymentPlans : IPaymentPlans
    {
        private FlutterwaveApi _flutterwaveApi { get; }

        public PaymentPlans(FlutterwaveApi flutterwaveApi)
        {
            _flutterwaveApi = flutterwaveApi;
        }

        /// <summary>
        /// Cancel an existing payment plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// The unique id of the Payment Plan you want to cancel, it is returned in the Get Payment Plan call as data.id
        /// </param>
        /// <returns>Success message</returns>
        public CancelPaymentPlanResponse CancelPaymentPlan(int paymentPlanId)
        {
            return _flutterwaveApi.Put<CancelPaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}/cancel");
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
        public CreatePaymentPlanResponse CreatePaymentPlan(decimal amount,
                                                           string name,
                                                           Interval interval,
                                                           int duration)
        {
            var data = new CreatePaymentPlanRequest(amount,
                                                    name,
                                                    interval.GetValue(),
                                                    duration);

            return _flutterwaveApi.Post<CreatePaymentPlanResponse>(Endpoints.PAYMENT_PLANS, data);
        }

        /// <summary>
        /// Get a single payment plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// Unique payment plan Id, it is returned in the Get Payment Plans call as data.id
        /// </param>
        /// <returns>A payment plan</returns>
        public GetPaymentPlanResponse GetPaymentPlan(int paymentPlanId)
        {
            return _flutterwaveApi.Get<GetPaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}");
        }

        /// <summary>
        /// Get all payment plans
        /// </summary>
        /// <returns>A list of payment plans</returns>
        public GetPaymentPlansResponse GetPaymentPlans()
        {
            return _flutterwaveApi.Get<GetPaymentPlansResponse>(Endpoints.PAYMENT_PLANS);
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
        public UpdatePaymentPlanResponse UpdatePaymentPlan(int paymentPlanId,
                                                           string name,
                                                           Status status)
        {
            var data = new UpdatePaymentPlanRequest(name, status.GetValue());
            
            return _flutterwaveApi.Put<UpdatePaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}", data);
        }

    }
}