### Miscellaneous
1. Verify a bank account number
    ```c#
    string accountNumber = "0690000032";
    string bankCode = "044";
    VerifyBankAccountResponse response = api.Miscellaneous.VerifyBankAccount(accountNumber, bankCode);

    // success
    if (response.Status == "success")
    {
        // Get the bank account
        BankAccount bankAccount = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```