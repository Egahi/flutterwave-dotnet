﻿namespace Flutterwave.Net
{
    public interface ITransactions
    {
        /// <summary>
        /// Get all Transactions
        /// </summary>
        /// <returns>A list of transactions</returns>
        public GetTransactionsResponse GetTransactions();

        /// <summary>
        /// Verify a transaction
        /// </summary>
        /// <param name="transactionId">
        /// This is the transaction unique identifier. It is returned in the Get transactions 
        /// call as data.Id
        /// </param>
        /// <returns>The transaction with the specified id</returns>
        public VerifyTransactionResponse VerifyTransaction(int transactionId);
    }
}
