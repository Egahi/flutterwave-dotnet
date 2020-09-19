<p align="center">
    <img title="Flutterwave" height="200" src="https://flutterwave.com/images/logo-colored.svg" width="50%"/>
</p>

# .NET Library for Flutterwave (version 3) APIs
This library makes it easy to consume [Flutterwave API (v3)](https://developer.flutterwave.com/reference#introduction-1) in .Net projects.

## Introduction
This library implements the following payment services:
1. Payments
    * Initiate Payment
1. Transactions
    * Get all Transactions
    
## Configuration
1. Include the Flutterwave.Net namespace to expose all types
    ```c#
    ...
    using Flutterwave.Net;
    ...
    ```
2. Declare and initialise the [FlutterwaveAPI](src/flutterwave-dotnet/FlutterwaveApi.cs) class with your secret key
    ```c#
    string flutterwaveSecretKey = ConfigurationManager.AppSettings["FlutterwaveSecretKey"];
    var api = new FlutterwaveApi(flutterwaveSecretKey);
    ```

## Usage

### - Payments
1. Initiate Payment
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
        // Get message
        string message = response.Message;
    }
    ```

### - Transactions
1. Get all Transactions
    ```c#
    GetTransactionsResponse response = api.Transactions.GetTransactions();

    // success
    if (response.Status == "success")
    {
        // Get all transactions
        List<Transaction> transactions = response.Data;
    }
    // error
    else
    {
        // Get message
        string message = response.Message;
    }
    ```

## Support
Create a new issue or add a comment to an open issue to request for new features and/or report bugs

[Send a mail](mailto:hello@egahi.net) for further assistance using this library
