namespace Flutterwave.Net
{
    public interface ITransactions
    {
        /// <summary>
        /// Get all Transactions
        /// </summary>
        /// <returns></returns>
        public GetTransactionsResponse GetTransactions();
    }
}
