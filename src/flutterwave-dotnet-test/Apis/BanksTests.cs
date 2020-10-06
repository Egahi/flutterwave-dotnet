using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class BanksTests
    {
        private Banks _banks;

        public BanksTests()
        {
            // Get flutterwave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FLUTTERWAVESECRETKEY");

            _banks = new Banks(new FlutterwaveApi(flutterwaveSecretKey));
        }

        [Fact]
        public void GetBankBranches_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int bankId = AppConstants.VALID_BANK_ID;

            var flutterwaveSecretKey = "";
            _banks = new Banks(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _banks.GetBankBranches(bankId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetBankBranchesResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetBankBranches_ValidSecretKey_InvalidBankId_ReturnsError()
        {
            // Arrange
            int bankId = AppConstants.INVALID_BANK_ID;

            // Act
            var result = _banks.GetBankBranches(bankId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetBankBranchesResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_BANK_BRANCHES_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetBankBranches_ValidSecretKey_ReturnsBankBranches()
        {
            // Arrange
            int bankId = AppConstants.VALID_BANK_ID;

            // Act
            var result = _banks.GetBankBranches(bankId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetBankBranchesResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_BANK_BRANCHES_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<BankBranch>>(result.Data);
        }

        [Fact]
        public void GetBankBranches__ValidSecretKey_ValidBankId_BankWithoutDocumentedBranches_ReturnsError()
        {
            // Arrange
            int bankId = AppConstants.FIRST_BANK_ID;

            // Act
            var result = _banks.GetBankBranches(bankId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetBankBranchesResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_BANK_BRANCHES_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetBanks_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _banks = new Banks(new FlutterwaveApi(flutterwaveSecretKey));
            
            // Act
            var result = _banks.GetBanks(Country.Nigeria);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetBanksResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetBanks_ValidSecretKey_ReturnsBanks()
        {
            // Act
            var result = _banks.GetBanks(Country.Nigeria);

            // Assert
            Assert.NotNull(result); 
            Assert.IsType<GetBanksResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_BANKS_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<Bank>>(result.Data);
        }
    }
}
