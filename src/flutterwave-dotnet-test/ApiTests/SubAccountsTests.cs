using Flutterwave.Net;
using Flutterwave.Net.APIs.Implementations;
using Flutterwave.Net.ModelsDTO.Responses;
using Flutterwave.Net.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace flutterwave_dotnet_test.ApiTests
{
    public class SubAccountsTests
    {
        private SubAccountService _subAccountService;
        
        public SubAccountsTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FLWSECK_TEST-SANDBOXDEMOKEY-X");

            _subAccountService = new SubAccountService(new FlutterwaveApi(flutterwaveSecretKey));
        }

        [Fact]
        public void GetTransactions_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _subAccountService = new SubAccountService(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _subAccountService.GetSubAccounts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UNAUTHORIZED_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetTransactions_ValidSecretKey_ReturnsAllTransactions()
        {
            // Arrange
            var flutterwaveSecretKey = "FLWSECK_TEST-SANDBOXDEMOKEY-X";

            _subAccountService = new SubAccountService(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _subAccountService.GetSubAccounts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetSubAccountsResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_SUBACCOUNT_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<SubAccountsResponse>>(result.Data);
        }
    }
}