namespace Flutterwave.Net
{
    public interface IBanks
    {
        /// <summary>
        /// Get all Banks
        /// </summary>
        /// <param name="country">
        /// Get list of banks in this country
        /// </param>
        /// <returns>A list of Banks</returns>
        public GetBanksResponse GetBanks(Country country);

        /// <summary>
        /// Verify bank branches
        /// </summary>
        /// <param name="id">
        /// Unique bank ID, it is returned in the call to fetch banks here -
        /// https://developer.flutterwave.com/v3.0/reference#get-all-banks
        /// </param>
        /// <returns>A list of bank branches</returns>
        public GetBankBranchesResponse GetBankBrances(string id);
    }
}
