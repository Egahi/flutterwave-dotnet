### Payments
1. Cancel a payment plan
    ```c#
    int paymentPlanId = 123;
    
    PaymentPlanResponse response = api.CancelPaymentPlan(paymentPlanId);

    // success
    if (response.Status == "success")
    {
        // Get payment plan
        PaymentPlan paymentPlan = response.Data;
        
        // Verify payment plan status
        bool isCancelled = paymentPlan.Status == "cancelled";
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
2. Create a payment plan
    ```c#
    decimal amount = 5000;
    string name = "Monthly Nepa Bill Collection";
    int duration = 24;
    
    PaymentPlanResponse response = api.CreatePaymentPlan(amount, 
                                                         name, 
                                                         Interval.Monthly, 
                                                         duration);

    // success
    if (response.Status == "success")
    {
        // Get payment plan
        PaymentPlan paymentPlan = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
3. Get a payment plan
    ```c#
    int paymentPlanId = 123;
    
    PaymentPlanResponse response = api.GetPaymentPlan(paymentPlanId);

    // success
    if (response.Status == "success")
    {
        // Get payment plan
        PaymentPlan paymentPlan = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
4. Get payment plans
    ```c#
    GetPaymentPlansResponse response = api.GetPaymentPlans();

    // success
    if (response.Status == "success")
    {
        // Get payment plans
        List<PaymentPlan> paymentPlans = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
5. Initiate payment
    ```c#
    string txRef = "hooli-tx-1920bbtytty";
    decimal amount = 100;
    string redirectUrl = "https://webhook.site/9d0b00ba-9a69-44fa-a43d-a82c33c36fdc";
    string customerEmail = "user@gmail.com";
    string customerPhonenumber = "08012345678";
    string customerName = "Yemi Desola";
    string paymentTitle = "Pied Piper Payments";
    string paymentDescription = "Middleout isn't free. Pay the price";
    string brandLogoUrl = "https://assets.piedpiper.com/logo.png";

    InitiatePaymentResponse response = api.Payments.InitiatePayment(txRef,
                                                                    amount,
                                                                    redirectUrl,
                                                                    customerName,
                                                                    customerEmail,
                                                                    customerPhonenumber,
                                                                    paymentTitle,
                                                                    paymentDescription,
                                                                    brandLogoUrl);

    // success
    if (response.Status == "success")
    {
        // Get payment hosted link 
        string hostedLink = response.Data.Link;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
6. Update a payment plan
    ```c#
    int paymentPlanId = 123;
    string name = "January neighbourhood";
    
    PaymentPlanResponse response = api.UpdatePaymentPlan(paymentPlanId,
                                                         name,
                                                         PaymentPlanStatus.Active);

    // success
    if (response.Status == "success")
    {
        // Get payment plan
        PaymentPlan paymentPlan = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```