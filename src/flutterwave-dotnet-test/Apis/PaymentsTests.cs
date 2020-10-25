using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class PaymentsTests
    {
        private IFlutterwaveApi _api;

        public PaymentsTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FLUTTERWAVESECRETKEY");

            _api = new FlutterwaveApi(flutterwaveSecretKey);
        }


        [Fact]
        public void CancelPaymentPlan_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymenPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Payments.CancelPaymentPlan(paymenPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CancelPaymentPlan_ValidSecretKey_InvalidId_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;

            // Act
            var result = _api.Payments.CancelPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CANCEL_PAYMENT_PLAN_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CancelPaymentPlan_ValidSecretKey_ValidId_ReturnsPaymentPlan()
        {
            // Arrange
            // Create a Payment Plan to test with
            var createTestPaymentPlanReponse = CreatePaymentPlan();
            int paymentPlanId = createTestPaymentPlanReponse.Data.Id;

            // Act
            var result = _api.Payments.CancelPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CANCEL_PAYMENT_PLAN_SUCCESS_MESSAGE, 
                actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
            Assert.Equal(expected: paymentPlanId, actual: result.Data.Id);
            Assert.Equal(expected: AppConstants.CANCELLED, actual: result.Data.Status);
        }

        [Fact]
        public void CreatePaymentPlan_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            decimal amount = 5000;
            string name = AppConstants.SAMPLE_PAYMENT_PLAN_NAME;
            int duration = 24;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Payments.CreatePaymentPlan(amount, 
                                                         name, 
                                                         Interval.Monthly, 
                                                         duration);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE,
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CreatePaymentPlan_ValidSecretKey_ValidParamters_ReturnsPaymentPlan()
        {
            // Arrange
            decimal amount = 5000;
            string name = AppConstants.SAMPLE_PAYMENT_PLAN_NAME;
            int duration = 24;

            // Act
            var result = _api.Payments.CreatePaymentPlan(amount, 
                                                         name, 
                                                         Interval.Monthly, 
                                                         duration);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CREATE_PAYMENT_PLAN_SUCCESS_MESSAGE, 
                actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
        }

        [Fact]
        public void GetPaymentPlan_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Payments.GetPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetPaymentPlan_ValidSecretKey_InvalidPaymentPlansId_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;

            // Act 
            var result = _api.Payments.GetPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_PAYMENT_PLAN_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetPaymentPlan_ValidSecretKey_ValidPaymentPlanId_ReturnsPaymentPlan()
        {
            // Arrange
            // Create a payment plan to test with
            var createTestPaymentPlanReponse = CreatePaymentPlan();
            int paymentPlanId = createTestPaymentPlanReponse.Data.Id;

            // Act
            var result = _api.Payments.GetPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_PAYMENT_PLAN_SUCCESS_MESSAGE, 
                actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
            Assert.Equal(expected: paymentPlanId, actual: result.Data.Id);
        }

        [Fact]
        public void GetPaymentPlans_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Payments.GetPaymentPlans();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetPaymentPlansResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE,
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetPaymentPlans_ValidSecretKey_ReturnsAllPaymentPlans()
        {
            // Act
            var result = _api.Payments.GetPaymentPlans();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetPaymentPlansResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_PAYMENT_PLANS_SUCCESS_MESSAGE, 
                actual: result.Message);
            Assert.IsType<List<PaymentPlan>>(result.Data);
        }

        [Fact]
        public void InitiatePayment_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            string txRef = AppConstants.SAMPLE_TX_REF;
            decimal amount = 100;
            string redirectUrl = AppConstants.SAMPLE_REDIRECT_URL;
            string customerEmail = AppConstants.SAMPLE_EMAIL;
            string customerPhonenumber = AppConstants.SAMPLE_PHONE_NUMBER;
            string customerName = AppConstants.SAMPLE_CUSTOMER_NAME;
            string paymentTitle = AppConstants.SAMPLE_PAYMENT_TITLE;
            string paymentDescription = AppConstants.SAMPLE_PAYMENT_DESCRIPTION;
            string brandLogoUrl = AppConstants.SAMPLE_BRAND_LOGO_URL;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Payments.InitiatePayment(txRef,
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
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void InitiatePayment_ValidSecretKey_CurrencySpecified_ReturnsSuccess()
        {
            // Arrange
            string txRef = AppConstants.SAMPLE_TX_REF;
            decimal amount = 100;
            string redirectUrl = AppConstants.SAMPLE_REDIRECT_URL;
            string customerName = AppConstants.SAMPLE_CUSTOMER_NAME;
            string customerEmail = AppConstants.SAMPLE_EMAIL;
            string customerPhonenumber = AppConstants.SAMPLE_PHONE_NUMBER;
            string paymentTitle = AppConstants.SAMPLE_PAYMENT_TITLE;
            string paymentDescription = AppConstants.SAMPLE_PAYMENT_DESCRIPTION;
            string brandLogoUrl = AppConstants.SAMPLE_BRAND_LOGO_URL;

            // Act
            var result = _api.Payments.InitiatePayment(txRef,
                                                       amount,
                                                       redirectUrl,
                                                       customerName,
                                                       customerEmail,
                                                       customerPhonenumber,
                                                       paymentTitle,
                                                       paymentDescription,
                                                       brandLogoUrl,
                                                       Currency.UnitedStatesDollar);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InitiatePaymentResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INITIATE_PAYMENT_RESPONSE_MESSAGE, 
                actual: result.Message);
            Assert.IsType<HostedLink>(result.Data);
            Assert.True(Uri.IsWellFormedUriString(result.Data.Link, UriKind.Absolute));
        }

        [Fact]
        public void InitiatePayment_ValidSecretKey_NoCurrencySpecified_ReturnsSuccess()
        {
            // Arrange
            string txRef = AppConstants.SAMPLE_TX_REF;
            decimal amount = 100;
            string redirectUrl = AppConstants.SAMPLE_REDIRECT_URL;
            string customerEmail = AppConstants.SAMPLE_EMAIL;
            string customerPhonenumber = AppConstants.SAMPLE_PHONE_NUMBER;
            string customerName = AppConstants.SAMPLE_CUSTOMER_NAME;
            string paymentTitle = AppConstants.SAMPLE_PAYMENT_TITLE;
            string paymentDescription = AppConstants.SAMPLE_PAYMENT_DESCRIPTION;
            string brandLogoUrl = AppConstants.SAMPLE_BRAND_LOGO_URL;

            // Act
            var result = _api.Payments.InitiatePayment(txRef,
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
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INITIATE_PAYMENT_RESPONSE_MESSAGE, 
                actual: result.Message);
            Assert.IsType<HostedLink>(result.Data);
            Assert.True(Uri.IsWellFormedUriString(result.Data.Link, UriKind.Absolute));
        }

        [Fact]
        public void UpdatePaymentPlans_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;
            string name = AppConstants.SAMPLE_NEW_PAYMENT_PLAN_NAME;

            var flutterwaveSecretKey = "";
            _api = new FlutterwaveApi(flutterwaveSecretKey);

            // Act
            var result = _api.Payments.UpdatePaymentPlan(paymentPlanId,
                                                         name,
                                                         Status.Active);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, 
                actual: result.Message);
        }

        [Fact]
        public void UpdatePaymentPlan_ValidSecretKey_InvalidPaymentPlanId_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;
            string name = AppConstants.SAMPLE_NEW_PAYMENT_PLAN_NAME;

            // Act
            var result = _api.Payments.UpdatePaymentPlan(paymentPlanId,
                                                         name,
                                                         Status.Active);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_PAYMENT_PLAN_ERROR_MESSAGE, 
                actual: result.Message);
        }

        [Fact]
        public void UpdatePaymentPlan_ValidSecretKey_ValidParamters_ReturnsPaymentPlan()
        {
            // Arrange
            // Create a payment plan to test with
            var createTestPaymentPlanReponse = CreatePaymentPlan();
            int paymentPlanId = createTestPaymentPlanReponse.Data.Id;
            string name = AppConstants.SAMPLE_NEW_PAYMENT_PLAN_NAME;

            // Act
            var result = _api.Payments.UpdatePaymentPlan(paymentPlanId,
                                                         name,
                                                         Status.Active);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_PAYMENT_PLAN_SUCCESS_MESSAGE, 
                actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
            Assert.Equal(expected: paymentPlanId, actual: result.Data.Id);
            Assert.Equal(expected: name, actual: result.Data.Name);
            Assert.Equal(expected: AppConstants.ACTIVE, actual: result.Data.Status);
        }

        /// <summary>
        /// Create test Payment Plan for unit tests
        /// </summary>
        /// <returns></returns>
        private PaymentPlanResponse CreatePaymentPlan()
        {
            decimal amount = 5000;
            string name = AppConstants.SAMPLE_PAYMENT_PLAN_NAME;
            int duration = 24;

            var result = _api.Payments.CreatePaymentPlan(amount,
                                                         name,
                                                         Interval.Monthly,
                                                         duration);

            return result;
        }
    }
}
