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
        /// <returns>A list of transactions</returns>
        public GetTransactionsResponse GetTransactions()
        {
            return _flutterwaveApi.Get<GetTransactionsResponse>(Endpoints.TRANSACTIONS);
        }

        /// <summary>
        /// Verify a transaction
        /// </summary>
        /// <param name="transactionId">
        /// This is the transaction unique identifier. It is returned in the Get transactions 
        /// call as data.id
        /// </param>
        /// <returns>The transaction with the specified id</returns>
        public VerifyTransactionResponse VerifyTransaction(int transactionId)
        {
            return _flutterwaveApi.Get<VerifyTransactionResponse>($"{Endpoints.TRANSACTIONS}/{transactionId}/verify");
        }
    }
}
