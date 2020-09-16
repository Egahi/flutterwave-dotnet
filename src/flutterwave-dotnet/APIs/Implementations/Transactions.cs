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
        /// Get all Transactions
        /// </summary>
        /// <returns></returns>
        public RaveGetTransactionsResponse GetTransactions()
        {
            return _flutterwaveApi.Get<RaveGetTransactionsResponse>(AppConstants.TRANSACTIONS);
        }
    }
}
