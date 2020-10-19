using Flutterwave.Net.Utilities;
using System.ComponentModel;

namespace Flutterwave.Net
{
    public enum Interval
    {
        /// <summary>
        /// "Daily"
        /// </summary>
        [Description(AppConstants.DAILY)]
        Daily,

        /// <summary>
        /// "Monthly"
        /// </summary>
        [Description(AppConstants.MONTHLY)]
        Monthly,

        /// <summary>
        /// "Quarterly"
        /// </summary>
        [Description(AppConstants.QUARTERLY)]
        Quarterly,

        /// <summary>
        /// "Weekly" 
        /// </summary>
        [Description(AppConstants.WEEKLY)]
        Weekly,

        /// <summary>
        /// "Yearly"
        /// </summary>
        [Description(AppConstants.YEARLY)]
        Yearly
    }
}