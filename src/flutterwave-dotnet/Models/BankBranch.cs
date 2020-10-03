using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class BankBranch
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }
        [JsonProperty("branch_name")]
        public string BranchName { get; set; }
        [JsonProperty("swift_code")]
        public string SwiftCode { get; set; }
        [JsonProperty("bic")]
        public string Bic { get; set; }
        [JsonProperty("bank_id")]
        public string BankId { get; set; }
    }
}
