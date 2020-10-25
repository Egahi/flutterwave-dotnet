using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class MiscellaneousTests
    {
        private IFlutterwaveApi _api;

        public MiscellaneousTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FLUTTERWAVESECRETKEY");

            _api = new FlutterwaveApi(flutterwaveSecretKey);
        }

        [Fact]
        public void VerifyBankAccount_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string bankCode = AppConstants.ACCESS_BANK_CODE;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Miscellaneous.VerifyBankAccount(accountNumber, bankCode);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VerifyBankAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void VerifyBankAccount_ValidSecretKey_InvalidAccountNumber_ReturnsError()
        {
            // Arrange
            string accountNumber = AppConstants.INVALID_ACCOUNT_NUMBER;
            string bankCode = AppConstants.ACCESS_BANK_CODE;

            // Act
            var result = _api.Miscellaneous.VerifyBankAccount(accountNumber, bankCode);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VerifyBankAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.VERIFY_BANK_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void VerifyBankAccount_ValidSecretKey_ValidAccountNumber_InvalidBankCode_ReturnsError()
        {
            // Arrange
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string bankCode = AppConstants.INVALID_BANK_CODE;

            // Act
            var result = _api.Miscellaneous.VerifyBankAccount(accountNumber, bankCode);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VerifyBankAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.VERIFY_BANK_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void VerifyBankAccount_ValidSecretKey_ValidAccountNumber_ValidBankCode_ReturnsBankAccountDetails()
        {
            // Arrange
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string bankCode = AppConstants.ACCESS_BANK_CODE;

            // Act
            var result = _api.Miscellaneous.VerifyBankAccount(accountNumber, bankCode);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VerifyBankAccountResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.VERIFY_BANK_ACCOUNT_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<BankAccount>(result.Data);
            Assert.Equal(expected: AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER, actual: result.Data.AccountNumber);
            Assert.Equal(expected: AppConstants.VALID_ACCESSBANK_ACCOUNT_NAME, actual: result.Data.AccountName);
        }

        [Fact]
        public void VerifyBankAccount_ValidSecretKey_ValidAccountNumber_WrongBankCode_ReturnsError()
        {
            // Arrange
            string accountNumber = AppConstants.VALID_ACCESSBANK_ACCOUNT_NUMBER;
            string bankCode = AppConstants.FIRST_BANK_CODE;

            // Act
            var result = _api.Miscellaneous.VerifyBankAccount(accountNumber, bankCode);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VerifyBankAccountResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.VERIFY_BANK_ACCOUNT_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

    }
}
