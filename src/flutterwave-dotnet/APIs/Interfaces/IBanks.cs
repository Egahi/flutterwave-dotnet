namespace Flutterwave.Net
{
    public interface IBanks
    {
        /// <summary>
        /// Get all Banks
        /// </summary>
        /// <param name="country">
        /// Pass either NG, GH, KE, UG, ZA or TZ to get list of banks in Nigeria, Ghana, 
        /// Kenya, Uganda, South Africa or Tanzania respectively
        /// </param>
        /// <returns>A list of Banks</returns>
        public GetBanksResponse GetBanks(string country);
    }
}
