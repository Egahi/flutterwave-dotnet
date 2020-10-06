using Flutterwave.Net.Utilities;

namespace Flutterwave.Net
{
    public class Banks : IBanks
    {
        private FlutterwaveApi _flutterwaveApi { get; }

        public Banks(FlutterwaveApi flutterwaveApi)
        {
            _flutterwaveApi = flutterwaveApi;
        }

        /// <summary>
        /// Get bank branches
        /// </summary>
        /// <param name="bankId">
        /// Unique bank ID, it is returned in the Get banks call as data.id
        /// </param>
        /// <returns>A list of bank branches</returns>
        public GetBankBranchesResponse GetBankBranches(int bankId)
        {
            return _flutterwaveApi.Get<GetBankBranchesResponse>($"{Endpoints.BANKS}/{bankId}/branches");
        }

        /// <summary>
        /// Get all Banks
        /// </summary>
        /// <param name="country">Get list of banks in this country</param>
        /// <returns>A list of Banks</returns>
        public GetBanksResponse GetBanks(Country country)
        {
            return _flutterwaveApi.Get<GetBanksResponse>($"{Endpoints.BANKS}/{country.GetValue()}");
        }
    }
}
