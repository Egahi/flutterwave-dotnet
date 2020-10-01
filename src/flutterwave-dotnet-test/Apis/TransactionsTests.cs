using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class TransactionsTests
    {
        private Transactions _transactions;

        public TransactionsTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FlutterwaveSecretKey");

            _transactions = new Transactions(new FlutterwaveApi(flutterwaveSecretKey));
        }

        [Fact]
        public void GetTransactions_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _transactions = new Transactions(new FlutterwaveApi(flutterwaveSecretKey));
            
            // Act
            var result = _transactions.GetTransactions();

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
            var result = _transactions.GetTransactions();

            // Assert
            Assert.NotNull(result); 
            Assert.IsType<GetTransactionsResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_TRANSACTIONS_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<Transaction>>(result.Data);
        }

        [Fact]
        public void VerifyTransaction_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            string id = AppConstants.VALID_TRANSACTION_ID;
            _transactions = new Transactions(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _transactions.VerifyTransaction(id);

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
            string id = AppConstants.INVALID_TRANSACTION_ID;

            // Act
            var result = _transactions.VerifyTransaction(id);

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
            string id = AppConstants.VALID_TRANSACTION_ID;

            // Act
            var result = _transactions.VerifyTransaction(id);

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
