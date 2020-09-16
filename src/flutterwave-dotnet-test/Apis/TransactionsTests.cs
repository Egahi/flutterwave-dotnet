using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
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
        public void GetTransactions_ValidSecretKey_ReturnsAllTransactions()
        {
            // Act
            var result = _transactions.GetTransactions();

            // Assert
            Assert.NotNull(result); 
            Assert.IsType<RaveGetTransactionsResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS, actual: result.Status);
            Assert.Equal(expected: AppConstants.TRANSACTION_FETCHED, actual: result.Message);
        }


        [Fact]
        public void GetTransactions_InValidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _transactions = new Transactions(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _transactions.GetTransactions();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RaveGetTransactionsResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY, actual: result.Message);
            Assert.Null(result.Data);
        }
    }
}
