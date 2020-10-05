using Flutterwave.Net.Utilities;

namespace Flutterwave.Net
{
    public class BankService : IBanks
    {
        private FlutterwaveApi _flutterwaveApi { get; }

        public BankService(FlutterwaveApi flutterwaveApi)
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
    }
}