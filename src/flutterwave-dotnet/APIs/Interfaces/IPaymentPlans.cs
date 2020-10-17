namespace Flutterwave.Net
{
    public interface IPaymentPlans
    {
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
                                                         decimal duration);

        /// <summary>
        /// Get all Payment Plan 
        /// </summary>
        /// <returns>A list of Payment Plans</returns>
        public GetPaymentPlansResponse GetPaymentPlans();

        /// <summary>
        /// Get a single Payment Plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// Unique payment plam Id, it is returned in the Get Payment Plans call as data.id
        /// </param>
        /// <returns>A Payment Plan</returns>
        public GetPaymentPlanResponse GetPaymentPlan(int paymentPlanId);

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
                                                         string status);

        /// <summary>
        /// Cancel a Payment Plan
        /// </summary>
        /// <param name="paymentPlanId">
        /// The unique id of the Payment Plan you want to cancel, it is returned in the Get Payment Plan call as data.id
        /// </param>
        /// <returns>Success message</returns>
        public CancelPaymentPlanResponse CancelPaymentPlan(int paymentPlanId);
    }
}