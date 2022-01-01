### Banks
1. Get bank branches
    ```c#
    int bankId = 280;

    GetBankBranchesResponse response = api.GetBankBranches(bankId);

    // success
    if (response.Status == "success")
    {
        // Get bank branches
        List<BankBranch> bankBranches = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```
    
2. Get banks
    ```c#
    GetBanksResponse response = api.GetBanks(Country.Nigeria);

    // success
    if (response.Status == "success")
    {
        // Get all banks
        List<Bank> banks = response.Data;
    }
    // error
    else
    {
        // Get error message
        string errorMessage = response.Message;
    }
    ```