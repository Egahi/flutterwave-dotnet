namespace Flutterwave.Net.Utilities
{
    public class AppConstants
    {
        // Banks
        public static string ACCESS_BANK_CODE = "044";
        public static string FIRST_BANK_CODE = "011";
        public static string FIRST_BANK_ID = "137";
        public static string GET_BANK_BRANCHES_ERROR_MESSAGE = "No branches found for specified bank id";
        public static string GET_BANK_BRANCHES_SUCCESS_MESSAGE = "Bank branches fetched successfully";
        public static string GET_BANKS_ERROR_MESSAGE = "No banks found for country code";
        public static string GET_BANKS_SUCCESS_MESSAGE = "Banks fetched successfully";
        public static string INVALID_ACCOUNT_NUMBER = "1234567890";
        public static string INVALID_BANK_CODE = "000";
        public static string INVALID_BANK_ID = "123";
        public static string VALID_ACCESSBANK_ACCOUNT_NUMBER = "0690000032";
        public static string VALID_ACCESSBANK_ACCOUNT_NAME = "Pastor Bright";
        public static string VALID_BANK_ID = "280";
        public static string VERIFY_BANK_ACCOUNT_ERROR_MESSAGE = "Sorry, recipient account could not be validated. Please try again";
        public static string VERIFY_BANK_ACCOUNT_SUCCESS_MESSAGE = "Account details fetched";

        // Country Codes
        public const string GHANA_COUNTRY_CODE = "GH";
        public const string KENYA_COUNTRY_CODE = "KE";
        public const string NIGERIA_COUNTRY_CODE = "NG";
        public const string SOUTH_AFRICA_COUNTRY_CODE = "ZA";
        public const string TANZANIA_COUNTRY_CODE = "TZ";
        public const string UGANDA_COUNTRY_CODE = "UG";

        // Currency Codes
        public const string EURO_CODE = "EUR";
        public const string GHANAIAN_CEDI_CODE = "GHS";
        public const string KENYAN_SHILLING_CODE = "KES";
        public const string NIGERIAN_NAIRA_CODE = "NGN";
        public const string POUND_STERLING_CODE = "GBP";
        public const string RWANDAN_FRANC_CODE = "RWF";
        public const string SIERRA_LEONEAN_LEONE_CODE = "SLL";
        public const string SOUTH_AFRICAN_RAND_CODE = "ZAR";
        public const string TANZANIAN_SHILLING_CODE = "TZS";
        public const string UGANDAN_SHILLING_CODE = "UGX";
        public const string UNITED_STATES_DOLLAR_CODE = "USD";
        public const string WEST_AFRICAN_CFA_FRANC_CODE = "XOF";
        public const string ZAMBIAN_KWACHA_CODE = "ZMW";

        // Others
        public static string ERROR_STATUS = "error";
        public static string UNAUTHORIZED_MESSAGE = "Invalid authorization key";
        public static string SAMPLE_CUSTOMER_NAME = "Yemi Desola";
        public static string SAMPLE_EMAIL = "user@gmail.com";
        public static string SAMPLE_PHONE_NUMBER = "08012345678";
        public static string SAMPLE_TX_REF = "hooli-tx-1920bbtytty";
        public static string SUCCESS_STATUS = "success";
        public static string SUCCESSFUL_STATUS = "successful";

        // Payments
        public static string INITIATE_PAYMENT_RESPONSE_MESSAGE = "Hosted Link";
        public static string SAMPLE_PAYMENT_DESCRIPTION = "Middleout isn't free. Pay the price";
        public static string SAMPLE_PAYMENT_TITLE = "Pied Piper Payments";

        // Transactions
        public static string GET_TRANSACTIONS_SUCCESS_MESSAGE = "Transactions fetched";
        public static string INVALID_TRANSACTION_ID = "123";
        public static string VALID_TRANSACTION_ID = "1541948";
        public static string VERIFY_TRANSACTION_ERROR_MESSAGE = "No transaction was found for this id";
        public static string VERIFY_TRANSACTION_UNAUTHORIZED_MESSAGE = "Invalid secret key passed";
        public static string VERIFY_TRANSACTION_SUCCESS_MESSAGE = "Transaction fetched successfully";

        // Urls
        public static string SAMPLE_BRAND_LOGO_URL = "https://assets.piedpiper.com/logo.png";
        public static string SAMPLE_REDIRECT_URL = "https://webhook.site/9d0b00ba-9a69-44fa-a43d-a82c33c36fdc";
    }
}
