using Flutterwave.Net.Utilities;
using System.ComponentModel;

namespace Flutterwave.Net
{
    public enum Currency
    {
        /// <summary>
        /// "GHS"
        /// </summary>
        [Description(AppConstants.CEDI_CODE)]
        Cedi,

        /// <summary>
        /// "USD"
        /// </summary>
        [Description(AppConstants.DOLLAR_CODE)]
        Dollar,

        /// <summary>
        /// "EUR"
        /// </summary>
        [Description(AppConstants.EURO_CODE)]
        Euro,

        /// <summary>
        /// "KES"
        /// </summary>
        [Description(AppConstants.KENYAN_SHILLING_CODE)]
        Kenyanshilling,

        /// <summary>
        /// "NGN"
        /// </summary>
        [Description(AppConstants.NAIRA_CODE)]
        Naira,

        /// <summary>
        /// "GBP"
        /// </summary>
        [Description(AppConstants.POUNDS_CODE)]
        Pounds
    };
}
