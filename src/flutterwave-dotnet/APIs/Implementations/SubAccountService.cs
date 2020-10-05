using Flutterwave.Net.APIs.Interfaces;
using Flutterwave.Net.ModelsDTO.Responses;
using Flutterwave.Net.Utilities;

namespace Flutterwave.Net.APIs.Implementations
{
    public class SubAccountService : ISubAccounts
    {
        private FlutterwaveApi _flutterwaveApi { get; }

        public SubAccountService(FlutterwaveApi flutterwaveApi)
        {
            _flutterwaveApi = flutterwaveApi;
        }

        public GetSubAccountsResponse GetSubAccounts()
        {
            return _flutterwaveApi.Get<GetSubAccountsResponse>(Endpoints.SUBACCOUNTS);
        }
    }
}