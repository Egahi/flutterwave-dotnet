using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class TransactionsTests
    {
        private IFlutterwaveApi _api;

        public TransactionsTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FLUTTERWAVESECRETKEY");

            _api = new FlutterwaveApi(flutterwaveSecretKey);
        }

        [Fact]
        public void GetTransactionFees_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            decimal amount = 5000;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Transactions.GetTransactionFee(amount);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetTransactionFeeResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetTransactionFee_ValidSecretKey_ReturnsTransactionFees()
        {
            // Act
            decimal amount = 5000;

            var result = _api.Transactions.GetTransactionFee(amount);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetTransactionFeeResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_TRANSACTION_FEES_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<TransactionFee>(result.Data);
        }

        [Fact]
        public void GetTransactions_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);
            
            // Act
            var result = _api.Transactions.GetTransactions();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetTransactionsResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetTransactions_ValidSecretKey_ReturnsAllTransactions()
        {
            // Act
            var result = _api.Transactions.GetTransactions();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetTransactionsResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_TRANSACTIONS_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<Transaction>>(result.Data);
        }

        [Fact]
        public void GetTransactions_ValidSecretKey_QueryParameters_ReturnsAllTransactions()
        {
            // Arrange
            string from = AppConstants.START_DATE;
            string to = AppConstants.END_DATE;
            int page = 1;
            string customerEmail = AppConstants.SAMPLE_EMAIL;
            string txRef = AppConstants.SAMPLE_TX_REF;
            string customerFullName = AppConstants.SAMPLE_CUSTOMER_NAME;
            
            // Act
            var result = _api.Transactions.GetTransactions(from,
                                                           to,
                                                           page,
                                                           customerEmail, 
                                                           TransactionStatus.Successful, 
                                                           txRef,
                                                           customerFullName,
                                                           Currency.NigerianNaira);

            // Assert
            Assert.NotNull(result); 
            Assert.IsType<GetTransactionsResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_TRANSACTIONS_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<Transaction>>(result.Data);
        }

        [Fact]
        public void ResendTransactionWebhook_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int id = AppConstants.VALID_TRANSACTION_ID;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Transactions.ResendTransactionWebhook(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ResendTransactionWebhookResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void ResendTransactionWebhook_WebHookNotConfigured_ReturnsError()
        {
            // Arrange
            int id = AppConstants.VALID_TRANSACTION_ID;

            // Act
            var result = _api.Transactions.ResendTransactionWebhook(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ResendTransactionWebhookResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.RESEND_TRANSACTION_WEBHOOK_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void VerifyTransaction_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int id = AppConstants.VALID_TRANSACTION_ID;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Transactions.VerifyTransaction(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VerifyTransactionResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.VERIFY_TRANSACTION_UNAUTHORIZED_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void VerifyTransaction_ValidSecretKey_InvalidTransactionId_ReturnsError()
        {
            // Arrange
            int id = AppConstants.INVALID_TRANSACTION_ID;

            // Act
            var result = _api.Transactions.VerifyTransaction(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VerifyTransactionResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.VERIFY_TRANSACTION_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void VerifyTransaction_ValidSecretKey_ValidTransactionId_ReturnsTransactionDetails()
        {
            // Arrange
            int id = AppConstants.VALID_TRANSACTION_ID;

            // Act
            var result = _api.Transactions.VerifyTransaction(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VerifyTransactionResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.VERIFY_TRANSACTION_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<Transaction>(result.Data);
            Assert.Equal(expected: AppConstants.SAMPLE_TX_REF, actual: result.Data.TxRef);
            Assert.Equal(expected: AppConstants.SUCCESSFUL_STATUS, actual: result.Data.Status);
            Assert.Equal(expected: AppConstants.NIGERIAN_NAIRA_CODE, actual: result.Data.Currency);
        }
    }
}
