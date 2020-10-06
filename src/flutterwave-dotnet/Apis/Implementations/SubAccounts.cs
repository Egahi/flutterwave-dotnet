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
        /// It is returned in the Get banks call as data.code
        /// </param>
        /// <param name="accountNumber">This is the customer's account number.</param>
        /// <param name="businessName">This is the sub-account business name.</param>
        /// <param name="businessEmail">This is the sub-account business email</param>
        /// <param name="country">Merchant's country</param>
        /// <param name="splitType">This can be set as percentage or flat</param>
        /// <param name="splitValue">
        /// This can be a percentage value or flat value depending on what was set on splitType. 
        /// Note that the % value is in decimal. So 50% is 0.5 and so on.
        /// </param>
        /// <param name="businessContact">This is the contact person for the sub-account</param>
        /// <param name="businessContactMobile">Business contact phone number</param>
        /// <param name="businessMobile">Primary business phone number</param>
        /// <returns>The newly created subaccount details</returns>
        public CreateSubAccountResponse CreateSubAccount(string bankCode,
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

            return _flutterwaveApi.Post<CreateSubAccountResponse>(Endpoints.SUB_ACCOUNTS, data);
        }

        /// <summary>
        /// Delete a subaccount
        /// </summary>
        /// <param name="id">The unique id of the sub account you want to delete</param>
        /// <returns></returns>
        public DeleteSubAccountResponse DeleteSubAccount(int id)
        {
            return _flutterwaveApi.Delete<DeleteSubAccountResponse>($"{Endpoints.SUB_ACCOUNTS}/{id}");
        }
    }
}
