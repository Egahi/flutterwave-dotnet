using Flutterwave.Net.Utilities;
using System.ComponentModel;

namespace Flutterwave.Net
{
    public enum Country
    { 
        /// <summary>
        /// "GH"
        /// </summary>
        [Description(AppConstants.GHANA_COUNTRY_CODE)]
        Ghana,

        /// <summary>
        /// "KE"
        /// </summary>
        [Description(AppConstants.KENYA_COUNTRY_CODE)]
        Kenya,

        /// <summary>
        /// "NG"
        /// </summary>
        [Description(AppConstants.NIGERIA_COUNTRY_CODE)]
        Nigeria,

        /// <summary>
        /// "ZA"
        /// </summary>
        [Description(AppConstants.SOUTH_AFRICA_COUNTRY_CODE)]
        SouthAfrica,

        /// <summary>
        /// "TZ"
        /// </summary>
        [Description(AppConstants.TANZANIA_COUNTRY_CODE)]
        Tanzania,

        /// <summary>
        /// "UG"
        /// </summary>
        [Description(AppConstants.UGANDA_COUNTRY_CODE)]
        Uganda,
    }
}
