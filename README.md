# .NET Library for Flutterwave (version 3) APIs
This library makes it easy to consume [Flutterwave API (v3)](https://developer.flutterwave.com/reference#introduction-1) in .Net projects.

## Introduction
This library implements the following payment services:
1. Transactions
    * Get all Transactions
    * Initiate Payment
    
## Configuration
1. Include the Flutterwave.Net namespace to expose all types
```
...
using Flutterwave.Net;
...
```
2. Declare and initialise the [FlutterwaveAPI](src/flutterwave-dotnet/FlutterwaveApi.cs) class with your secret key
```
var flutterwaveSecretKey = ConfigurationManager.AppSettings["FlutterwaveSecretKey"];
var api = new FlutterwaveApi(flutterwaveSecretKey);
```

## Usage
### Transactions
1. Get all Transactions
```
var response = api.Transactions.GetTransactions();

// success
if (response.Status == "success")
{
    // show all transactions
    var transactions = response.Data;
}
// error
else
{
    // show message
    string message = response.Message;
}
```

2. Initiate Payment
```
string txRef = "hooli-tx-1920bbtytty";
decimal amount = 100;
string redirectUrl = "https://webhook.site/9d0b00ba-9a69-44fa-a43d-a82c33c36fdc";
string customerEmail = "user@gmail.com";
string customerPhonenumber = "08012345678";
string customerName = "Yemi Desola";
string paymentTitle = "Pied Piper Payments";
string paymentDescription = "Middleout isn't free. Pay the price";
string brandLogoUrl = "https://assets.piedpiper.com/logo.png";

var response = api.Transactions.InitiatePayment(txRef,
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
    var transactions = response.Data.Link;
}
// error
else
{
    // show message
    string message = response.Message;
}
```
