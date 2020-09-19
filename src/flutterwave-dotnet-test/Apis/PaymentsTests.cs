using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class PaymentsTests
    {
        private Payments _payments;

        public PaymentsTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FlutterwaveSecretKey");

            _payments = new Payments(new FlutterwaveApi(flutterwaveSecretKey));
        }

        [Fact]
        public void InitiatePayment_InValidSecretKey_ReturnsError()
        {
            // Arrange
            string txRef = AppConstants.TX_REF;
            decimal amount = 100;
            string redirectUrl = AppConstants.SAMPLE_REDIRECT_URL;
            string customerEmail = AppConstants.SAMPLE_EMAIL;
            string customerPhonenumber = AppConstants.SAMPLE_PHONE_NUMBER;
            string customerName = AppConstants.SAMPLE_CUSTOMER_NAME;
            string paymentTitle = AppConstants.SAMPLE_PAYMENT_TITLE;
            string paymentDescription = AppConstants.SAMPLE_PAYMENT_DESCRIPTION;
            string brandLogoUrl = AppConstants.SAMPLE_BRAND_LOGO_URL;

            var flutterwaveSecretKey = "";
            _payments = new Payments(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _payments.InitiatePayment(txRef,
                                                       amount,
                                                       redirectUrl,
                                                       customerName,
                                                       customerEmail,
                                                       customerPhonenumber,
                                                       paymentTitle,
                                                       paymentDescription,
                                                       brandLogoUrl);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InitiatePaymentResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void InitiatePayment_ValidSecretKey_CurrencySpecified_ReturnsSuccess()
        {
            // Arrange
            string txRef = AppConstants.TX_REF;
            decimal amount = 100;
            string redirectUrl = AppConstants.SAMPLE_REDIRECT_URL;
            string customerName = AppConstants.SAMPLE_CUSTOMER_NAME;
            string customerEmail = AppConstants.SAMPLE_EMAIL;
            string customerPhonenumber = AppConstants.SAMPLE_PHONE_NUMBER;
            string paymentTitle = AppConstants.SAMPLE_PAYMENT_TITLE;
            string paymentDescription = AppConstants.SAMPLE_PAYMENT_DESCRIPTION;
            string brandLogoUrl = AppConstants.SAMPLE_BRAND_LOGO_URL;

            // Act
            var result = _payments.InitiatePayment(txRef,
                                                       amount,
                                                       redirectUrl,
                                                       customerName,
                                                       customerEmail,
                                                       customerPhonenumber,
                                                       paymentTitle,
                                                       paymentDescription,
                                                       brandLogoUrl,
                                                       Currency.Dollar);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InitiatePaymentResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INITIATE_PAYMENT_RESPONSE_MESSAGE, actual: result.Message);
            Assert.IsType<HostedLink>(result.Data);
            Assert.True(Uri.IsWellFormedUriString(result.Data.Link, UriKind.Absolute));
        }

        [Fact]
        public void InitiatePayment_ValidSecretKey_NoCurrencySpecified_ReturnsSuccess()
        {
            // Arrange
            string txRef = AppConstants.TX_REF;
            decimal amount = 100;
            string redirectUrl = AppConstants.SAMPLE_REDIRECT_URL;
            string customerEmail = AppConstants.SAMPLE_EMAIL;
            string customerPhonenumber = AppConstants.SAMPLE_PHONE_NUMBER;
            string customerName = AppConstants.SAMPLE_CUSTOMER_NAME;
            string paymentTitle = AppConstants.SAMPLE_PAYMENT_TITLE;
            string paymentDescription = AppConstants.SAMPLE_PAYMENT_DESCRIPTION;
            string brandLogoUrl = AppConstants.SAMPLE_BRAND_LOGO_URL;

            // Act
            var result = _payments.InitiatePayment(txRef,
                                                       amount,
                                                       redirectUrl,
                                                       customerName,
                                                       customerEmail,
                                                       customerPhonenumber,
                                                       paymentTitle,
                                                       paymentDescription,
                                                       brandLogoUrl);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InitiatePaymentResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INITIATE_PAYMENT_RESPONSE_MESSAGE, actual: result.Message);
            Assert.IsType<HostedLink>(result.Data);
            Assert.True(Uri.IsWellFormedUriString(result.Data.Link, UriKind.Absolute));
        }
    }
}
