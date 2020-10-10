using System.ComponentModel.DataAnnotations;

namespace Flutterwave.Net
{
    public class SplitPaymentRequest
    {
        /// <summary>
        /// The subAccountId, it is returned in the Get SubAccount call as data.SubAccountId
        /// </summary>
        [Required]
        public string SubAccountId { get; set; }
        /// <summary>
        /// This is the ratio value representing the share of the amount you intend to give a subaccount
        /// </summary>
        public int TransactionSplitRatio { get; set; }
        /// <summary>
        /// This represents the type for the commission you would like to charge, 
        /// if you would like to charge a flat fee pass the value as flat. 
        /// If you would like to charge a percentage pass the value as percentage. 
        /// When you pass this you override the type set as commission when the subaccount was created
        /// </summary>
        public SplitType TransactionChargeType { get; set; }
        /// <summary>
        /// The flat or percentage value to charge as commission on the transaction. 
        /// When you pass this, you override the values set as commission when the subaccount was created
        /// </summary>
        public decimal TransactionCharge { get; set; }
    }
}
