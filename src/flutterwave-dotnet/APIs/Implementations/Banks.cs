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
        /// Pass either NG, GH, KE, UG, ZA or TZ to get list of banks in Nigeria, Ghana, 
        /// Kenya, Uganda, South Africa or Tanzania respectively
        /// </param>
        /// <returns>A list of Banks</returns>
        public GetBanksResponse GetBanks(string country)
        {
            return _flutterwaveApi.Get<GetBanksResponse>($"{Endpoints.BANKS}/{country}");
        }
    }
}
