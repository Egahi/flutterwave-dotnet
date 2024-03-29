﻿using Flutterwave.Net.Utilities;

namespace Flutterwave.Net
{
    public class Miscellaneous : IMiscellaneous
    {
        private FlutterwaveApi _flutterwaveApi { get; }

        public Miscellaneous(FlutterwaveApi flutterwaveApi)
        {
            _flutterwaveApi = flutterwaveApi;
        }

        /// <summary>
        /// Verify a bank account number
        /// </summary>
        /// <param name="accountNumber">
        /// Account number to be verified
        /// </param>
        /// <param name="bankCode">
        /// Bank code. It is returned in the Get banks call as data.Code
        /// </param>
        /// <returns>The bank account name and number</returns>
        public VerifyBankAccountResponse VerifyBankAccount(string accountNumber, 
                                                           string bankCode)
        {
            var data = new VerifyBankAccountRequest(accountNumber, bankCode);

            return _flutterwaveApi.Post<VerifyBankAccountResponse>(
                Endpoints.BANK_ACCOUNT_VERIFICATION, data);
        }
    }
}
