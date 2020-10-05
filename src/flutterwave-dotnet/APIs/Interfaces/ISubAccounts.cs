using Flutterwave.Net.ModelsDTO.Responses;

namespace Flutterwave.Net.APIs.Interfaces
{
    public interface ISubAccounts
    {
        /// <summary>
        /// Get all Sub Accounts
        /// </summary>
        /// <returns>A list of SubAccounts</returns>
        public GetSubAccountsResponse GetSubAccounts();
    }
}