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
            Assert.Equal(expected: AppConstants.GET_PAYMENTPLANS_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<List<PaymentPlan>>(result.Data);
        }

        [Fact]
        public void GetPaymentPlan_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENTPLAN_ID;
             
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
            int paymentPlanId = AppConstants.INVALID_PAYMENTPLAN_ID;

            // Act 
            var result = _paymentPlans.GetPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GetPaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.GET_PAYMENTPLAN_ERROR_MESSAGE, actual: result.Message);
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
            Assert.Equal(expected: AppConstants.GET_PAYMENTPLAN_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);

            // Cancel test Payment Plan
            // for purposing of re-creating in future test runs
            CancelTestPaymentPlan(createTestPaymentPlanReponse.Data.Id);
        }

        [Fact]
        public void CreatePaymentPlan_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            decimal amount = AppConstants.PAYMENTPLAN_AMOUNT;
            string name = AppConstants.PAYMENTPLAN_NAME;
            decimal duration = AppConstants.PAYMENTPLAN_DURATION;
            
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
        public void CreatePaymentPlan_ValidParamters_ReturnsPaymentPlan()
        {
            // Arrange
            decimal amount = AppConstants.PAYMENTPLAN_AMOUNT;
            string name = AppConstants.PAYMENTPLAN_NAME;
            decimal duration = AppConstants.PAYMENTPLAN_DURATION;

            // Act
            var result = _paymentPlans.CreatePaymentPlan(amount, name, Interval.Monthly, duration);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatePaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CREATE_PAYMENTPLAN_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);

            // Cancel Payment Plan
            // for purposing of re-creating in future test runs
            CancelTestPaymentPlan(result.Data.Id);
        }

        [Fact]
        public void UpdatePaymentPlans_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENTPLAN_ID;

            string name = "January neighbourhood";
            string status = "active";

            var flutterwaveSecretKey = "";
            _paymentPlans = new PaymentPlans(new FlutterwaveApi(flutterwaveSecretKey));

            // Act
            var result = _paymentPlans.UpdatePaymentPlan(paymentPlanId,
                                                          name,
                                                          status);

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
            int paymentPlanId = AppConstants.INVALID_PAYMENTPLAN_ID;

            string name = "January neighbourhood";
            string status = "active";

            // Act
            var result = _paymentPlans.UpdatePaymentPlan(paymentPlanId,
                                                          name,
                                                          status);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UpdatePaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_PAYMENTPLAN_ERROR_MESSAGE, actual: result.Message);
        }

        [Fact]
        public void UpdatePaymentPlan_ValidParamters_ReturnsPaymentPlan()
        {
            // Arrange
            // Create a payment plan to test with
            var createTestPaymentPlanReponse = CreatePaymentPlan();
            int paymentPlanId = createTestPaymentPlanReponse.Data.Id;

            string name = "March neighbourhood";
            string status = "active";

            // Act
            var result = _paymentPlans.UpdatePaymentPlan(paymentPlanId,
                                                          name,
                                                          status);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UpdatePaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.SUCCESS_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.UPDATE_PAYMENTPLAN_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
            Assert.Equal(expected: name, actual: result.Data.Name);
            Assert.Equal(expected: status, actual: result.Data.Status);

            // Cancel test Payment Plan
            // for purposing of re-creating in future test runs
            CancelTestPaymentPlan(createTestPaymentPlanReponse.Data.Id);
        }

        [Fact]
        public void CancelPaymentPlan_InvalidSecretKey_ReturnsError()
        {
            // Arrange
            int paymenPlanId = AppConstants.INVALID_PAYMENTPLAN_ID;

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
        public void CancelPaymentPlan_InvalidId_ReturnsError()
        {
            // Arrange
            int paymentPlanId = AppConstants.INVALID_PAYMENTPLAN_ID;

            // Act
            var result = _paymentPlans.CancelPaymentPlan(paymentPlanId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CancelPaymentPlanResponse>(result);
            Assert.Equal(expected: AppConstants.ERROR_STATUS, actual: result.Status);
            Assert.Equal(expected: AppConstants.CANCEL_PAYMENTPLAN_ERROR_MESSAGE, actual: result.Message);
            Assert.Null(result.Data);
        }
        
        [Fact]
        public void CancelPaymentPlan_ValidId_ReturnsSuccessMessage()
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
            Assert.Equal(expected: AppConstants.CANCEL_PAYMENTPLAN_SUCCESS_MESSAGE, actual: result.Message);
            Assert.IsType<PaymentPlan>(result.Data);
        }

        /// <summary>
        /// Create test Payment Paln for unit tests
        /// </summary>
        /// <returns></returns>
        private CreatePaymentPlanResponse CreatePaymentPlan()
        {
            decimal amount = 5000;
            string name = "Monthly Nepa Bill Collection";
            decimal duration = 24;

            var result = _paymentPlans.CreatePaymentPlan(amount,
                                                         name,
                                                         Interval.Monthly,
                                                         duration);

            return result;
        }

        /// <summary>
        /// Delete test payment plan
        /// </summary>
        /// <returns></returns>
        private void CancelTestPaymentPlan(int paymentPlanId)
        {
            _paymentPlans.CancelPaymentPlan(paymentPlanId);
        }
    }
}