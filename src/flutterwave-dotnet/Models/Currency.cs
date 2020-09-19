using Flutterwave.Net.Utilities;
using System.ComponentModel;

namespace Flutterwave.Net
{
    public enum Currency
    {
        /// <summary>
        /// "EUR"
        /// </summary>
        [Description(AppConstants.EURO_CODE)]
        Euro,

        /// <summary>
        /// "GHS"
        /// </summary>
        [Description(AppConstants.GHANAIAN_CEDI_CODE)]
        GhanaianCedi,

        /// <summary>
        /// "KES"
        /// </summary>
        [Description(AppConstants.KENYAN_SHILLING_CODE)]
        KenyanShilling,

        /// <summary>
        /// "NGN"
        /// </summary>
        [Description(AppConstants.NIGERIAN_NAIRA_CODE)]
        NigerianNaira,

        /// <summary>
        /// "GBP"
        /// </summary>
        [Description(AppConstants.POUND_STERLING_CODE)]
        PoundSterling,

        /// <summary>
        /// "RWF"
        /// </summary>
        [Description(AppConstants.RWANDAN_FRANC_CODE)]
        RwandanFranc,
        
        /// <summary>
        /// "SLL"
        /// </summary>
        [Description(AppConstants.SIERRA_LEONEAN_LEONE_CODE)]
        SierraLeoneanLeone,
        
        /// <summary>
        /// "ZAR"
        /// </summary>
        [Description(AppConstants.SOUTH_AFRICAN_RAND_CODE)]
        SouthAfricanRand,
        
        /// <summary>
        /// "TZS"
        /// </summary>
        [Description(AppConstants.TANZANIAN_SHILLING_CODE)]
        TanzanianShilling,

        /// <summary>
        /// "UGX"
        /// </summary>
        [Description(AppConstants.UGANDAN_SHILLING_CODE)]
        UgandanShilling,

        /// <summary>
        /// "USD"
        /// </summary>
        [Description(AppConstants.UNITED_STATES_DOLLAR_CODE)]
        UnitedStatesDollar,
        
        /// <summary>
        /// "XOF"
        /// </summary>
        [Description(AppConstants.WEST_AFRICAN_CFA_FRANC_CODE)]
        WestAfricanCFAFranc,

        /// <summary>
        /// "ZMW"
        /// </summary>
        [Description(AppConstants.ZAMBIAN_KWACHA_CODE)]
        ZambianKwacha
    };
}
