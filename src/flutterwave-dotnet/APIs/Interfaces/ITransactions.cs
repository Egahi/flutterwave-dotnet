namespace Flutterwave.Net
{
    public interface ITransactions
    {
        /// <summary>
        /// Get transaction fees
        /// </summary>
        /// <param name="amount">This is the amount of the product or service to be charged from the customer</param>
        /// <param name="currency">This is the specified currency to charge in</param>
        /// <returns>The transaction fees</returns>
        public GetTransactionFeeResponse GetTransactionFee(decimal amount,
                                                           Currency currency = Currency.NigerianNaira);

        /// <summary>
        /// Get all Transactions
        /// </summary>
        /// <param name="from">This is the specified date to start the list from. YYYY-MM-DD</param>
        /// <param name="to">The is the specified end period for the search . YYYY-MM-DD</param>
        /// <param name="page">This is the page number to retrieve</param>
        /// <param name="customerEmail">This is the email of the customer who carried out a transaction. Use for more specific listing.</param>
        /// <param name="status">This is the transaction status to filter the listing</param>
        /// <param name="txRef">This is the merchant reference tied to a transaction. Use for more specific listing</param>
        /// <param name="customerFullName">This is the combination of the customer first name and last name passed to rave during transaction.</param>
        /// <param name="currency">This is the currency the transaction list should come in</param>
        /// <returns>A list of transactions</returns>
        public GetTransactionsResponse GetTransactions(string from = null,
                                                       string to = null,
                                                       int page = 1,
                                                       string customerEmail = null,
                                                       TransactionStatus? status = null,
                                                       string txRef = null,
                                                       string customerFullName = null,
                                                       Currency currency = Currency.NigerianNaira);

        /// <summary>
        /// Verify a transaction
        /// </summary>
        /// <param name="transactionId">
        /// This is the transaction unique identifier. It is returned in the Get transactions 
        /// call as data.Id
        /// </param>
        /// <returns>The transaction with the specified id</returns>
        public VerifyTransactionResponse VerifyTransaction(int transactionId);




        /// <summary>
        /// Resend transaction webhook
        /// </summary>
        /// <param name="transactionId"></param>
        /// This is the transaction unique identifier. It is returned in the Get transactions 
        /// <param name="wait"></param>
        /// If this is passed the endpoint would hold for the hook response and return what you respond with as the response. 
        /// The expected value is 1
        /// <returns>Success or Error if no hook was found</returns>
        ResendTransactionWebhookResponse ResendTransactionWebhook(int transactionId, int wait = 1);
    }
}
