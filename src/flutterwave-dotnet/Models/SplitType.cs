using Flutterwave.Net.Utilities;
using System.ComponentModel;

namespace Flutterwave.Net
{
    public enum SplitType
    {
        /// <summary>
        /// flat
        /// </summary>

        [Description(AppConstants.SPLIT_TYPE_FLAT)]
        Flat,

        /// <summary>
        /// percentage
        /// </summary>
        [Description(AppConstants.SPLIT_TYPE_PERCENTAGE)]
        Percentage
    }
}
