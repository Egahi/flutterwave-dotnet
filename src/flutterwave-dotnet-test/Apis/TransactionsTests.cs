using Flutterwave.Net;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class TransactionsTests
    {
        private readonly Transactions transactions;

        public TransactionsTests()
        {
            // Get rave secret key from environmental variables

            // GitHub
            var raveSecretKey = System.Environment.GetEnvironmentVariable("RaveSecretKey",
                System.EnvironmentVariableTarget.Process);

            // Local - Windows
            //var raveSecretKey = System.Environment.GetEnvironmentVariable("RaveSecretKey",
            //    System.EnvironmentVariableTarget.Machine);

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
            Assert.Equal(expected: "success", actual: result.Status);
            Assert.Equal(expected: "Transactions fetched", actual: result.Message);
        }
    }
}
