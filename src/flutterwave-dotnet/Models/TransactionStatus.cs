using Flutterwave.Net.Utilities;
using System.ComponentModel;

namespace Flutterwave.Net
{
    public enum TransactionStatus
    {
        /// <summary>
        /// "Failed"
        /// </summary>
        [Description(AppConstants.FAILED_STATUS)]
        Failed,

        /// <summary>
        /// "Successful"
        /// </summary>
        [Description(AppConstants.SUCCESSFUL_STATUS)]
        Successful
    }
}
