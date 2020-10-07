using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class SubAccountsTests
    {
        private SubAccounts _subAccounts;

        public SubAccountsTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FLUTTERWAVESECRETKEY");

            _subAccounts = new SubAccounts(new FlutterwaveApi(flutterwaveSecretKey));
        }


        //Facts
        [Fact]
        public void GetSubAccounts_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _subAccounts = new SubAccounts(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _subAccounts.GetSubAccounts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }
        
        [Fact]
        public void GetSubAccounts_ValidSecretKey_ReturnsAllTransactions()
        {
            // Act
            var result = _subAccounts.GetSubAccounts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNTS_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<GetSubAccounts>>(result.Data);
        }

        [Fact]
        public void GetSubAccountsById_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int id = AppConstants.VALID_SUBACCOUNTS_ID;

            var flutterwaveSecretKey = "";
            _subAccounts = new SubAccounts(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _subAccounts.GetSubAccountsById(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsByIdResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetSubAccountsById_ValidSecretKey_SubAccountsId_ReturnsError()
        {
            // Arrange
            int id = AppConstants.INVALID_SUBACCOUNTS_ID;

            // Act 
            var result = _subAccounts.GetSubAccountsById(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsByIdResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNTS_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetSubAccountsById_ValidSecretKey_ReturnsSubAccounts()
        {
            // Arrange
            int id = AppConstants.VALID_SUBACCOUNT_ID;

            // Act
            var result = _subAccounts.GetSubAccountsById(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsByIdResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNTSBYID_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<GetSubAccounts>(result.Data);
        }

        [Fact]
        public void CreateSubAccount_ExistingSubAccountWithAccountNumberAndBank_ReturnsError()
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
            var result = _subAccounts.CreateSubAccount(bankCode,
                                                       accountNumber,
                                                       businessName,
                                                       businessEmail,
                                                       Country.Nigeria,
                                                       SplitType.Percentage,
                                                       splitValue,
                                                       businessContact,
                                                       businessContactMobile,
                                                       businessMobile);

            result = _subAccounts.CreateSubAccount(bankCode,
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
            Assert.IsType<CreateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.EXISTING_SUB_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);

            // TODO
            // Delete subaccount
        }

        //[Fact]
        public void CreateSubAccount_InvalidAccountNumber_ReturnsError()
        {
            // Arrange
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.INVALID_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            string country = AppConstants.NIGERIA_CODE;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _subAccounts.CreateSubAccount(bankCode,
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
            Assert.IsType<CreateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.COULD_NOT_VERIFY_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CreateSubAccount_InvalidBankCode_ReturnsError()
        {
            // Arrange
            string bankCode = AppConstants.INVALID_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            string country = AppConstants.NIGERIA_CODE;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _subAccounts.CreateSubAccount(bankCode,
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
            Assert.IsType<CreateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.COULD_NOT_VERIFY_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
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
            string country = AppConstants.NIGERIA_CODE;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _subAccounts.CreateSubAccount(bankCode,
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
            Assert.IsType<CreateSubAccountResponse>(result);
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
            string country = AppConstants.NIGERIA_CODE;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            var flutterwaveSecretKey = "";
            _subAccounts = new SubAccounts(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _subAccounts.CreateSubAccount(bankCode,
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
            Assert.IsType<CreateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
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
            string country = AppConstants.NIGERIA_CODE;
            double splitValue = 1.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _subAccounts.CreateSubAccount(bankCode,
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
            Assert.IsType<CreateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_SPLIT_VALUE_ERROR_MESSAGE, actual: result.Message);
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
            string country = AppConstants.NIGERIA_CODE;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _subAccounts.CreateSubAccount(bankCode,
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
            Assert.IsType<CreateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.COULD_NOT_VERIFY_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        //[Fact]
        public void CreateSubAccount_ValidParamters_ReturnsSubAccount()
        {
            // Arrange
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;
            string businessEmail = AppConstants.SAMPLE_EMAIL;
            string country = AppConstants.NIGERIA_CODE;
            double splitValue = 0.5;
            string businessContact = AppConstants.SAMPLE_CUSTOMER_NAME;
            string businessContactMobile = AppConstants.SAMPLE_PHONE_NUMBER;
            string businessMobile = AppConstants.SAMPLE_PHONE_NUMBER;

            // Act
            var result = _subAccounts.CreateSubAccount(bankCode,
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
            Assert.IsType<CreateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CREATE_SUB_ACCOUNT_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<SubAccount>(result.Data);
            Assert.Equal(expected: AppConstants.ACCESS_BANK_CODE, actual: result.Data.BankCode);
            Assert.Equal(expected: AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER, actual: result.Data.AccountNumber);
            Assert.Equal(expected: AppConstants.SPLIT_TYPE_PERCENTAGE, actual: result.Data.SplitType);
            Assert.Equal(expected: AppConstants.ONE_POINT_FIVE_DECIMAL, actual:result.Data.SplitValue, 
                precision: AppConstants.ONE_DECIMAL_PLACE);
            Assert.Equal(expected:AppConstants.ACCESS_BANK_CODE, actual:result.Data.BankName);

            // TODO
            // Delete subaccount
        }


    }
}
