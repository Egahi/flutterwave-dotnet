using Flutterwave.Net.Utilities;

namespace Flutterwave.Net
{
    public class SubAccounts : ISubAccounts
    {
        private FlutterwaveApi _flutterwaveApi { get; }

        public SubAccounts(FlutterwaveApi flutterwaveApi)
        {
            _flutterwaveApi = flutterwaveApi;
        }

        /// <summary>
        /// Create a subaccount
        /// </summary>
        /// <param name="bankCode">
        /// This is the sub-accounts bank ISO code. 
        /// It is returned in the Get banks call as data.Code
        /// </param>
        /// <param name="accountNumber">
        /// This is the customer's account number.
        /// </param>
        /// <param name="businessName">
        /// This is the sub-account business name.
        /// </param>
        /// <param name="businessEmail">
        /// This is the sub-account business email
        /// </param>
        /// <param name="country">
        /// Merchant's country
        /// </param>
        /// <param name="splitType">
        /// This can be set as percentage or flat
        /// </param>
        /// <param name="splitValue">
        /// This can be a percentage value or flat value depending on what was set on splitType. 
        /// Note that the % value is in decimal. So 50% is 0.5 and so on.
        /// </param>
        /// <param name="businessContact">
        /// This is the contact person for the sub account
        /// </param>
        /// <param name="businessContactMobile">
        /// Business contact phone number
        /// </param>
        /// <param name="businessMobile">
        /// Primary business phone number
        /// </param>
        /// <returns>The newly created sub account details</returns>
        public SubAccountResponse CreateSubAccount(string bankCode,
                                                   string accountNumber,
                                                   string businessName,
                                                   string businessEmail,
                                                   Country country,
                                                   SplitType splitType,
                                                   double splitValue,
                                                   string businessContact = "",
                                                   string businessContactMobile = "",
                                                   string businessMobile = "")
        {
            var data = new CreateSubAccountRequest(bankCode,
                                                   accountNumber,
                                                   businessName,
                                                   businessEmail,
                                                   country.GetValue(),
                                                   splitType.GetValue(),
                                                   splitValue,
                                                   businessContact,
                                                   businessContactMobile,
                                                   businessMobile);

            return _flutterwaveApi.Post<SubAccountResponse>(Endpoints.SUB_ACCOUNTS, data);
        }

        /// <summary>
        /// Delete a sub account
        /// </summary>
        /// <param name="subAccountId">
        /// The unique id of the sub account you want to delete, it is returned 
        /// in the Get SubAccount call as data.Id
        /// </param>
        /// <returns>Success message</returns>
        public SubAccountResponse DeleteSubAccount(int subAccountId)
        {
            return _flutterwaveApi.Delete<SubAccountResponse>(
                $"{Endpoints.SUB_ACCOUNTS}/{subAccountId}");
        }

        /// <summary>
        /// Get a single sub account
        /// </summary>
        /// <param name="subAccountId">
        /// Unique sub account Id, it is returned in the Get SubAccounts call as data.Id
        /// </param>
        /// <returns>A Sub Account</returns>
        public SubAccountResponse GetSubAccount(int subAccountId)
        {
            return _flutterwaveApi.Get<SubAccountResponse>(
                $"{Endpoints.SUB_ACCOUNTS}/{subAccountId}");
        }

        /// <summary>
        /// Get all sub accounts
        /// </summary>
        /// <returns>A list of sub accounts</returns>
        public GetSubAccountsResponse GetSubAccounts()
        {
            return _flutterwaveApi.Get<GetSubAccountsResponse>(Endpoints.SUB_ACCOUNTS);
        }

        /// <summary>
        /// Update a subaccount
        /// </summary>
        /// <param name="subAccountId">
        /// The unique id of the sub account you want to delete, it is returned in the Get SubAccount call as data.Id
        /// </param>
        /// <param name="businessName">
        /// This is the sub-account business name
        /// </param>
        /// <param name="businessEmail">
        /// This is the sub-account business email
        /// </param>        
        /// <param name="bankCode">
        /// This is the sub-accounts bank ISO code. It is returned in the Get banks call as data.code
        /// </param>
        /// <param name="accountNumber">
        /// This is the customer's account number
        /// </param>
        /// <param name="splitType">
        /// This can be set as percentage or flat
        /// </param>
        /// <param name="splitValue">
        /// This can be a percentage value or flat value depending on what was set on splitType. 
        /// Note that the % value is in decimal. So 50% is 0.5 and so on.
        /// </param>
        /// <returns>The updated sub account details</returns>
        public SubAccountResponse UpdateSubAccount(int subAccountId,
                                                   string businessName, 
                                                   string businessEmail, 
                                                   string bankCode, 
                                                   string accountNumber, 
                                                   SplitType splitType, 
                                                   double splitValue)
        {
            var data = new UpdateSubAccountRequest(businessName,
                                                   businessEmail,
                                                   bankCode,
                                                   accountNumber,
                                                   splitType.GetValue(),
                                                   splitValue);
            
            return _flutterwaveApi.Put<SubAccountResponse>(
                $"{Endpoints.SUB_ACCOUNTS}/{subAccountId}", data);
        }
    }
}
