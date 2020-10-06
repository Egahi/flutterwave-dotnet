using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetSubAccountsResponse : Response<List<GetSubAccounts>>
    {
        [JsonProperty("meta")]
        public Meta meta { get; set; }
    }
}