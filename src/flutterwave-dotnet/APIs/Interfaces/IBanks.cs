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
    }
}
