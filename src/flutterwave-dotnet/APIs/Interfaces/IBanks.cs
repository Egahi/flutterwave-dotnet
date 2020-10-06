namespace Flutterwave.Net
{
    public interface IBanks
    {
        /// <summary>
        /// Get bank branches
        /// </summary>
        /// <param name="bankId">
        /// Unique bank ID, it is returned in the Get banks call as data.id
        /// </param>
        /// <returns>A list of bank branches</returns>
        public GetBankBranchesResponse GetBankBranches(int bankId);

        /// <summary>
        /// Get all Banks
        /// </summary>
        /// <param name="country">
        /// Get list of banks in this country
        /// </param>
        /// <returns>A list of Banks</returns>
        public GetBanksResponse GetBanks(Country country);
    }
}
