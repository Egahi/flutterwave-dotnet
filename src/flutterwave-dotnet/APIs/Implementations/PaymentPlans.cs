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
        /// Create a Payment Plans
        /// </summary>
        /// <param name="amount">This is the Amount of payment plan.</param>
        /// <param name="name">This is the name of payment plan.</param>
        /// <param name="interval">This is the selected interval of payment plan</param>
        /// <param name="duration">Length of duration for payment plan</param>
        /// <returns>The newly created sub account details</returns>
        public CreatePaymentPlanResponse CreatePaymentPlan(decimal amount,
                                                             string name,
                                                             Interval interval,
                                                             decimal duration)
        {
            var data = new CreatePaymentPlanRequest(amount,
                                                    name,
                                                    interval.GetValue(),
                                                    duration);

            return _flutterwaveApi.Post<CreatePaymentPlanResponse>(Endpoints.PAYMENT_PLANS, data);
        }

        /// <summary>
        /// Get all Payment Plan 
        /// </summary>
        /// <returns>A list of Payment Plans</returns>
        public GetPaymentPlansResponse GetPaymentPlans()
        {
            return _flutterwaveApi.Get<GetPaymentPlansResponse>(Endpoints.PAYMENT_PLANS);
        }
        
        /// <summary>
        /// Get a single Payment Plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// Unique payment plam Id, it is returned in the Get Payment Plans call as data.id
        /// </param>
        /// <returns>A Payment Plan</returns>
        public GetPaymentPlanResponse GetPaymentPlan(int paymentPlanId)
        {
            return _flutterwaveApi.Get<GetPaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}");
        }

        /// <summary>
        /// Update a Payment Plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// The unique id of the payment plan you want to delete, it is returned in the Get Payment Plan call as data.id
        /// </param>
        /// <param name="name">This is the sub-account business name</param>
        /// <param name="status">This is the sub-account business email</param>        
        /// <returns>The updated Payment Plan details</returns>
        public UpdatePaymentPlanResponse UpdatePaymentPlan(int paymentPlanId,
                                                         string name,
                                                         string status)
        {
            var data = new UpdatePaymentPlanRequest(name,
                                                    status);
            
            return _flutterwaveApi.Put<UpdatePaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}", data);
        }

        /// <summary>
        /// Cancel a Payment Plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// The unique id of the Payment Plan you want to cancel, it is returned in the Get Payment Plan call as data.id
        /// </param>
        /// <returns>Success message</returns>
        public CancelPaymentPlanResponse CancelPaymentPlan(int paymentPlanId)
        {
            var data = new UpdatePaymentPlanRequest("",
                                                    "");

            return _flutterwaveApi.Put<CancelPaymentPlanResponse>($"{Endpoints.PAYMENT_PLANS}/{paymentPlanId}/cancel", data);
        }
    }
}