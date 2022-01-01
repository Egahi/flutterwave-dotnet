### Sub accounts
1. Create a sub account
    ```c#
    string bankCode = "044";
    string accountNumber = "0690000032";
    string businessName = "Eternal Blue";
    string businessEmail = "user@gmail.com";
    double splitValue = 0.5;
    string businessContact = "Yemi Desola";
    string businessContactMobile = "08012345678";
    string businessMobile = "08012345678";

    SubAccountResponse response = api.CreateSubAccount(bankCode,
                                                       accountNumber,
                                                       businessName,
                                                       businessEmail,
                                                       Country.Nigeria,
                                                       SplitType.Percentage,
                                                       splitValue,
                                                       businessContact,
                                                       businessContactMobile,
                                                       businessMobile);

    // success
    if (response.Status == "success")
    {
        // Get sub account
        SubAccount subAccount = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
2. Delete a sub account
    ```c#
    int subAccountId = 12345
    
    SubAccountResponse response = api.DeleteSubAccount(subAccountId);

    // success
    if (response.Status == "success")
    {
        // Get success message
        string successMessage = response.Message;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
3. Fetch a sub account
    ```c#
    int subAccountId = 12345;
    
    SubAccountResponse response = api.GetSubAccount(subAccountId);

    // success
    if (response.Status == "success")
    {
        // Get the sub account
        SubAccount subAccounts = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
4. Fetch all sub accounts
    ```c#
    GetSubAccountsResponse response = api.GetSubAccounts();

    // success
    if (response.Status == "success")
    {
        // Get all sub accounts
        List<SubAccount> subAccounts = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
5. Update a sub account
    ```c#
    int subAccountId = 12345;
    string businessName = "Eternal Blue";
    string businessEmail = "user@gmail.com";
    string bankCode = "044";
    string accountNumber = "0690000032";
    double splitValue = 0.5;

    SubAccountResponse response = api.UpdateSubAccountRequest(subAccountId,
                                                              businessName,
                                                              businessEmail,
                                                              bankCode,
                                                              accountNumber,
                                                              SplitType.Percentage,
                                                              splitValue);

    // success
    if (response.Status == "success")
    {
        // Get updated sub account
        SubAccount subAccount = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```