using Flutterwave.Net.Utilities;
using System.ComponentModel;

namespace Flutterwave.Net
{
    public enum Status
    {
        /// <summary>
        /// "Active"
        /// </summary>
        [Description(AppConstants.ACTIVE)]
        Active,

        /// <summary>
        /// "Cancelled"
        /// </summary>
        [Description(AppConstants.CANCELLED)]
        Cancelled
    }
}
