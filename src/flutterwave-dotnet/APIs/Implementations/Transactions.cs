using Flutterwave.Net.Utilities;
using System.Collections.Generic;

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
                                                       Currency currency = Currency.NigerianNaira)
        {
            if (page <= 0)
                page = 1;

            var queryParameters = new Dictionary<string, string>()
            {
                { "page", page.ToString() },
                { "currency", currency.GetValue().ToString() }
            };

            if (!string.IsNullOrWhiteSpace(from))
                queryParameters.Add("from", from);
            
            if (!string.IsNullOrWhiteSpace(to))
                queryParameters.Add("to", to);

            if (!string.IsNullOrWhiteSpace(customerEmail))
                queryParameters.Add("customer_email", customerEmail);

            if (status != null)
                queryParameters.Add("status", status.GetValue().ToString());

            if (!string.IsNullOrWhiteSpace(txRef))
                queryParameters.Add("tx_ref", txRef);

            if (!string.IsNullOrWhiteSpace(customerFullName))
                queryParameters.Add("customer_fullname", customerFullName);

            return _flutterwaveApi.Get<GetTransactionsResponse>($"{Endpoints.TRANSACTIONS}", queryParameters);
        }

        /// <summary>
        /// Verify a transaction
        /// </summary>
        /// <param name="transactionId">
        /// This is the transaction unique identifier. It is returned in the Get transactions 
        /// call as data.Id
        /// </param>
        /// <returns>The transaction with the specified id</returns>
        public VerifyTransactionResponse VerifyTransaction(int transactionId)
        {
            return _flutterwaveApi.Get<VerifyTransactionResponse>($"{Endpoints.TRANSACTIONS}/{transactionId}/verify");
        }
    }
}
