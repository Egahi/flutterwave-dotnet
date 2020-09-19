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
        /// Get all transactions
        /// </summary>
        /// <returns></returns>
        public GetTransactionsResponse GetTransactions()
        {
            return _flutterwaveApi.Get<GetTransactionsResponse>(Endpoints.TRANSACTIONS);
        }
    }
}
