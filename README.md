<p align="center">
    <img title="Flutterwave" height="200" src="https://flutterwave.com/images/logo-colored.svg" width="50%"/>
</p>

# .NET Library for Flutterwave (version 3) APIs
This library makes it easy to consume [Flutterwave API (v3)](https://developer.flutterwave.com/reference#introduction-1) in .Net projects.

## Introduction
This library implements the following services:
1. Banks
    * Get bank branches
    * Get banks
2. Miscellaneous
    * Verify a bank account number
3. Payments
    * Cancel a payment plan
    * Create a payment plan
    * Get a payment plan
    * Get payment plans
    * Initiate payment
    * Update a payment plan
4. Sub accounts
    * Create a sub account
    * Delete a sub account
    * Fetch a sub account
    * Fetch all sub accounts
    * Update a sub account
5. Transactions
    * Get all transactions
    * Get transaction fees
    * Resend transaction webhook
    * Verify a transaction
    
## Installation
* From Nuget <br/>
    ```c#
    Install-Package Flutterwave.Net -Version 1.0.0
    ```
* From .NET CLI
    ```c#
    dotnet add package Flutterwave.Net --version 1.0.0
    ```
* As a package reference
    ```c#
    <PackageReference Include="Flutterwave.Net" Version="1.0.0" />
    ```
    
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
View code snippets on how to call each api endpoint in the docs linked below. 
1. [Banks](/docs/Banks.md)
2. [Miscellaneous](/docs/Miscellaneous.md)
3. [Payments](/docs/Payments.md)
4. [Sub Accounts](/docs/SubAccounts.md)
5. [Transactions](/docs/Transactions.md)

## Support
Create a new issue or add a comment to an open issue to request for new features and/or report bugs

[Send a mail](mailto:hello@egahi.so) for further assistance using this library
