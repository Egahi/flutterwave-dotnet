using Flutterwave.Net.Utilities;
using System.ComponentModel;

namespace Flutterwave.Net
{
    public enum Interval
    {
        /// <summary>
        /// "Yearly"
        /// </summary>
        [Description(AppConstants.YEARLY)]
        Yearly,

        /// <summary>
        /// "Quarterly"
        /// </summary>
        [Description(AppConstants.QUARTERLY)]
        Quarterly,

        /// <summary>
        /// "Monthly"
        /// </summary>
        [Description(AppConstants.MONTHLY)]
        Monthly,

        /// <summary>
        /// "Weekly" 
        /// </summary>
        [Description(AppConstants.WEEKLY)]
        Weekly,

        /// <summary>
        /// "Daily"
        /// </summary>
        [Description(AppConstants.DAILY)]
        Daily
    }
}