using Flutterwave.Net;
using System.Configuration;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class TransactionsTests
    {
        private readonly Transactions transactions;

        public TransactionsTests()
        {
            // Get your rave secret key from your config file
            var raveSecretKey = ConfigurationManager.AppSettings.Get("RaveSecretKey");
            transactions = new Transactions(new FlutterwaveApi(raveSecretKey));
        }

        [Fact]
        public void GetTransactions_ReturnsAllTransactions()
        {
            // Act
            var result = transactions.GetTransactions();

            // Assert
            Assert.NotNull(result); 
            Assert.IsType<RaveGetTransactionsResponse>(result);
            Assert.Equal(expected: "error", actual: result.Status);
            Assert.Equal(expected: "Transactions fetched", actual: result.Message);
        }
    }
}
