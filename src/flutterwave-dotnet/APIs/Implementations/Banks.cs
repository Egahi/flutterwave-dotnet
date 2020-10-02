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
        /// Get all Banks
        /// </summary>
        /// <param name="country">
        /// Get list of banks in this country
        /// </param>
        /// <returns>A list of Banks</returns>
        public GetBanksResponse GetBanks(Country country)
        {
            return _flutterwaveApi.Get<GetBanksResponse>($"{Endpoints.BANKS}/{country.GetValue()}");
        }

        /// <summary>
        /// Verify bank branches
        /// </summary>
        /// <param name="id">
        /// Unique bank ID, it is returned in the call to fetch banks here -
        /// https://developer.flutterwave.com/v3.0/reference#get-all-banks
        /// </param>
        /// <returns>A list of bank branches</returns>
        public GetBankBranchesResponse GetBankBrances(string id)
        {
            return _flutterwaveApi.Get<GetBankBranchesResponse>($"{Endpoints.BANKS}/{id}/branches");
        }
    }
}
