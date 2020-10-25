using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class SubAccountsTests
    {
        private IFlutterwaveApi _api;

        public SubAccountsTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FLUTTERWAVESECRETKEY");

            _api = new FlutterwaveApi(flutterwaveSecretKey);
        }

        [Fact]
        public void CreateSubAccount_ExistingSubAccountWithAccountNumberAndBank_ReturnsError()
        {
            // Arrange
            // Create a sub account to test with
            var createTestSubAccountReponse = CreateTestSubAccount();

            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _api.SubAccounts.CreateSubAccount(bankCode,
                                                           accountNumber,
                                                           businessName,
                                                           businessEmail,
                                                           Country.Nigeria,
                                                           SplitType.Percentage,
                                                           splitValue,
                                                           businessContact,
                                                           businessContactMobile,
                                                           businessMobile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.EXISTING_SUB_ACCOUNT_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);

            // Delete test subAccount
            // for purposing of re-creating in future test runs
            DeleteTestSubAccount(createTestSubAccountReponse.Data.Id);
        }

        [Fact]
        public void CreateSubAccount_InvalidBankCode_ReturnsError()
        {
            // Arrange
            string bankCode = AppConstants.INVALID_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _api.SubAccounts.CreateSubAccount(bankCode,
                                                           accountNumber,
                                                           businessName,
                                                           businessEmail,
                                                           Country.Nigeria,
                                                           SplitType.Percentage,
                                                           splitValue,
                                                           businessContact,
                                                           businessContactMobile,
                                                           businessMobile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.COULD_NOT_VERIFY_ACCOUNT_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CreateSubAccount_InvalidEmailAddress_ReturnsError()
        {
            // Arrange
            string bankCode = AppConstants.INVALID_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.INVALID_EMAIL;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _api.SubAccounts.CreateSubAccount(bankCode,
                                                           accountNumber,
                                                           businessName,
                                                           businessEmail,
                                                           Country.Nigeria,
                                                           SplitType.Percentage,
                                                           splitValue,
                                                           businessContact,
                                                           businessContactMobile,
                                                           businessMobile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_EMAIL + AppConstants.INVALID_EMAIL_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CreateSubAccount_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.SubAccounts.CreateSubAccount(bankCode,
                                                           accountNumber,
                                                           businessName,
                                                           businessEmail,
                                                           Country.Nigeria,
                                                           SplitType.Percentage,
                                                           splitValue,
                                                           businessContact,
                                                           businessContactMobile,
                                                           businessMobile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CreateSubAccount_InvalidSplitValue_ReturnsError()
        {
            // Arrange
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.INVALID_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            double splitValue = 1.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _api.SubAccounts.CreateSubAccount(bankCode,
                                                           accountNumber,
                                                           businessName,
                                                           businessEmail,
                                                           Country.Nigeria,
                                                           SplitType.Percentage,
                                                           splitValue,
                                                           businessContact,
                                                           businessContactMobile,
                                                           businessMobile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_SPLIT_VALUE_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CreateSubAccount_ValidAccountNumber_WrongBankCode_ReturnsError()
        {
            // Arrange
            string bankCode = AppConstants.FIRST_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _api.SubAccounts.CreateSubAccount(bankCode,
                                                           accountNumber,
                                                           businessName,
                                                           businessEmail,
                                                           Country.Nigeria,
                                                           SplitType.Percentage,
                                                           splitValue,
                                                           businessContact,
                                                           businessContactMobile,
                                                           businessMobile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.COULD_NOT_VERIFY_ACCOUNT_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CreateSubAccount_ValidParamters_ReturnsSubAccount()
        {
            // Arrange
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _api.SubAccounts.CreateSubAccount(bankCode,
                                                           accountNumber,
                                                           businessName,
                                                           businessEmail,
                                                           Country.Nigeria,
                                                           SplitType.Percentage,
                                                           splitValue,
                                                           businessContact,
                                                           businessContactMobile,
                                                           businessMobile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CREATE_SUB_ACCOUNT_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<SubAccount>(result.Data);
            Assert.Equal(expected: AppConstants.ACCESS_BANK_CODE, actual: result.Data.BankCode);
            Assert.Equal(expected: AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER, actual: result.Data.AccountNumber);
            Assert.Equal(expected: AppConstants.SPLIT_TYPE_PERCENTAGE, actual: result.Data.SplitType);
            Assert.Equal(expected: (decimal)0.5, actual:result.Data.SplitValue, 
                precision: AppConstants.ONE_DECIMAL_PLACE);
            Assert.Equal(expected:AppConstants.ACCESS_BANK, actual:result.Data.BankName);

            // Delete subAccount
            // for purposing of re-creating in future test runs
            DeleteTestSubAccount(result.Data.Id);
        }

        [Fact]
        public void DeleteSubAccount_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.SubAccounts.DeleteSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void DeleteSubAccount_InvalidId_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;

            // Act
            var result = _api.SubAccounts.DeleteSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.DELETE_SUB_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void DeleteSubAccount_ValidId_ReturnsSuccessMessage()
        {
            // Arrange
            // Create a sub account to test with
            var createTestSubAccountReponse = CreateTestSubAccount();
            int subAccountId = createTestSubAccountReponse.Data.Id;

            // Act
            var result = _api.SubAccounts.DeleteSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.DELETE_SUB_ACCOUNT_SUCCESS_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetSubAccount_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.SubAccounts.GetSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetSubAccount_ValidSecretKey_InvalidSubAccountsId_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;

            // Act 
            var result = _api.SubAccounts.GetSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetSubAccount_ValidSecretKey_ValidSubAccountId_ReturnsSubAccount()
        {
            // Arrange
            // Create a sub account to test with
            var createTestSubAccountReponse = CreateTestSubAccount();
            int subAccountId = createTestSubAccountReponse.Data.Id;

            // Act
            var result = _api.SubAccounts.GetSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNT_SUCCESS_MESSAGE, 
                actual: result.Message);
            Assert.IsType<SubAccount>(result.Data);
            Assert.Equal(expected: subAccountId, actual: result.Data.Id);

            // Delete test subAccount
            // for purposing of re-creating in future test runs
            DeleteTestSubAccount(createTestSubAccountReponse.Data.Id);
        }

        [Fact]
        public void GetSubAccounts_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.SubAccounts.GetSubAccounts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetSubAccounts_ValidSecretKey_ReturnsAllSubAccounts()
        {
            // Act
            var result = _api.SubAccounts.GetSubAccounts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNTS_SUCCESS_MESSAGE, 
                actual: result.Message);
            Assert.IsType<List<SubAccount>>(result.Data);
        }

        [Fact]
        public void UpdateSubAccounts_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;

            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            double splitValue = 0.5;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.SubAccounts.UpdateSubAccount(subAccountId,
                                                           businessName,
                                                           businessEmail,
                                                           bankCode,
                                                           accountNumber,
                                                           SplitType.Percentage,
                                                           splitValue);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
        }

        [Fact]
        public void UpdateSubAccount_ValidSecretKey_InvalidSubAccountId_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            double splitValue = 0.5;

            // Act
            var result = _api.SubAccounts.UpdateSubAccount(subAccountId,
                                                           businessName,
                                                           businessEmail,
                                                           bankCode,
                                                           accountNumber,
                                                           SplitType.Percentage,
                                                           splitValue);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_SUB_ACCOUNT_ERROR_MESSAGE, 
                actual: result.Message);
        }

        [Fact]
        public void UpdateSubAccount_ValidParamters_ReturnsSubAccount()
        {
            // Arrange
            // Create a sub account to test with
            var createTestSubAccountReponse = CreateTestSubAccount();

            int subAccountId = createTestSubAccountReponse.Data.Id;
            string newBusinessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string newBusinessEmail = AppConstants.SAMPLE_EMAIL;
            string newBankCode = AppConstants.ACCESS_BANK_CODE;
            string newAccountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            double newSplitValue = 0.5;

            // Act
            var result = _api.SubAccounts.UpdateSubAccount(subAccountId,
                                                           newBusinessName,
                                                           newBusinessEmail,
                                                           newBankCode,
                                                           newAccountNumber,
                                                           SplitType.Percentage,
                                                           newSplitValue);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_SUB_ACCOUNT_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<SubAccount>(result.Data);
            Assert.Equal(expected: subAccountId, actual: result.Data.Id);
            Assert.Equal(expected: AppConstants.ACCESS_BANK_CODE, actual: result.Data.BankCode);
            Assert.Equal(expected: AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER, actual: result.Data.AccountNumber);
            Assert.Equal(expected: AppConstants.SPLIT_TYPE_PERCENTAGE, actual: result.Data.SplitType);
            Assert.Equal(expected: (decimal)0.5, actual: result.Data.SplitValue,
                precision: AppConstants.ONE_DECIMAL_PLACE);
            Assert.Equal(expected: AppConstants.ACCESS_BANK, actual: result.Data.BankName);

            // Delete test subAccount
            // for purposing of re-creating in future test runs
            DeleteTestSubAccount(createTestSubAccountReponse.Data.Id);
        }

        /// <summary>
        /// Create test sub account for unit tests
        /// </summary>
        /// <returns></returns>
        private SubAccountResponse CreateTestSubAccount()
        {
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            var result = _api.SubAccounts.CreateSubAccount(bankCode,
                                                           accountNumber,
                                                           businessName,
                                                           businessEmail,
                                                           Country.Nigeria,
                                                           SplitType.Percentage,
                                                           splitValue,
                                                           businessContact,
                                                           businessContactMobile,
                                                           businessMobile);

            return result;
        }

        /// <summary>
        /// Delete test sub account
        /// </summary>
        /// <returns></returns>
        private void DeleteTestSubAccount(int subAccountId)
        {
            _api.SubAccounts.DeleteSubAccount(subAccountId);
        }
    }
}
