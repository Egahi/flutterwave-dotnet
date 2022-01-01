### Transactions
1. Get transaction fees
    ```c#
    decimal amount = 5000;
    
    GetTransactionFeeResponse response = api.Transactions.GetTransactionFee(amount);

    // success
    if (response.Status == "success")
    {
        // Get transaction fees
        TransactionFee transactionFees = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
2. Get all transactions
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
        // Get error message
        string errorMessage = response.Message;
    }
    ```
3. Resend transaction webhook
    ```c#
    int transactionId = 1234567;
    
    ResendTransactionWebhookResponse response = api.Transactions.ResendTransactionWebhook(id);
    
    string responseMessage = response.Message;
    
    // success
    if (response.Status == "success")
    {
        // Provide Value
    }
    // error
    else
    {
        // Handle error
    }
    ```
4. Verify a transaction
    ```c#
    int transactionId = 1234567;
    
    VerifyTransactionResponse response = api.Transactions.VerifyTransaction(id);

    // success
    if (response.Status == "success")
    {
        // Get the transaction
        Transaction transaction = response.Data;
        
        // Verify transaction status
        bool isSuccess = transaction.Status == "successful";
        
        // Verify that the transaction reference, currency and charged amount i.e
        // transaction.TxRef, transaction.Currency and transaction.ChargedAmount
        // are what you expect them to be
        
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```