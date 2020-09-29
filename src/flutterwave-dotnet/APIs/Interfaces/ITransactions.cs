namespace Flutterwave.Net
{
    public interface ITransactions
    {
        /// <summary>
        /// Get all Transactions
        /// </summary>
        /// <returns>A list of Transactions</returns>
        public GetTransactionsResponse GetTransactions();

        /// <summary>
        /// Verify a transaction
        /// </summary>
        /// <param name="id">
        /// This is the transaction unique identifier. It is returned in the Get transactions 
        /// call as data.id
        /// </param>
        /// <returns>The transaction with the specified id</returns>
        public VerifyTransactionResponse VerifyTransaction(string id);
    }
}
