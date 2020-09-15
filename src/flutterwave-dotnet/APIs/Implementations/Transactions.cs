using Flutterwave.Net.Utilities;

namespace Flutterwave.Net
{
    public class Transactions : ITransactions
    {
        private FlutterwaveApi FlutterwaveApi { get; }

        public Transactions(FlutterwaveApi flutterwaveApi)
        {
            FlutterwaveApi = flutterwaveApi;
        }

        /// <summary>
        /// Get all Transactions
        /// </summary>
        /// <returns></returns>
        public RaveGetTransactionsResponse GetTransactions()
        {
            return FlutterwaveApi.Get<RaveGetTransactionsResponse>(AppConstants.TRANSACTIONS);
        }
    }
}
