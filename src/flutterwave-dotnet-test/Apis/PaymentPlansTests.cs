using Flutterwave.Net;
using Flutterwave.Net.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace flutterwave_dotnet_test.Apis
{
    public class PaymentPlansTests
    {
        private PaymentPlans _paymentPlans;

        public PaymentPlansTests()
        {
            // Get rave secret key from environmental variables
            var flutterwaveSecretKey = Environment.GetEnvironmentVariable("FLUTTERWAVESECRETKEY");

            _paymentPlans = new PaymentPlans(new FlutterwaveApi(flutterwaveSecretKey));
        }

        [Fact]
        public void CancelPaymentPlan_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymenPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;

            var flutterwaveSecretKey = "";
            _paymentPlans = new PaymentPlans(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _paymentPlans.CancelPaymentPlan(paymenPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CancelPaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void CancelPaymentPlan_ValidSecretKey_InvalidId_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;

            // Act
            var result = _paymentPlans.CancelPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CancelPaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CANCEL_PAYMENT_PLAN_ERROR_MESSAGE, actual: result.Message);
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
            var result = _paymentPlans.CancelPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CancelPaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CANCEL_PAYMENT_PLAN_SUCCESS_MESSAGE, actual: result.Message);
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
            _paymentPlans = new PaymentPlans(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _paymentPlans.CreatePaymentPlan(amount, name, Interval.Monthly, duration);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatePaymentPlanResponse>(result);
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
            var result = _paymentPlans.CreatePaymentPlan(amount, name, Interval.Monthly, duration);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatePaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CREATE_PAYMENT_PLAN_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
        }

        [Fact]
        public void GetPaymentPlan_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;
             
            var flutterwaveSecretKey = "";
            _paymentPlans = new PaymentPlans(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _paymentPlans.GetPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetPaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public void GetPaymentPlan_ValidSecretKey_InvalidPaymentPlansId_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;

            // Act 
            var result = _paymentPlans.GetPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetPaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_PAYMENT_PLAN_ERROR_MESSAGE, actual: result.Message);
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
            var result = _paymentPlans.GetPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetPaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_PAYMENT_PLAN_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
            Assert.Equal(expected: paymentPlanId, actual: result.Data.Id);
        }

        [Fact]
        public void GetPaymentPlans_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            var flutterwaveSecretKey = "";
            _paymentPlans = new PaymentPlans(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _paymentPlans.GetPaymentPlans();

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
            var result = _paymentPlans.GetPaymentPlans();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetPaymentPlansResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_PAYMENT_PLANS_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<PaymentPlan>>(result.Data);
        }

        [Fact]
        public void UpdatePaymentPlans_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;
            string name = AppConstants.SAMPLE_NEW_PAYMENT_PLAN_NAME;

            var flutterwaveSecretKey = "";
            _paymentPlans = new PaymentPlans(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _paymentPlans.UpdatePaymentPlan(paymentPlanId,
                                                          name,
                                                          Status.Active);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UpdatePaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.INVALID_AUTHORIZATION_KEY_ERROR_MESSAGE, actual: result.Message);
        }

        [Fact]
        public void UpdatePaymentPlan_ValidSecretKey_InvalidPaymentPlanId_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENT_PLAN_ID;
            string name = AppConstants.SAMPLE_NEW_PAYMENT_PLAN_NAME;

            // Act
            var result = _paymentPlans.UpdatePaymentPlan(paymentPlanId,
                                                          name,
                                                          Status.Active);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UpdatePaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_PAYMENT_PLAN_ERROR_MESSAGE, actual: result.Message);
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
            var result = _paymentPlans.UpdatePaymentPlan(paymentPlanId,
                                                          name,
                                                          Status.Active);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UpdatePaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_PAYMENT_PLAN_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
            Assert.Equal(expected: paymentPlanId, actual: result.Data.Id);
            Assert.Equal(expected: name, actual: result.Data.Name);
            Assert.Equal(expected: AppConstants.ACTIVE, actual: result.Data.Status);
        }

        /// <summary>
        /// Create test Payment Plan for unit tests
        /// </summary>
        /// <returns></returns>
        private CreatePaymentPlanResponse CreatePaymentPlan()
        {
            decimal amount = 5000;
            string name = AppConstants.SAMPLE_PAYMENT_PLAN_NAME;
            int duration = 24;

            var result = _paymentPlans.CreatePaymentPlan(amount,
                                                         name,
                                                         Interval.Monthly,
                                                         duration);

            return result;
        }
    }
}