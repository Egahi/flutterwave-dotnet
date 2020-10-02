namespace Flutterwave.Net
{
    public interface IFlutterwaveApi
    {
        public IBanks Banks { get; }
        public IMiscellaneous Miscellaneous { get; }
        public IPayments Payments { get; }
        public ITransactions Transactions { get; }
    }
}
