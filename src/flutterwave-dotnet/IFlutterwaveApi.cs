namespace Flutterwave.Net
{
    public interface IFlutterwaveApi
    {
        public IBanks Banks { get; }
        public IMiscellaneous Miscellaneous { get; }
        public IPaymentPlans PaymentPlans { get; }
        public IPayments Payments { get; }
        public ISubAccounts SubAccounts { get; }
        public ITransactions Transactions { get; }
    }
}
