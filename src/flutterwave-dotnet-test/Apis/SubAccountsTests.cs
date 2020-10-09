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
            var result1 = _subAccounts.CreateSubAccount(bankCode,
                                                        accountNumber,
                                                        businessName,
                                                        businessEmail,
                                                        Country.Nigeria,
                                                        SplitType.Percentage,
                                                        splitValue,
                                                        businessContact,
                                                        businessContactMobile,
                                                        businessMobile);

            var result2 = _subAccounts.CreateSubAccount(bankCode,
                                                        accountNumber,
                                                        businessName,
                                                        businessEmail,
                                                        Country.Nigeria,
                                                        SplitType.Percentage,
                                                        splitValue,
                                                        businessContact,
                                                        businessContactMobile,
                                                        businessMobile);

            // Delete newly created subAccount
            // for purposing of re-creating in future test runs
            _subAccounts.DeleteSubAccount(result1.Data.Id);

            // Assert
            Assert.NotNull(result2);
            Assert.IsType<CreateSubAccountResponse>(result2);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result2.Status);
            Assert.Equal(expected: AppConstants.EXISTING_SUB_ACCOUNT_ERROR_MESSAGE, actual: result2.Message);
            Assert.Null(result2.Data);
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

            // Delete newly created subAccount
            // for purposing of re-creating in future test runs
            _subAccounts.DeleteSubAccount(result.Data.Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CREATE_SUB_ACCOUNT_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<SubAccount>(result.Data);
            Assert.Equal(expected: AppConstants.ACCESS_BANK_CODE, actual: result.Data.BankCode);
            Assert.Equal(expected: AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER, actual: result.Data.AccountNumber);
            Assert.Equal(expected: AppConstants.SPLIT_TYPE_PERCENTAGE, actual: result.Data.SplitType);
            Assert.Equal(expected: (decimal)0.5, actual:result.Data.SplitValue, 
                precision: AppConstants.ONE_DECIMAL_PLACE);
            Assert.Equal(expected:AppConstants.ACCESS_BANK, actual:result.Data.BankName);
        }

        [Fact]
        public void DeleteSubAccount_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.VALID_SUBACCOUNT_ID;

            var flutterwaveSecretKey = "";
            _subAccounts = new SubAccounts(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _subAccounts.DeleteSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DeleteSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void DeleteSubAccount_InvalidId_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;

            // Act
            var result = _subAccounts.DeleteSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DeleteSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.DELETE_SUB_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void DeleteSubAccount_ValidId_ReturnsSuccessMessage()
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
            var result1 = _subAccounts.CreateSubAccount(bankCode,
                                                        accountNumber,
                                                        businessName,
                                                        businessEmail,
                                                        Country.Nigeria,
                                                        SplitType.Percentage,
                                                        splitValue,
                                                        businessContact,
                                                        businessContactMobile,
                                                        businessMobile);

            // Arrange
            int subAccountId = result1.Data.Id;

            // Act
            var result2 = _subAccounts.DeleteSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result2);
            Assert.IsType<DeleteSubAccountResponse>(result2);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result2.Status);
            Assert.Equal(expected: AppConstants.DELETE_SUB_ACCOUNT_SUCCESS_MESSAGE, actual: result2.Message);
            Assert.Null(result2.Data);
        }

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
        public void GetSubAccounts_ValidSecretKey_ReturnsAllSubAccounts()
        {
            // Act
            var result = _subAccounts.GetSubAccounts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNTS_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<SubAccount>>(result.Data);
        }

        [Fact]
        public void UpdateSubAccount_InvalidSubAccountId_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;            
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;            
            string businessEmail = AppConstants.SAMPLE_EMAIL;            
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            double splitValue = 0.5;

            // Act
            var result = _subAccounts.UpdateSubAccount(subAccountId,
                                                       businessName,
                                                       businessEmail,            
                                                       bankCode,
                                                       accountNumber,                                                       
                                                       SplitType.Percentage,
                                                       splitValue);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UpdateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_SUB_ACCOUNT_ID_ERROR_MESSAGE, actual: result.Message);
        }
      
        public void GetSubAccount_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.VALID_SUBACCOUNT_ID;

            var flutterwaveSecretKey = "";
            _subAccounts = new SubAccounts(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _subAccounts.GetSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void UpdateSubAccounts_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _subAccounts = new SubAccounts(new FlutterwaveApi(flutterwaveSecretKey));
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;            
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;            
            string businessEmail = AppConstants.SAMPLE_EMAIL;            
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            double splitValue = 0.5;

            // Act
            var result = _subAccounts.UpdateSubAccount(subAccountId,
                                                       businessName,
                                                       businessEmail,            
                                                       bankCode,
                                                       accountNumber,                                                       
                                                       SplitType.Percentage,
                                                       splitValue);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UpdateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
        }
      
        public void GetSubAccount_ValidSecretKey_InvalidSubAccountsId_ReturnsError()
        {
            // Arrange
            int subAccountId = AppConstants.INVALID_SUBACCOUNT_ID;

            // Act 
            var result = _subAccounts.GetSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void UpdateSubAccount_ValidParamters_ReturnsSubAccount()
        {
            // Arrange
            int subAccountId = AppConstants.VALID_SUBACCOUNT_ID;            
            string businessName = AppConstants.SAMPLE_BUSINESS_NAME;            
            string businessEmail = AppConstants.SAMPLE_EMAIL;            
            string bankCode = AppConstants.ACCESS_BANK_CODE;
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            double splitValue = 0.5;

            // Act
            var result = _subAccounts.UpdateSubAccount(subAccountId,
                                                       businessName,
                                                       businessEmail,            
                                                       bankCode,
                                                       accountNumber,                                                       
                                                       SplitType.Percentage,
                                                       splitValue);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UpdateSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_SUB_ACCOUNT_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<UpdateSubAccount>(result.Data);
            Assert.Equal(expected: AppConstants.ACCESS_BANK_CODE, actual: result.Data.BankCode);
            Assert.Equal(expected: AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER, actual: result.Data.AccountNumber);
            Assert.Equal(expected: AppConstants.SPLIT_TYPE_PERCENTAGE, actual: result.Data.SplitType);
            Assert.Equal(expected: (decimal)0.5, actual:result.Data.SplitValue, 
                precision: AppConstants.ONE_DECIMAL_PLACE);
            Assert.Equal(expected:AppConstants.ACCESS_BANK, actual:result.Data.BankName);
        }
      
        public void GetSubAccount_ValidSecretKey_ValidSubAccountId_ReturnsSubAccount()
        {
            // Arrange
            int subAccountId = AppConstants.VALID_SUBACCOUNT_ID;

            // Act
            var result = _subAccounts.GetSubAccount(subAccountId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNT_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<SubAccount>(result.Data);
        }
    }
}
