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
        /// <returns>A list of Transactions</returns>
        public GetTransactionsResponse GetTransactions()
        {
            return _flutterwaveApi.Get<GetTransactionsResponse>(Endpoints.TRANSACTIONS);
        }

        /// <summary>
        /// Verify a transaction
        /// </summary>
        /// <param name="id">
        /// This is the transaction unique identifier. It is returned in the Get transactions 
        /// call as data.id
        /// </param>
        /// <returns>The transaction with the specified id</returns>
        public VerifyTransactionResponse VerifyTransaction(int id)
        {
            return _flutterwaveApi.Get<VerifyTransactionResponse>($"{Endpoints.TRANSACTIONS}/{id}/verify");
        }
    }
}
